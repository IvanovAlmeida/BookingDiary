using BD.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BD.Business.Interfaces
{
    public interface IAppUserRepository<TEntity> : IDisposable where TEntity : AppUser
    {
        Task<AppUser> GetById(int id);
        Task<IEnumerable<AppUser>> GetAll(); 
        Task<IEnumerable<AppUser>> Find(Expression<Func<AppUser, bool>> predicate);

        Task Disable(int id);
        Task Reactivate(int id);
        Task SaveChanges();
    }
}
