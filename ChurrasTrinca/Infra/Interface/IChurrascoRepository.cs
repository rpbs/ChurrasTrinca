using Core.DTO;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interface
{
    public interface IChurrascoRepository : IBaseRepository<Churrasco>
    {
        Task<Churrasco> CriarChurrasco(ChurrascoDTO churrascoDTO);
        Task<List<Participante>> VerParticipantes(Guid churrascoId);
        Task<Participante> AdicionarParticipante(ParticipanteDTO participanteDTO);
    }
}
