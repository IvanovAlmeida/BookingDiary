using BD.Business.Interfaces;
using BD.Business.Models;
using BD.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BD.Data.Repository
{
    public class ReserveRepository : Repository<Reserve>, IReserveRepository
    {
        public ReserveRepository(DataDbContext db) : base(db) { }

        public async Task<IEnumerable<Reserve>> FindWithItemsAndPagination(Expression<Func<Reserve, bool>> predicate, int pageNumber = 1, int pageSize = 10)
        {
            var reserves = await DbSet
                                    .AsNoTracking()
                                    .Include(r => r.ReserveItem)
                                    .ThenInclude(ri => ri.Item)
                                    .Where(predicate)
                                    .Skip(pageSize * (pageNumber - 1))
                                    .Take(pageSize)
                                    .ToListAsync();

            return reserves;
        }

        public async Task<IEnumerable<Reserve>> GetAllReservesWithItems()
        {
            var reserves = await DbSet
                                    .AsNoTracking()
                                    .Include(r => r.ReserveItem)
                                    .ThenInclude(ri => ri.Item)
                                    .ToListAsync();
            return reserves;
        }

        public async Task<Reserve> GetByIdWithItems(int id)
        {
            var reserve = await DbSet
                                    .AsNoTracking()
                                    .Include(r => r.ReserveItem)
                                    .ThenInclude(ri => ri.Item)
                                    .Where(r => r.Id == id)
                                    .FirstOrDefaultAsync();

            return reserve;
        }
    }
}
