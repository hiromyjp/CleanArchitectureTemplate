using FluentValidation;

namespace Hiro.Core.Application.Usuarios.Commands.AlterarSenha
{
    class AlterarSenhaValidator : AbstractValidator<ChangePasswordCommand>
    {
        public AlterarSenhaValidator()
        {
            RuleFor(x => x.Value).SetValidator(new AlterarSenhaDtoValidator());
        }
    }

    class AlterarSenhaDtoValidator : AbstractValidator<AlterarSenhaDto>
    {
        public AlterarSenhaDtoValidator()
        {
            RuleFor(x => x.ColaboradorId).NotEmpty().WithMessage("Colaborador deve ser informado");
            RuleFor(x => x.NovaSenha).NotEmpty().MinimumLength(4).WithMessage("Nova senha deve ser maior ou igual a 4 caracteres");
        }
    }
}
