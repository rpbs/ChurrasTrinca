using Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Queries
{
    public class ParticipanteByChurrascoIdQuery : IRequest<List<ParticipanteResponse>>
    {
    }
}
