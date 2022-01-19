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
    public class ChurrascoCommandHandler : 
        IRequestHandler<ChurrascoCommand, ChurrascoResponse>
    {
        public Task<ChurrascoResponse> Handle(ChurrascoCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
