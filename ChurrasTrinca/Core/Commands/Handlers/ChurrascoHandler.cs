using AutoMapper;
using Core.Entities;
using Core.Interface;
using Core.Model;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Commands.Handlers
{
    public class ChurrascoHandler : 
        IRequestHandler<ChurrascoCommand, ChurrascoResponse>
    {

        private readonly IMapper _mapper;
        private readonly IChurrascoRepository _churrascoRepository;

        public ChurrascoHandler (IMapper mapper, IChurrascoRepository churrascoRepository)
        {
            _mapper = mapper;
            _churrascoRepository = churrascoRepository;
        }

        public async Task<ChurrascoResponse> Handle(ChurrascoCommand request, CancellationToken cancellationToken)
        {
            var churrascoDTO = request.ChurrascoDTO;

            if (churrascoDTO.ValorComBebida <= 0 || churrascoDTO.ValorSemBebida <= 0)
            {                
                throw new ArgumentException("Valor de contribuição inválido ");
            }
            if (churrascoDTO.Data < DateTime.Now)
            {
                throw new ArgumentException("Data do churrasco tem que ser no futuro!");
            }
            var novoChurrasco = _mapper.Map<Churrasco>(request.ChurrascoDTO);
            novoChurrasco = await _churrascoRepository.Create(novoChurrasco);
            var resposta = _mapper.Map<ChurrascoResponse>(novoChurrasco);

            return resposta;
        }
    }
}
