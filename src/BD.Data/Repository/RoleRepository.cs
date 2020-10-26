using BD.Business.Interfaces;
using BD.Business.Models;
using BD.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BD.Data.Repository
{
    public class RoleRepository : AppRoleRepository<AppRole>, IRoleRepository
    {
        public RoleRepository(DataDbContext db) : base(db)
        {
        }

        public async Task Update(AppRole role)
        {
            DbSet.Update(role);
            await SaveChanges();
        }
    }
}
