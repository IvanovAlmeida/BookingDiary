using AutoMapper;
using BD.API.Extensions;
using BD.API.ViewModels.Permission;
using BD.Business.Interfaces;
using BD.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BD.API.Controllers.V1
{
    //[Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/permissions")]
    public class PermissionController : MainController
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly IMapper _mapper;
        
        public PermissionController(IUser appUser, INotificator notificator, IPermissionRepository permissionRepository, IMapper mapper) : base(appUser, notificator)
        {
            _permissionRepository = permissionRepository;
            _mapper = mapper;
        }

        [HttpGet("")]
        //[ClaimsAuthorize("Permission", "All")]
        public async Task<IEnumerable<PermissionViewModel>> All()
        {
            var permissions = _mapper.Map<IEnumerable<PermissionViewModel>>(await _permissionRepository.GetAll());
            return permissions;
        }

        [HttpPost("")]
        [ClaimsAuthorize("Permission", "Add")]
        public async Task<ActionResult> Add(PermissionViewModel permissionViewModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(permissionViewModel);

            var permission = _mapper.Map<Permission>(permissionViewModel);
            permission = await _permissionRepository.Add(permission);

            return CustomResponse(_mapper.Map<PermissionViewModel>(permission));
        }

        [HttpPut("{id:int}")]
        [ClaimsAuthorize("Permission", "Edit")]
        public async Task<ActionResult> Update(int id, PermissionViewModel permissionViewModel)
        {
            var permission = await _permissionRepository.GetById(id);

            if (permission == null)
                return NotFound();

            if (!ModelState.IsValid)
                return CustomResponse(permissionViewModel);

            permission = _mapper.Map<Permission>(permissionViewModel);
            await _permissionRepository.Update(permission);

            return CustomResponse(_mapper.Map<PermissionViewModel>(permission));
        }

        [HttpDelete("{id:int}")]
        [ClaimsAuthorize("Permission", "Delete")]
        public async Task<ActionResult> Disable(int id)
        {
            await _permissionRepository.Disable(id);
            return CustomResponse();
        }
    }
}
