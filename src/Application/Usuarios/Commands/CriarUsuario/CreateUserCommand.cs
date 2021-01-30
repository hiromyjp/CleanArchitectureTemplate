using Hiro.Core.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hiro.Core.Application.Usuarios.Commands.CriarUsuario
{
    public class CreateUserCommand : IRequest
    {

        public CreateUserCommand(CreateUserDto value)
        {
            Value = value;
        }

        public CreateUserDto Value { get; }


        class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
        {
            private readonly IApplicationDbContext _dbcontext;
            private readonly IUserManager _userManager;

            public CreateUserCommandHandler(IApplicationDbContext dbcontext, IUserManager userManager)
            {
                _dbcontext = dbcontext;
                _userManager = userManager;
            }

            public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _userManager.CreateUserAsync(request.Value.Username, request.Value.Password, request.Value.RoleName);
                await _dbcontext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
