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
    [Route("api/[controller]")]
    public class ChurrascoController : Controller
    {
        private readonly IMediator _mediator;

        public ChurrascoController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetChurrasco(Guid id)
        {
            var query = new ChurrascoByIdQuery(id);
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CriarChurrasco([FromBody] ChurrascoDTO churrascoDTO)
        {
            var query = new ChurrascoCommand(churrascoDTO);
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetChurrascos()
        {
            var query = new ChurrascoQuery();
            var response = await _mediator.Send(query);

            return Ok(response);

        }

        [HttpGet("{id}/participantes")]
        public async Task<IActionResult> GetParticipantesChurrasco(Guid id)
        {
            var query = new ChurrascoParticipantesByIdQuery(id);
            var response = await _mediator.Send(query);

            return Ok(response);
        }
    }
}
