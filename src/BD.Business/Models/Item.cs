using System.Collections;
using System.Collections.Generic;

namespace BD.Business.Models
{
    public class Item : Entity
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public IEnumerable<ReserveItem> ReserveItems { get; set; }
    }
}
