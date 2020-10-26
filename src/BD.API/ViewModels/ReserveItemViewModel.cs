using System.ComponentModel.DataAnnotations;

using BD.API.ViewModels.Item;
using BD.API.ViewModels.Reserve;

namespace BD.API.ViewModels
{
    public class ReserveItemViewModel
    {
        public int IdReserveItem { get; set; }

        [Display(Name = "ID Item")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} deve possuir o valor mínimo de {1}.")]
        public int ItemId { get; set; }

        [Display(Name = "ID Reserva")]
        //[Required(ErrorMessage = "O campo {0} é obrigatório.")]
        //[Range(1, int.MaxValue, ErrorMessage = "O campo {0} deve possuir o valor mínimo de {1}.")]
        public int ReserveId { get; set; }

        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} deve possuir o valor mínimo de {1}.")]
        public int Quantity { get; set; }

        [Display(Name = "PrecoPorUnidade")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} deve possuir o valor mínimo de {1}.")]
        public decimal PricePerUnit { get; set; }

        public ItemViewModel Item { get; set; }
        public ReserveViewModel Reserve { get; set; }
    }
}
