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

        public ChurrascoRepository(ChurrasDbContext dbContext) : base(dbContext)
        {
        }
    }
}
