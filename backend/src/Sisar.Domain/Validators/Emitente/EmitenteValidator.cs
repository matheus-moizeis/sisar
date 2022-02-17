#region Namespaces

using FluentValidation;
using Sisar.Domain.Entities;

#endregion

namespace Sisar.Domain.Validators
{
    public class EmitenteValidator : AbstractValidator<Emitente>
    {
        public EmitenteValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula");

            RuleFor(x => x.RazaoSocial)
                .NotNull()
                .WithMessage("Razão Social não pode ser nula")
                .MaximumLength(50)
                .WithMessage("Razão social deve ter no máximo 50 caracteres")
                .MinimumLength(10)
                .WithMessage("Razão social deve ter no mínimo 10 caracteres");

            RuleFor(x => x.NomeFantasia)
               .NotNull()
               .WithMessage("Nome Fantasia não pode ser nula")
               .MaximumLength(50)
               .WithMessage("Razão social deve ter no máximo 50 caracteres")
               .MinimumLength(3)
               .WithMessage("Razão social deve ter no mínimo 3 caracteres");

            RuleFor(x => x.Cnpj)
                .NotNull()
                .WithMessage("O campo CNPJ não pode ser nulo")
                .IsValidCNPJ();

        }
    }
}
