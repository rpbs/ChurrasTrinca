using Core.DTO;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IChurrascoRepository : IBaseRepository<Churrasco>
    {
        Task<IReadOnlyList<Churrasco>> ChurrascosAgendados();
    }
}
