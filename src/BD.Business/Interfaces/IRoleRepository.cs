using BD.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BD.Business.Interfaces
{
    public interface IRoleRepository : IAppRoleRepository<AppRole>
    {
        Task Update(AppRole role);
    }
}
