using BD.Business.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;

namespace BD.Business.Models
{
    public class AppRole : IdentityRole<int>, ITrackable, IIsDeleted
    {
        public AppRole(string roleName) : base(roleName) { }
        public AppRole() { }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public DateTime? DisabledAt { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int DisabledBy { get; set; }
    }
}
