using System;
using System.Collections.Generic;
using System.Text;

namespace BD.Business.Models
{
    public class Reserve : Entity
    {
        public decimal Entry { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public IEnumerable<ReserveItem> ReserveItem { get; set; }
        public IEnumerable<CashFlow> CashFlows { get; set; }
    }
}
