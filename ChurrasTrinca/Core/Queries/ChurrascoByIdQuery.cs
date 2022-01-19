using Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Queries
{
    public class ChurrascoByIdQuery : IRequest<ChurrascoResponse>
    {
        public ChurrascoByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
