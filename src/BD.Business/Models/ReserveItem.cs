namespace BD.Business.Models
{
    public class ReserveItem : Entity
    {
        public int IdReserveItem { get; set; }

        public int ReserveId { get; set; }
        public Reserve Reserve { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
    }
}
