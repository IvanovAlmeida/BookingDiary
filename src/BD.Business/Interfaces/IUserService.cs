using System;

namespace BD.Business.Interfaces
{
    public interface IUserService : IDisposable
    {
        void Disable(int id);
        void Reactivate(int id);
    }
}