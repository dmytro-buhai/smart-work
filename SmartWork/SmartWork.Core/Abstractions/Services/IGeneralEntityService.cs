using SmartWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartWork.Core.Abstractions.Services
{
    public interface IGeneralEntityService<TEntity> where TEntity : Entity
    {
        Task<TEntity> FindAsync(int id);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression = null);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression);
        Task<bool> AddAsync(TEntity entity);
        Task<bool> AddAsync(IEnumerable<TEntity> entities);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> UpdateAsync(IEnumerable<TEntity> entities);
        Task<bool> RemoveAsync(TEntity entity);
        Task<bool> RemoveAsync(IEnumerable<TEntity> entities);
    }
}
