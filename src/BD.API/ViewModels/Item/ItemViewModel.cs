using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BD.API.ViewModels.Item
{
    public class ItemViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(180,  ErrorMessage = "O campo {0} deve possuir entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Name { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(1, double.MaxValue, ErrorMessage = "O campo {0} deve possuir o valor mínimo de {1}.")]
        public decimal Price { get; set; }

        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} deve possuir o valor mínimo de {1}.")]
        public int Quantity { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(1000, ErrorMessage = "O campo {0} deve possuir no máximo {1} caracteres.")]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public DateTime? DisabledAt { get; set; }
    }
}
