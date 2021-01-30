using AutoMapper;
using Hiro.Core.Application.Common.Mappings;
using Hiro.Core.Domain.Entities;
using System;

namespace Hiro.Core.Application.Depositos.Queries.ListarDepositos
{
    public class DepositoDto : IMapFrom<Deposito>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Deposito, DepositoDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Nome, opt => opt.MapFrom(s => s.Nome));
        }
    }
}
