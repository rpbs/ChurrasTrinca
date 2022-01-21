using AutoMapper;
using Core.Entities;
using Core.Interface;
using Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Commands.Handlers
{
    public class ParticipanteHandler :
        IRequestHandler<AdicionarParticipanteCommad, ParticipanteResponse>,
        IRequestHandler<RemoverParticipanteCommand, object>
    {

        private readonly IParticipanteRepository _pariticipanteRepository;
        private readonly IChurrascoRepository _churrascoRepository;
        private readonly IMapper _mapper;

        public ParticipanteHandler(IParticipanteRepository pariticipanteRepository, IChurrascoRepository churrascoRepository, IMapper mapper)
        {
            _pariticipanteRepository = pariticipanteRepository;
            _churrascoRepository = churrascoRepository;
            _mapper = mapper;
        }

        public async Task<ParticipanteResponse> Handle(AdicionarParticipanteCommad request, CancellationToken cancellationToken)
        {
            var churras = await _churrascoRepository.GetById(request.ParticipanteDTO.ChurrascoId);
            var dto = request.ParticipanteDTO;

            if (dto.ValorContribuicao > 0 && 
               (dto.ValorContribuicao >= churras?.ValorComBebida || dto.ValorContribuicao >= churras?.ValorSemBebida))
            {
                var participante = _mapper.Map<Participante>(request.ParticipanteDTO);
                participante = await _pariticipanteRepository.Create(participante);
                var response = _mapper.Map<ParticipanteResponse>(participante);
                return response;
            }
            else throw new ArgumentException("Valor de contribuição não atende as demandas do churrasco!");
        }

        public async Task<object> Handle(RemoverParticipanteCommand request, CancellationToken cancellationToken)
        {
            var dto = request.RemoverParticipanteDTO;
            var participante = await _pariticipanteRepository.ObterPorChurrascoIdAndParticipanteId(dto.ChurrascoId, dto.ParticipanteId);
            if (participante != null)
                await _pariticipanteRepository.Delete(participante.Id);
            return new object();
        }
    }
}
