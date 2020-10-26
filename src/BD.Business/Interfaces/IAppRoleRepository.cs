using BD.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BD.Business.Interfaces
{
    public interface IAppRoleRepository<TEntity> : IDisposable where TEntity : AppRole
    {
        Task<AppRole> GetById(int id);
        Task<IEnumerable<AppRole>> GetAll();
        Task<IEnumerable<AppRole>> Find(Expression<Func<AppRole, bool>> predicate);

        Task Disable(int id);
        Task Reactivate(int id);
        Task SaveChanges();
    }
}
