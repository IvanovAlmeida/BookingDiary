using BD.Business.Interfaces;
using BD.Business.Models;
using BD.Data.Context;

namespace BD.Data.Repository
{
    public class CashFlowRepository : Repository<CashFlow>, ICashFlowRespository
    {
        public CashFlowRepository(DataDbContext db) : base(db)
        { }
    }
}
