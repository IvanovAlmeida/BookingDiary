using System;

namespace BD.API.ViewModels.Reserve
{
    public class ReserveSearchViewModel
    {
        public decimal? MinEntry { get; set; }

        public decimal? MaxEntry { get; set; }

        public decimal? MinPrice { get; set; }
        
        public decimal? MaxPrice { get; set; }

        public DateTime? MinDateStart { get; set; }

        public DateTime? MaxDateStart { get; set; }
        
        public bool? Enabled { get; set; }
    }
}