using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interface
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> GetById(Guid id);
        Task<T> Create(T entity);
        Task<bool> Delete(Guid id);

    }
}
