using System;
using System.Collections.Generic;
using System.Text;
using BD.Business.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BD.Business.Models
{
    public class AppUser : IdentityUser<int>, ITrackable, IIsDeleted
    {
        public AppUser(string userName) : base(userName) { }
        public AppUser() { }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public DateTime? DisabledAt { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int DisabledBy { get; set; }
    }
}
