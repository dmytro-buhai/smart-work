using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartWork.Core.Abstractions.Repositories
{
    public interface IUserRepository<TEntity> where TEntity : IdentityUser<Guid> 
    {
        Task<TEntity> FindAsync(Guid id);
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
