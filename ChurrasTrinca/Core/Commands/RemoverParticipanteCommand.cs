using Core.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Commands
{
    public class RemoverParticipanteCommand : IRequest<object>
    {
        public RemoverParticipanteCommand(RemoverParticipanteDTO removerParticipanteDTO)
        {
            RemoverParticipanteDTO = removerParticipanteDTO;
        }

        public RemoverParticipanteDTO RemoverParticipanteDTO { get; }
    }
}
