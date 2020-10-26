using System.Collections.Generic;

namespace BD.API.ViewModels.User
{
    public class UserTokenViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<ClaimViewModel> Claims { get; set; }
    }
}