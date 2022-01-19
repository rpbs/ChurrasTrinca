using Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Queries.Handlers
{
    public class ChurrascoQueryHandler : 
        IRequestHandler<ChurrascoParticipantesByIdQuery, List<ParticipanteResponse>>,
        IRequestHandler<ChurrascoByIdQuery, ChurrascoResponse>,
        IRequestHandler<ChurrascoQuery, IReadOnlyList<ChurrascoResponse>>
    {
        public Task<List<ParticipanteResponse>> Handle(ChurrascoParticipantesByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ChurrascoResponse> Handle(ChurrascoByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<ChurrascoResponse>> Handle(ChurrascoQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
