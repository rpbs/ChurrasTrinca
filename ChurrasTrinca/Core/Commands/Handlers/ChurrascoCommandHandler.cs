using AutoMapper;
using Core.Entities;
using Core.Interface;
using Core.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Commands.Handlers
{
    public class ChurrascoCommandHandler : 
        IRequestHandler<ChurrascoCommand, ChurrascoResponse>
    {

        private readonly IMapper _mapper;
        private readonly IChurrascoRepository _churrascoRepository;

        public ChurrascoCommandHandler(IMapper mapper, IChurrascoRepository churrascoRepository)
        {
            _mapper = mapper;
            _churrascoRepository = churrascoRepository;
        }

        public async Task<ChurrascoResponse> Handle(ChurrascoCommand request, CancellationToken cancellationToken)
        {
            var novoChurrasco = _mapper.Map<Churrasco>(request.ChurrascoDTO);
            novoChurrasco = await _churrascoRepository.Create(novoChurrasco);
            var resposta = _mapper.Map<ChurrascoResponse>(novoChurrasco);

            return resposta;
        }
    }
}
