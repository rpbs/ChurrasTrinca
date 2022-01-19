using AutoMapper;
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
            CreateMap<Participante, ParticipanteResponse>();
            CreateMap<Churrasco, ChurrascoResponse>();
        }
    }
}
