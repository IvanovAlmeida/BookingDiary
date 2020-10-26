using BD.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BD.Business.Interfaces
{
    public interface IUserRepository : IAppUserRepository<AppUser>
    {
    }
}
