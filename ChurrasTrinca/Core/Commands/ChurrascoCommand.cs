using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Commands
{
    public class ChurrascoCommand
    {
        public ChurrascoCommand(ChurrascoDTO churrascoDTO)
        {
            ChurrascoDTO = churrascoDTO;
        }

        public ChurrascoDTO ChurrascoDTO { get; }
    }
}
