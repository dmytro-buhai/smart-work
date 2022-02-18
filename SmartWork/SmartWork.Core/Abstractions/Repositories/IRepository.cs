using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartWork.Core.Abstractions.Repositories
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> FindAsync(int id);
        Task<TEntity> FindAsync(Func<TEntity, bool> expression);
        Task<IEnumerable<TEntity>> GetAsync(Func<TEntity, bool> expression);
        Task AddAsync(TEntity entity);
        Task AddAsync(IEnumerable<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task UpdateAsync(IEnumerable<TEntity> entities);
        Task RemoveAsync(TEntity entity);
        Task RemoveAsync(IEnumerable<TEntity> entities);
    }
}
