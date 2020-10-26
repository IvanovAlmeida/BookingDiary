namespace BD.API.ViewModels.Item
{
    public class ItemSearchViewModel
    {
        public string Name { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? MinQuantity { get; set; }
        public int? MaxQuantity { get; set; }
        public string Description { get; set; }

        public bool? Enabled { get; set; }
    }
}