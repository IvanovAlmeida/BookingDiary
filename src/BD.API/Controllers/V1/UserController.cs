using AutoMapper;

using System;
using System.Linq;
using System.Text;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

using BD.API.Extensions;
using BD.API.Helper.Search;
using BD.API.ViewModels.User;
using BD.Business.Models;
using BD.Business.Interfaces;
using Microsoft.Extensions.Options;
using BD.Data.Context;
using Microsoft.EntityFrameworkCore;
using BD.API.ViewModels.Role;

namespace BD.API.Controllers.V1
{
    //[Authorize]
    [Route("api/v{version:apiVersion}/users")]
    public class UserController : MainController
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly AppSettings _appSettings;

        public UserController(IUser appUser, INotificator notificador, IUserRepository userRepository, IMapper mapper, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IOptions<AppSettings> appSettings, RoleManager<AppRole> roleManager, IRoleRepository roleRepository) : base(appUser, notificador)
        {
            _mapper = mapper;
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _signInManager = signInManager;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            //_roleManager = roleManager;
        }

        [HttpGet("")]
        [ClaimsAuthorize("User", "All")]
        public async Task<IEnumerable<UserViewModel>> Search([FromQuery] UserSearchViewModel userSearch)
        {
            var expressionSearch = GenerateSearchingExpression(userSearch);
            var users = _mapper.Map<IEnumerable<UserViewModel>>(await _userRepository.Find(expressionSearch));

            return users;
        }

        [HttpGet("{id:int}")]
        [ClaimsAuthorize("User", "Get")]
        public async Task<ActionResult> Get(int id)
        {
            var user = await _userRepository.GetById(id);

            if (user == null) return NotFound();

            var rolesName = await _userManager.GetRolesAsync(user);
            var roles = await _roleRepository.Find(r => rolesName.Contains(r.Name));

            var userModel = _mapper.Map<UserViewModel>(user);

            var roleModel = _mapper.Map<IEnumerable<RoleViewModel>>(roles);

            userModel.Roles = roleModel;

            return CustomResponse(userModel);
        }

        [HttpPost("")]
        [ClaimsAuthorize("User", "Add")]
        public async Task<ActionResult> Add(RegisterUserViewModel registerUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new AppUser
            {
                Name = registerUser.Name,
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return CustomResponse(await GerarJwt(user.Email));
            }

            foreach (var error in result.Errors)
            {
                NotifyError(error.Description);
            }

            return CustomResponse(registerUser);
        }

        [HttpPut("{id:int}")]
        [ClaimsAuthorize("User", "Edit")]
        public async Task<ActionResult> Update(int id, UpdateUserViewModel updateUser)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var user = await _userManager.FindByIdAsync(id.ToString());

            user.Name = updateUser.Name;
            
            user.Email = updateUser.Email;
            user.NormalizedEmail = updateUser.Email.ToUpper();

            user.UserName = updateUser.Email;
            user.NormalizedUserName = updateUser.Email.ToUpper();

            var result = await _userManager.UpdateAsync(user);

            foreach (var error in result.Errors)
            {
                NotifyError(error.Description);
            }
            
            return CustomResponse(updateUser);
        }

        [HttpPut("update-roles/{id:int}")]
        [ClaimsAuthorize("User", "UpdateRoles")]
        public async Task<ActionResult> UpdateUserRole(int id, IEnumerable<RoleViewModel> rolesModel)
        {

            var user = await _userManager.FindByIdAsync(id.ToString());
            var userRoles = await _userManager.GetRolesAsync(user);

            var rolesToInsert = rolesModel.Where(rm => !userRoles.Contains(rm.Name));
            var rolesToRemove = userRoles.Where(ur => !rolesModel.Select(rm => rm.Name).Contains(ur));

            var result = await _userManager.AddToRolesAsync(user, rolesToInsert.Select(r => r.Name));
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    NotifyError(error.Description);
                }
                return CustomResponse(ModelState);
            }

            result = await _userManager.RemoveFromRolesAsync(user, rolesToRemove);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    NotifyError(error.Description);
                }
            }

            return CustomResponse(ModelState);
        }

        [HttpDelete("{id:int}")]
        [ClaimsAuthorize("User", "Disable")]
        public async Task<ActionResult> Disable(int id)
        {
            await _userRepository.Disable(id);
            return CustomResponse();
        }

        [HttpPatch("{id:int}")]
        [ClaimsAuthorize("User", "Reactive")]
        public async Task<ActionResult> Reactivate(int id)
        {
            await _userRepository.Reactivate(id);
            return CustomResponse();
        }

        [HttpPut("change-password")]
        [ClaimsAuthorize("User", "ChangePassword")]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel passwordViewModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var user = await _userManager.FindByIdAsync(this.UserId.ToString());
            if (user == null)
                return NotFound();

            var result = await _userManager.ChangePasswordAsync(user, passwordViewModel.OldPassword, passwordViewModel.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    NotifyError(error.Description);
                }
            }

            return CustomResponse(ModelState);
        }

        [HttpPut("change-user-password/{id:int}")]
        [ClaimsAuthorize("User", "ChangeUserPassword")]
        public async Task<ActionResult> ChangeUserPassword(int id, ChangeUserPasswordViewModel passwordViewModel)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            if (user == null)
                return NotFound();

            var result = await _userManager.RemovePasswordAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    NotifyError(error.Description);
                }
                return CustomResponse(ModelState);
            }

            result = await _userManager.AddPasswordAsync(user, passwordViewModel.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    NotifyError(error.Description);
                }
            }

            return CustomResponse(ModelState);
        }

        private async Task<LoginResponseViewModel> GerarJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToUnixEpochDate().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUnixEpochDate().ToString(), ClaimValueTypes.Integer64));
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            var response = new LoginResponseViewModel
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
                UserToken = new UserTokenViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Claims = claims.Select(c => new ViewModels.User.ClaimViewModel { Type = c.Type, Value = c.Value })
                }
            };

            return response;
        }

        private Expression<Func<AppUser, bool>> GenerateSearchingExpression(UserSearchViewModel userSearch)
        {
            var searchHelper = new SearchHelper<AppUser>();

            if (!string.IsNullOrWhiteSpace(userSearch.Name))
                searchHelper.AddAndExpression("Name", userSearch.Name, ExpressionOperation.Contains);
            
            if (!string.IsNullOrWhiteSpace(userSearch.Email))
                searchHelper.AddAndExpression("Email", userSearch.Email, ExpressionOperation.Contains);
            
            if (userSearch.Enabled != null && !(bool) userSearch.Enabled)
                searchHelper.AddAndExpression("DisabledAt", null, ExpressionOperation.NotEqualTo);
            
            if (userSearch.Enabled != null && ((bool) userSearch.Enabled))
                searchHelper.AddAndExpression("DisabledAt", null);
            
            return searchHelper.BuildExpression();
        }
    }
}
