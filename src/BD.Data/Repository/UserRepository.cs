using BD.Business.Interfaces;
using BD.Business.Models;
using BD.Data.Context;

namespace BD.Data.Repository
{
    public class UserRepository : AppUserRepository<AppUser>, IUserRepository
    {
        public UserRepository(DataDbContext db) : base(db)
        {
        }
    }
}
