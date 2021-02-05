using AutoMapper;
using AutoMapper.QueryableExtensions;
using Hiro.Core.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Hiro.Core.Application.Warehouses.Queries.ListWarehouses
{
    public class ListWarehousesQuery : IRequest<ListWarehousesResponse>
    {
    }

    class ListWarehousesQueryHandler : IRequestHandler<ListWarehousesQuery, ListWarehousesResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public ListWarehousesQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ListWarehousesResponse> Handle(ListWarehousesQuery request, CancellationToken cancellationToken)
        {
            var warehousese = await _dbContext.Warehouses
                .ProjectTo<WarehouseDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var response = new ListWarehousesResponse()
            {
                Warehouses = warehousese
            };
            return response;
        }
    }
}
