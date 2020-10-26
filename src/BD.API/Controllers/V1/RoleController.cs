using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using BD.API.Extensions;
using BD.API.ViewModels.Role;
using BD.Business.Interfaces;
using BD.Business.Models;
using BD.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BD.API.Controllers.V1
{
    [Route("api/v{version:apiVersion}/roles")]
    public class RoleController : MainController
    {
        private readonly IRoleRepository _roleRepository;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly DataDbContext _context;
        private readonly IMapper _mapper;

        public RoleController(IUser appUser, INotificator notificator,
                                RoleManager<AppRole> roleManager, IMapper mapper, DataDbContext context, IRoleRepository roleRepository) : base(appUser, notificator)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _context = context;
            _roleRepository = roleRepository;
        }

        [HttpGet("")]
        [ClaimsAuthorize("Role", "All")]
        public async Task<IEnumerable<AppRole>> All()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return roles;
        }

        [HttpGet("{id:int}")]
        [ClaimsAuthorize("Role", "Get")]
        public async Task<ActionResult<RoleViewModel>> Get(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            var claims = await _context.RoleClaims.AsNoTracking().Where(c => c.RoleId == id).ToListAsync();
            
            var claimsModel = new List<ClaimViewModel>();
            foreach(var claim in claims)
            {
                claimsModel.Add(new ClaimViewModel { 
                    Id = claim.Id,
                    RoleId = role.Id,
                    ClaimType = claim.ClaimType,
                    ClaimValue = claim.ClaimValue,
                });
            }

            var roleModel = new RoleViewModel
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description,
                Claims = claimsModel
            };

            return CustomResponse(roleModel);
        }
        
        [HttpPost("")]
        [ClaimsAuthorize("Role", "Add")]
        public async Task<ActionResult> Add(RoleViewModel roleViewModel)
        {
            var role = _mapper.Map<AppRole>(roleViewModel);
            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
                return CustomResponse();

            foreach(var error in result.Errors)
                NotifyError(error.Description);

            return CustomResponse();
        }

        [HttpPut("{id:int}")]
        [ClaimsAuthorize("Role", "Edit")]
        public async Task<ActionResult> Update(int id, RoleViewModel roleViewModel)
        {
            var role = _mapper.Map<AppRole>(roleViewModel);
            var roleToUpdate = await _roleManager.FindByIdAsync(id.ToString());

            roleToUpdate.Name = role.Name;
            roleToUpdate.NormalizedName = role.Name.ToUpper();
            roleToUpdate.Description = role.Description;

            //await _roleRepository.Update(roleToUpdate);

            var result = await _roleManager.UpdateAsync(roleToUpdate);
            
            if (result.Succeeded)
                return CustomResponse();

            foreach (var error in result.Errors)
                NotifyError(error.Description);

            return CustomResponse();
        }

        [HttpDelete("{id:int}")]
        [ClaimsAuthorize("Role", "Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role == null)
                return NotFound();

            var result = await _roleManager.DeleteAsync(role);
            
            if(result.Succeeded)
                return CustomResponse();

            foreach (var error in result.Errors)
                NotifyError(error.Description);

            return CustomResponse();
        }

        [HttpPost("add-claim/{id:int}")]
        [ClaimsAuthorize("Role", "AddClaim")]
        public async Task<ActionResult> AddClaim(int id, ClaimViewModel claimViewModel)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());

            var claim = new Claim(claimViewModel.ClaimType, claimViewModel.ClaimValue);

            var claims = await _roleManager.GetClaimsAsync(role);

            if (claims.Where(c => c.Value == claim.Value && c.Type == claim.Type).Any())
                return CustomResponse();
                        
            var result = await _roleManager.AddClaimAsync(role, claim);

            if (result.Succeeded)
                return CustomResponse();

            foreach (var error in result.Errors)
                NotifyError(error.Description);

            return CustomResponse();
        }

        [HttpDelete("remove-claim/{id}")]
        [ClaimsAuthorize("Role", "DeleteClaim")]
        public async Task<ActionResult> RemoveClaim(int id, ClaimViewModel claimViewModel)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            var claim = new Claim(claimViewModel.ClaimType, claimViewModel.ClaimValue);

            var result = await _roleManager.RemoveClaimAsync(role, claim);

            if (result.Succeeded)
                return CustomResponse();

            foreach (var error in result.Errors)
                NotifyError(error.Description);

            return CustomResponse();
        }
    }
}