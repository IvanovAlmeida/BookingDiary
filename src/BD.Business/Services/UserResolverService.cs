using Microsoft.AspNetCore.Http;
using BD.Business.Extensions;
using System.Diagnostics;

namespace BD.Business.Services
{
    public class UserResolverService
    {
        private readonly IHttpContextAccessor _context;
        public UserResolverService(IHttpContextAccessor context)
        {
            _context = context;
        }

        public bool IsAuthenticated()
        {
            if (_context.HttpContext == null)
                return false;

            if (_context.HttpContext.User == null)
                return false;

            return _context.HttpContext.User.Identity.IsAuthenticated;
        }

        public int GetUserId()
        {
            return IsAuthenticated() ? int.Parse(_context.HttpContext.User.GetUserId()) : 0;
        }
    }
}
