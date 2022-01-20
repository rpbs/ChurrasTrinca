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
    public class ParticipanteController : BaseController
    {
        private readonly IMediator _mediator;

        public ParticipanteController(IMediator mediator)
        {
            _mediator = mediator;
        }


    }
}
