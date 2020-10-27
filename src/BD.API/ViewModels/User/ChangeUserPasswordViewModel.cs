using System.ComponentModel.DataAnnotations;

namespace BD.API.ViewModels.User
{
    public class ChangeUserPasswordViewModel
    {
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
