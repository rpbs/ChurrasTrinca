﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class ParticipanteDTO
    {
        public string Nome { get; set; }
        public decimal Contribuicao { get; set; }
        public Guid ChurrascoId { get; set; }

    }
}
