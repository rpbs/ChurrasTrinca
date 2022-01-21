using AutoMapper;
using Core.DTO;
using Core.Entities;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapper
{
    public class CoreProfile : Profile
    {
        public CoreProfile()
        {
            // falta adicionar no startup
            CreateMap<ParticipanteDTO, Participante>();
            CreateMap<Participante, ParticipanteResponse>();
            CreateMap<ChurrascoDTO, Churrasco>();
            CreateMap<Churrasco, ChurrascoResponse>()
                .ForMember(x => x.QuantidadePessoas, opt => opt.MapFrom(x => x.Participantes.Count))
                .ForMember(x => x.ValorTotal, opt => opt.MapFrom(x => x.Participantes.Sum(x => x.ValorContribuicao)));
        }
    }
}
