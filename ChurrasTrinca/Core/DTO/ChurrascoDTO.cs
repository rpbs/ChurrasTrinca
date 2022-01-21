using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class ChurrascoDTO
    {
        public string Descricao { get; set; }
        public string Observacoes { get; set; }
        public DateTime Data { get; set; }
        public decimal ValorComBebida { get; set; }
        public decimal ValorSemBebida { get; set; }

    }
}
