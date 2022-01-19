using Core.DTO;
using Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Commands
{
    public class ChurrascoCommand : IRequest<ChurrascoResponse>
    {
        public ChurrascoCommand(ChurrascoDTO churrascoDTO)
        {
            ChurrascoDTO = churrascoDTO;
        }

        public ChurrascoDTO ChurrascoDTO { get; }
    }
}
