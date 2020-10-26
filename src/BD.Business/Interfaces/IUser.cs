using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace BD.Business.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        int GetUserId();
        string GetUserEmail();
        bool IsAuthenticated();
        bool IsInRole(string role);
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
