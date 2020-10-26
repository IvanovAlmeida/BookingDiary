using BD.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BD.Business.Interfaces
{
    public interface IReserveService : IDisposable
    {
        Task<Reserve> Add(Reserve reserve);
        Task Update(Reserve reserve);
        Task Disable(int id);
        Task Reactivate(int id);
    }
}
