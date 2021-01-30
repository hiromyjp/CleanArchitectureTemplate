using FluentValidation;
using Hiro.Core.Application.Usuarios.Commands.CriarUsuario;

namespace Hiro.Core.Application.Usuarios.Commands.CriarUsuario
{
    class CriarUsuarioValidator : AbstractValidator<CreateUserCommand>
    {
        public CriarUsuarioValidator()
        {
            RuleFor(x => x.Value).SetValidator(new CriarUsuarioDtoValidator());
        }
    }

    class CriarUsuarioDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CriarUsuarioDtoValidator()
        {
            RuleFor(x => x.ColaboradorId).NotNull().NotEmpty().WithMessage("Um colaborador deve ser informado");
            RuleFor(x => x.Username).NotNull().NotEmpty().WithMessage("Um nome de usuário deve ser informado");
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Uma senha deve ser informada");
        }
    }
}
