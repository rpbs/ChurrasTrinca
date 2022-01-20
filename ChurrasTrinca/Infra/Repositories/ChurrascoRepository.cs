using AutoMapper;
using Core.DTO;
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
    public class ChurrascoRepository : BaseRepository<Churrasco>, IChurrascoRepository
    {

        private readonly ChurrasDbContext _churrasDbContext;

        public ChurrascoRepository(ChurrasDbContext dbContext) : base(dbContext)
        {
            _churrasDbContext = dbContext;
        }

        public async Task<IReadOnlyList<Churrasco>> ChurrascosAgendados()
        {
            IReadOnlyList<Churrasco> churrascos = await _churrasDbContext.Churrascos.Where(x => x.Data >= DateTime.Now).ToListAsync();
            return churrascos;
        }
    }
}
