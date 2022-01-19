using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Queries
{
    public class ChurrascoParticipantesByIdQuery
    {
        public ChurrascoParticipantesByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
