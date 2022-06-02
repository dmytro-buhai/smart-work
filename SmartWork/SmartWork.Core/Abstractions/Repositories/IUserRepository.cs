using Microsoft.AspNetCore.Identity;
using SmartWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartWork.Core.Abstractions.Repositories
{
    public interface IUserRepository<TEntity> where TEntity : IdentityUser 
    {
        Task<TEntity> FindAsync(string id);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> expression);
        Task<List<TEntity>> GetAsync(PageInfo pageInfo, Expression<Func<TEntity, bool>> expression = null);
        Task AddAsync(TEntity entity);
        Task AddAsync(IEnumerable<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task UpdateAsync(IEnumerable<TEntity> entities);
        Task RemoveAsync(TEntity entity);
        Task RemoveAsync(IEnumerable<TEntity> entities);
    }
}
