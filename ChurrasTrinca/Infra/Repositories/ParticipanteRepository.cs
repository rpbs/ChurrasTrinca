using Core.Entities;
using Core.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class ParticipanteRepository : BaseRepository<Participante>, IParticipanteRepository
    {
        private readonly ChurrasDbContext _churrasDbContext;

        public ParticipanteRepository(ChurrasDbContext churrasDbContext) : base(churrasDbContext)
        {
            _churrasDbContext = churrasDbContext;
        }

        public async Task<IReadOnlyCollection<Participante>> ObterParticipantes(Guid churrascoId)
        {
            var lista = await _churrasDbContext
                .Participantes
                .Where(x => x.ChurrascoId == churrascoId)
                .ToListAsync();

            return lista;
        }

        public async Task<Participante> ObterPorChurrascoIdAndParticipanteId(Guid churrascoId, Guid participanteId)
        {
            var lista = await _churrasDbContext
                .Participantes
                .FirstOrDefaultAsync(x => x.ChurrascoId == churrascoId && x.Id == participanteId);

            return lista;
        }
    }
}
