using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class ChurrascoResponse
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public string Observacoes { get; set; }
        public int QuantidadePessoas { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal? ValorComBebida { get; set; }
        public decimal? ValorSemBebida { get; set; }

    }
}
