using SmartWork.Core.Entities;
using SmartWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartWork.Core.Abstractions.Services
{
    public interface IGeneralEntityOperations<TEntity, TAddDTO, TUpdateDTO>
        where TEntity : Entity
        where TAddDTO : IDTO
        where TUpdateDTO : IDTO
    {
        Task<int> AddAsync(TAddDTO addEntityDTO);
        Task<bool> AddAsync(IEnumerable<TAddDTO> transferObjects);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression = null);
        Task<TEntity> FindAsync(int id);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> FindWithIncludeAsync(int id, string includeName);
        Task<TEntity> FindWithIncludesAsync(int id, string[] includeNames);
        Task<List<TEntity>> GetAsync(PageInfo pageInfo);
        Task<List<TEntity>> GetAsyncWithInclude(PageInfo pageInfo, string includeName);
        Task<List<TEntity>> GetAsyncWithIncludes(PageInfo pageInfo, string[] includeNames);
        Task<bool> RemoveAsync(int entityId);
        Task<bool> RemoveAsync(IEnumerable<TEntity> entities);
        Task<bool> UpdateAsync(TUpdateDTO updateEntityDTO);
        Task<bool> UpdateAsync(IEnumerable<TUpdateDTO> transferObjects);
    }
}
