using SmartWork.Core.Entities;
using SmartWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartWork.Core.Abstractions.Repositories
{
    public interface IEntityRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> FindAsync(int id);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> FindWithIncludeAsync(int id, string includeName);
        Task<TEntity> FindWithThreeIncludesAsync(int id, string[] includeNames);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression = null);
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression = null);
        Task<List<TEntity>> GetAsync(PageInfo pageInfo, Expression<Func<TEntity, bool>> expression = null);
        Task<List<TEntity>> GetWithIncludeAsync(PageInfo pageInfo, string includeName);
        Task<List<TEntity>> GetWithTwoIncludesAsync(PageInfo pageInfo, string[] includeNames);
        Task<List<TEntity>> GetWithThreeIncludesAsync(PageInfo pageInfo, string[] includeNames);
        Task<TEntity> AddAsync(TEntity entity);
        Task AddAsync(IEnumerable<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task UpdateAsync(IEnumerable<TEntity> entities);
        Task RemoveAsync(TEntity entities);
        Task RemoveAsync(IEnumerable<TEntity> entities);
        Task SaveChangesAsync();
        Task<TEntity> FindWithTwoIncludesAsync(int id, string[] includeNames);
        Task<List<TEntity>> GetPageListAsync(int skip, int take);
        Task<List<TEntity>> GetPageListWithTwoIncludesAsync(int skip, int take, string[] includeNames);
    }
}
