namespace BD.API.ViewModels.Role
{
    public class ClaimViewModel
    {
        public int Id { get; set; }
        public int RoleId { get; set; }

        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        
        public RoleViewModel Role { get; set; }
    }
}