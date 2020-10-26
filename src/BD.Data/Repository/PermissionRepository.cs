using BD.Business.Interfaces;
using BD.Business.Models;
using BD.Data.Context;

namespace BD.Data.Repository
{
    public class PermissionRepository : Repository<Permission>, IPermissionRepository
    {
        public PermissionRepository(DataDbContext db) : base(db)
        { }
    }
}
