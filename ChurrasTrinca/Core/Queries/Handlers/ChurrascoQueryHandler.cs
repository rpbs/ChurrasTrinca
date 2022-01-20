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
        IRequestHandler<ChurrascoQuery, IReadOnlyList<ChurrascoResponse>>        
    {

        private readonly IChurrascoRepository _churrascoRepository;
        private readonly IMapper _mapper;

        public ChurrascoQueryHandler(IChurrascoRepository churrascoRepository, IMapper mapper)
        {
            _churrascoRepository = churrascoRepository;
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
    }
}
