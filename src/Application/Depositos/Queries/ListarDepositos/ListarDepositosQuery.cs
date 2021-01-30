using AutoMapper;
using AutoMapper.QueryableExtensions;
using Hiro.Core.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Hiro.Core.Application.Depositos.Queries.ListarDepositos
{
    public class ListarDepositosQuery : IRequest<ListarDepositosResponse>
    {
    }

    class ListarDepositosQueryHandler : IRequestHandler<ListarDepositosQuery, ListarDepositosResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public ListarDepositosQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ListarDepositosResponse> Handle(ListarDepositosQuery request, CancellationToken cancellationToken)
        {
            var depositos = await _dbContext.Depositos
                .ProjectTo<DepositoDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var response = new ListarDepositosResponse()
            {
                Depositos = depositos
            };
            return response;
        }
    }
}
