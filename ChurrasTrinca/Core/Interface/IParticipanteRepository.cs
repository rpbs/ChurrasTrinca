using Core.DTO;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IParticipanteRepository : IBaseRepository<Participante>
    {
        Task<IReadOnlyCollection<Participante>> ObterParticipantes(Guid churrascoId);
        Task<Participante> ObterPorChurrascoIdAndParticipanteId(Guid churrascoId, Guid participanteId);

    }
}
