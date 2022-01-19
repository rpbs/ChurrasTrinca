using Core.Entities;
using Core.Interface;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {

        private readonly ChurrasDbContext _dbContext;

        public BaseRepository(ChurrasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<T>> All()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> Create(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var record = await GetById(id);
            if (record != null)
            {
                _dbContext.Set<T>().Remove(record);
                var result = await _dbContext.SaveChangesAsync();
                return result > 0;
            } return false;
        }

        public async Task<T> GetById(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
    }
}
