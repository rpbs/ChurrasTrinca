using System;
using System.Collections.Generic;

#nullable disable

namespace Core.Entities
{
    public class Participante : BaseEntity
    {
        public Participante() : base()
        {
        }

        public Participante(Guid churrascoId, string nome, decimal valorContribuicao)
        {
            ChurrascoId = churrascoId;
            Nome = nome;
            ValorContribuicao = valorContribuicao;
        }

        public Guid ChurrascoId { get; set; }
        public string Nome { get; set; }
        public decimal ValorContribuicao { get; set; }
        public virtual Churrasco Churrasco { get; set; }
    }
}
