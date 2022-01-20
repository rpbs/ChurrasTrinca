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
        private readonly IMapper _mapper;

        public ParticipanteHandler(IParticipanteRepository pariticipanteRepository, IMapper mapper)
        {
            _pariticipanteRepository = pariticipanteRepository;
            _mapper = mapper;
        }

        public async Task<ParticipanteResponse> Handle(AdicionarParticipanteCommad request, CancellationToken cancellationToken)
        {
            var participante = _mapper.Map<Participante>(request.ParticipanteDTO);
            participante = await _pariticipanteRepository.Create(participante);
            var response = _mapper.Map<ParticipanteResponse>(participante);
            return response;
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
