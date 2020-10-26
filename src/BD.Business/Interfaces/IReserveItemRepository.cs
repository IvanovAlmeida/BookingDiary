using BD.Business.Models;

namespace BD.Business.Interfaces
{
    public interface IReserveItemRepository : IRepository<ReserveItem>, IForceRemove<ReserveItem>
    {
        
    }
}