using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Queries
{
    public class BaseIdQuery
    {
        public Guid Id { get; }

        public BaseIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
