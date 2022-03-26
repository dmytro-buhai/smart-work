using SmartWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartWork.Core.Abstractions.Repositories
{
    public interface IEntityRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> FindAsync(int id);
        Task<TEntity> FindAsync(Func<TEntity, bool> expression);
        Task<IEnumerable<TEntity>> GetAsync(Func<TEntity, bool> expression);
        Task AddAsync(TEntity entity);
        Task AddAsync(IEnumerable<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task UpdateAsync(IEnumerable<TEntity> entities);
        Task RemoveAsync(int id);
        Task RemoveAsync(IEnumerable<int> identifiers);
    }
}
