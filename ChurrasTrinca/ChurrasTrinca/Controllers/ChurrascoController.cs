using Core.Commands;
using Core.DTO;
using Core.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ChurrasTrinca.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/churrasco")]
    public class ChurrascoController : Controller
    {
        private readonly IMediator _mediator;

        public ChurrascoController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Cria um novo churrasco
        /// </summary>
        /// <param name="churrascoDTO">Teste</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CriarChurrasco([FromBody] ChurrascoDTO churrascoDTO)
        {
            var query = new ChurrascoCommand(churrascoDTO);
            var response = await _mediator.Send(query);

            return Ok(response);
        }
        /// <summary>
        /// Obter um determinado churrasco
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetChurrasco(Guid id)
        {
            var query = new ChurrascoByIdQuery(id);
            var response = await _mediator.Send(query);

            return Ok(response);
        }
        /// <summary>
        /// Retorna todos os churrascos agendados da data atual em diante.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetChurrascos()
        {
            var query = new ChurrascoQuery();
            var response = await _mediator.Send(query);

            return Ok(response);

        }
        /// <summary>
        /// Lista todos os participantes do churrasco.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/participantes")]
        public async Task<IActionResult> GetParticipantesChurrasco(Guid id)
        {
            var query = new ChurrascoParticipantesByIdQuery(id);
            var response = await _mediator.Send(query);

            return Ok(response);
        }
    }
}
