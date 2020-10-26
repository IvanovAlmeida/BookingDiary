using System.Collections.Generic;
using System.Threading.Tasks;
using BD.Business.Interfaces;
using BD.Business.Models;
using BD.Data.Context;

namespace BD.Data.Repository
{
    public class ReserveItemRepository : Repository<ReserveItem>, IReserveItemRepository
    {
        public ReserveItemRepository(DataDbContext db) : base(db)
        { }

        public async Task ForceRemove(ReserveItem entity)
        {
            DbSet.Remove(entity);
            await SaveChanges();
        }

        public async Task ForceRemove(IEnumerable<ReserveItem> entities)
        {
            DbSet.RemoveRange(entities);
            await SaveChanges();
        }
    }
}