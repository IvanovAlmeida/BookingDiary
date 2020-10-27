using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BD.API.ViewModels.Role;

namespace BD.API.ViewModels.User
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public DateTime? DisabledAt { get; set; }

        public IEnumerable<RoleViewModel> Roles { get; set; }
    }
}
