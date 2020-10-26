using BD.Business.Interfaces;
using BD.Business.Models;
using BD.Data.Context;

namespace BD.Data.Repository
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(DataDbContext db) : base(db) { }
    }
}
