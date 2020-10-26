using System;
using System.Collections.Generic;
using System.Text;

namespace BD.Business.Models
{
    public class CashFlow : Entity
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }

        public int? ReserveId { get; set; }
        public Reserve Reserve { get; set; }

        public MovementType MovementType { get; set; }
    }
}
