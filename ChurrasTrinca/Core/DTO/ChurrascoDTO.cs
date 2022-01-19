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
        public string Observacao { get; set; }
        public DateTime Data { get; set; }
        public decimal ValorComBebiba { get; set; }
        public decimal ValorSemBebiba { get; set; }

    }
}
