using BD.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BD.API.Configuration
{
    public static class AdminClaimsConfiguration
    {
        public static IApplicationBuilder ConfigureAdminClaims(this IApplicationBuilder app, IServiceScopeFactory serviceScopeFactory)
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<DataDbContext>();
                var permissions = context.Permissions.ToList();

                var claims = context.RoleClaims.ToList();

                foreach (var claim in claims)
                    if (!permissions.Where(p => p.Type == claim.ClaimType && p.Value == claim.ClaimValue).Any())
                        context.RoleClaims.Remove(claim);

                claims = claims.Where(c => c.RoleId == 1).ToList();

                foreach (var permission in permissions)
                    if (!claims.Where(c => c.ClaimType == permission.Type && c.ClaimValue == permission.Value).Any())
                        context.RoleClaims.Add(new IdentityRoleClaim<int> { RoleId = 1, ClaimType = permission.Type, ClaimValue = permission.Value });

                context.SaveChanges();
            }

            return app;
        }
    }
}
