using Core.Commands;
using Core.DTO;
using Core.Model;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurrasTrinca.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/participante")]
    public class ParticipanteController : Controller
    {
        private readonly IMediator _mediator;

        public ParticipanteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarParticipante([FromBody] ParticipanteDTO participanteDTO)
        {
            var query = new AdicionarParticipanteCommad(participanteDTO);
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoverParticipante([FromBody] RemoverParticipanteDTO removerParticipanteDTO)
        {
            var query = new RemoverParticipanteCommand(removerParticipanteDTO);
            var response = await _mediator.Send(query);

            return Ok(response);
        }
    }
}
