using AutoMapper;
using Core.Interface;
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
    public class ParticipanteQueryHandler :
                IRequestHandler<ParticipanteByChurrascoIdQuery, IReadOnlyList<ParticipanteResponse>>
    {

        private readonly IMapper _mapper;
        private readonly IParticipanteRepository _participanteRepository;

        public ParticipanteQueryHandler(IMapper mapper, IParticipanteRepository participanteRepository)
        {
            _mapper = mapper;
            _participanteRepository = participanteRepository;
        }

        public async Task<IReadOnlyList<ParticipanteResponse>> Handle(ParticipanteByChurrascoIdQuery request, CancellationToken cancellationToken)
        {
            var participantes = await _participanteRepository.ObterParticipantes(request.ChurrascoId);
            var resposta = _mapper.Map<IReadOnlyList<ParticipanteResponse>>(participantes);
            return resposta;
        }
    }
}
