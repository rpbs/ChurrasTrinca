using AutoMapper;
using Core.Interface;
using Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace Core.Queries.Handlers
{
    public class ChurrascoQueryHandler : 
        IRequestHandler<ChurrascoByIdQuery, ChurrascoResponse>,
        IRequestHandler<ChurrascoQuery, IReadOnlyList<ChurrascoResponse>>,
        IRequestHandler<ChurrascoParticipantesByIdQuery, IReadOnlyList<ParticipanteResponse>>
    {

        private readonly IChurrascoRepository _churrascoRepository;
        private readonly IParticipanteRepository _participanteRepository;
        private readonly IMapper _mapper;

        public ChurrascoQueryHandler(IChurrascoRepository churrascoRepository, IParticipanteRepository participanteRepository, IMapper mapper)
        {
            _churrascoRepository = churrascoRepository;
            _participanteRepository = participanteRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ChurrascoResponse>> Handle(ChurrascoQuery request, CancellationToken cancellationToken)
        {
            var todosChurrascos = await _churrascoRepository.ChurrascosAgendados();
            var respostas = _mapper.Map<IReadOnlyList<ChurrascoResponse>>(todosChurrascos);
            return respostas;
        }

        public async Task<ChurrascoResponse> Handle(ChurrascoByIdQuery request, CancellationToken cancellationToken)
        {
            var churrasco = await _churrascoRepository.GetById(request.Id);
            var resposta = _mapper.Map<ChurrascoResponse>(churrasco);
            return resposta;
        }

        public async Task<IReadOnlyList<ParticipanteResponse>> Handle(ChurrascoParticipantesByIdQuery request, CancellationToken cancellationToken)
        {
            var churrasco = await _participanteRepository.ObterParticipantes(request.Id);
            var resposta = _mapper.Map<IReadOnlyList<ParticipanteResponse>>(churrasco);
            return resposta;
        }
    }
}
