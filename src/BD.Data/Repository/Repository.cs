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
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly DataDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(DataDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<Entity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<Entity>> FindWithPagination(Expression<Func<TEntity, bool>> predicate, int pageNumber = 1, int pageSize = 10)
        {
            return await DbSet
                            .AsNoTracking()
                            .Where(predicate)
                            .Skip(pageSize * (pageNumber - 1))
                            .Take(pageSize)
                            .ToListAsync();
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<TEntity> GetByIdNoTracking(int id)
        {
            var entity = await DbSet.FindAsync(id);
            Db.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<int> Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            var search = DbSet.AsNoTracking();

            if (predicate != null) search = search.Where(predicate);

            return await search.CountAsync();
        }

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
            return entity;
        }

        public virtual async Task Update(TEntity entity)
        {
            var dbEntity = await GetByIdNoTracking(entity.Id);

            entity.DisabledAt = dbEntity.DisabledAt;

            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Disable(int id)
        {
            var entity = await DbSet.FindAsync(id);

            entity.DisabledAt = DateTime.Now;

            //DbSet.Remove(entity);
            await SaveChanges();
        }

        public virtual async Task Reactivate(int id)
        {
            var entity = await DbSet.FindAsync(id);
            entity.DisabledAt = null;
            
            DbSet.Update(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }
        
        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
