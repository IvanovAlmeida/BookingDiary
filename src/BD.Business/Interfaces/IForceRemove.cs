using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using BD.Business.Models;

namespace BD.Business.Interfaces
{
    public interface IForceRemove<TEntity> : IDisposable where TEntity : Entity
    {
        Task ForceRemove(TEntity entity);
        Task ForceRemove(IEnumerable<TEntity> entities);
    }
}