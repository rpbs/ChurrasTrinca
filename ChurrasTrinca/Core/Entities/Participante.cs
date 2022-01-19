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

        public Participante(Guid churrascoId, string nome, decimal? valorComBebida, decimal? valorSemBebida) 
        {
            ChurrascoId = churrascoId;
            Nome = nome;
            ValorComBebida = valorComBebida;
            ValorSemBebida = valorSemBebida;
        }

        public Guid ChurrascoId { get; set; }
        public string Nome { get; set; }
        public decimal? ValorComBebida { get; set; }
        public decimal? ValorSemBebida { get; set; }
        public virtual Churrasco Churrasco { get; set; }
    }
}
