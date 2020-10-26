using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BD.API.ViewModels.Reserve
{
    public class ReserveViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Entrada")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(1, double.MaxValue, ErrorMessage = "O campo {0} deve possuir o valor mínimo de {1}.")]
        public decimal Entry { get; set; }
        
        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(1, double.MaxValue, ErrorMessage = "O campo {0} deve possuir o valor mínimo de {1}.")]
        public decimal Price { get; set; }
        
        [Display(Name = "Descrição")]
        [StringLength(500, ErrorMessage = "O campo deve ter no máximo {1} caracteres.")]
        public string Description { get; set; }

        [Display(Name = "Data de Entrada")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime DateStart { get; set; }

        [Display(Name = "Data de Saída")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime DateEnd { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public DateTime? DisabledAt { get; set; }
        
        public IEnumerable<ReserveItemViewModel> ReserveItem { get; set; }
    }
}
