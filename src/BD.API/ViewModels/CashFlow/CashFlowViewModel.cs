using BD.API.ViewModels.Reserve;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BD.API.ViewModels.CashFlow
{
    public class CashFlowViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(500, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        public string Description { get; set; }

        [Display(Name = "Data")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime Date { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(1, double.MaxValue, ErrorMessage = "O campo {0} deve possuir o valor mínimo de {1}.")]
        public decimal Value { get; set; }

        [Display(Name = "ReservaId")]
        public int? ReserveId { get; set; }

        [Display(Name = "Tipo de Movimentacao")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(0, 1, ErrorMessage = "O campo {0} deve possuir o valor mínimo de {1} e máximo de {2}.")]
        public int MovementType { get; set; }

        [Display(Name = "Reserva")]
        public ReserveViewModel Reserve { get; set; }
    }
}
