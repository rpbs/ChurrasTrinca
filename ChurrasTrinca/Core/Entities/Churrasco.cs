using Core.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace Core.Entities
{
    public class Churrasco : BaseEntity
    {

        public Churrasco() : base()
        {
            Participantes = new HashSet<Participante>();
        }

        public string Descricao { get; set; }
        public string Observacoes { get; set; }
        public virtual ICollection<Participante> Participantes { get; set; }
    }
}
