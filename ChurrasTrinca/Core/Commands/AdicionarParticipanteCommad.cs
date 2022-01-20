using Core.DTO;
using Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Commands
{
    public class AdicionarParticipanteCommad : IRequest<ParticipanteResponse>
    {
        public AdicionarParticipanteCommad(ParticipanteDTO participanteDTO)
        {
            ParticipanteDTO = participanteDTO;
        }

        public ParticipanteDTO ParticipanteDTO { get; }
    }
}
