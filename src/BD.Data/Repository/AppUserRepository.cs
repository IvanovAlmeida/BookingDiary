using BD.Business.Interfaces;
using BD.Business.Models;
using BD.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BD.Data.Repository
{
    public abstract class AppUserRepository<TEntity> : IAppUserRepository<TEntity> where TEntity : AppUser, new()
    {
        protected readonly DataDbContext Db;
        protected readonly DbSet<AppUser> DbSet;

        protected AppUserRepository(DataDbContext db)
        {
            Db = db;
            DbSet = db.Set<AppUser>();
        }

        public async Task<IEnumerable<AppUser>> Find(Expression<Func<AppUser, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<AppUser>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<AppUser> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task Disable(int id)
        {
            var entity = await DbSet.FindAsync(id);
            entity.DisabledAt = DateTime.Now;
            await SaveChanges();
        }

        public async Task Reactivate(int id)
        {
            var entity = await DbSet.FindAsync(id);
            entity.DisabledAt = null;
            await SaveChanges();
        }

        public async Task SaveChanges()
        {
            await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
