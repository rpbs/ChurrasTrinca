using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTime Data { get; set; }

        protected BaseEntity() 
        {
            Id = Guid.NewGuid();
            Data = DateTime.Now;
        }
    }
}
