using AutoMapper;

using BD.Business.Models;

using BD.API.ViewModels;
using BD.API.ViewModels.Item;
using BD.API.ViewModels.User;
using BD.API.ViewModels.Role;
using BD.API.ViewModels.Reserve;
using BD.API.ViewModels.CashFlow;
using BD.API.ViewModels.Permission;

namespace BD.API.AutoMapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Item, ItemViewModel>().ReverseMap();
            
            CreateMap<Reserve, ReserveViewModel>().ReverseMap();
            CreateMap<ReserveItem, ReserveItemViewModel>().ReverseMap();

            CreateMap<CashFlow, CashFlowViewModel>().ReverseMap();

            CreateMap<Permission, PermissionViewModel>().ReverseMap();

            CreateMap<AppUser, UserViewModel>().ReverseMap();

            CreateMap<AppRole, RoleViewModel>().ReverseMap();
        }
    }
}
