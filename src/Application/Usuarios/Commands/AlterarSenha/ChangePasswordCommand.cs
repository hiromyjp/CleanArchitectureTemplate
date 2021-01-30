using Hiro.Core.Application.Common.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hiro.Core.Application.Usuarios.Commands.AlterarSenha
{
    public class ChangePasswordCommand : IRequest
    {
        public ChangePasswordCommand(AlterarSenhaDto value)
        {
            Value = value;
        }

        public AlterarSenhaDto Value { get; set; }

        class ChangePasswordCommandhandler : IRequestHandler<ChangePasswordCommand>
        {
            private readonly IApplicationDbContext _dbcontext;
            private readonly IUserManager _userManager;

            public ChangePasswordCommandhandler(IUserManager userManager, IApplicationDbContext dbcontext)
            {
                _userManager = userManager;
                _dbcontext = dbcontext;
            }

            public async Task<Unit> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
                //var colaborador = BuscarColaborador(request.Value.ColaboradorId);
                //await _userManager.ResetPasswordAsync(colaborador.CodigoUsuario.ToString(), request.Value.NovaSenha);
                //return Unit.Value;
            }

        }
    }
}
