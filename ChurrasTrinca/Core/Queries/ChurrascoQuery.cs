using Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Queries
{
    public class ChurrascoQuery : IRequest<IReadOnlyList<ChurrascoResponse>>
    {
        
    }
}
