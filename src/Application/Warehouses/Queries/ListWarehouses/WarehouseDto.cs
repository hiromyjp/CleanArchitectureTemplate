using AutoMapper;
using Hiro.Core.Application.Common.Mappings;
using Hiro.Core.Domain.Entities;
using System;

namespace Hiro.Core.Application.Warehouses.Queries.ListWarehouses
{
    public class WarehouseDto : IMapFrom<Warehouse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int BranchId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Warehouse, WarehouseDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.BranchId, opt => opt.MapFrom(s => s.BranchId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name));
        }
    }
}
