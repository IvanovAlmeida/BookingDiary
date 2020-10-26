using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BD.Business.Models.Validations
{
    public class ItemValidation : AbstractValidator<Item>
    {
        public ItemValidation()
        {
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("O campo Nome precisa ser fornecido")
                .Length(2, 180).WithMessage("O campo Nome precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(r => r.Price)
                .NotEmpty().WithMessage("O campo Preço precisa ser fornecido")
                .GreaterThanOrEqualTo(1).WithMessage("O campo Preço precisa ser maior ou igual a {PropertyValue}");

            RuleFor(r => r.Quantity)
                .NotEmpty().WithMessage("O campo Quantidade precisa ser fornecido")
                .GreaterThanOrEqualTo(1).WithMessage("O campo Quantidade precisa ser maior ou igual a {PropertyValue}");

            RuleFor(r => r.Description)
                .Length(2, 1000).WithMessage("O campo Descrição precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
