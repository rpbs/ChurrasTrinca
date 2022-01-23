using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class ParticipanteResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorContribuicao { get; set; }
    }
}
