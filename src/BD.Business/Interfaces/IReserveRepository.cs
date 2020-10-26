using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using BD.Business.Models;

namespace BD.Business.Interfaces
{
    public interface IReserveRepository : IRepository<Reserve>
    {
        Task<IEnumerable<Reserve>> GetAllReservesWithItems();
        Task<IEnumerable<Reserve>> FindWithItemsAndPagination(Expression<Func<Reserve, bool>> predicate, int pageNumber = 1, int pageSize = 10);
        Task<Reserve> GetByIdWithItems(int id);
    }
}
