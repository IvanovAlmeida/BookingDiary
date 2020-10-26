using BD.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BD.Business.Interfaces
{
    public interface IItemService : IDisposable
    {
        Task<Item> Add(Item item);
        Task Update(Item item);
        Task Disable(int id);
        Task Reactivate(int id);
    }
}
