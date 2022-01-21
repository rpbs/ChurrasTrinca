using Core.DTO;
using Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Queries
{
    public class ChurrascoParticipantesByIdQuery : IRequest<IReadOnlyList<ParticipanteResponse>>
    {
        public ChurrascoParticipantesByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
