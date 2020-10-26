using BD.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BD.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Update(TEntity entity);
        Task Disable(int id);
        Task Reactivate(int id);
        Task<IEnumerable<Entity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<Entity>> FindWithPagination(Expression<Func<TEntity, bool>> predicate, int pageNumber = 1, int pageSize = 10);
        Task<int> Count(Expression<Func<TEntity, bool>> predicate = null);
        Task<int> SaveChanges();
    }
}
