using Microsoft.AspNetCore.Mvc;
using SmartWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartWork.Core.Abstractions.Services
{
    public interface IEntityService<TEntity> where TEntity : Entity
    {
        Task<TEntity> FindAsync(int id);
        Task<TEntity> FindAsync(Func<TEntity, bool> expression);
        Task<IEnumerable<TEntity>> GetAsync(Func<TEntity, bool> expression);
        Task<IActionResult> AddAsync(TEntity entity);
        Task<IActionResult> AddAsync(IEnumerable<TEntity> entities);
        Task<IActionResult> UpdateAsync(TEntity entity);
        Task<IActionResult> UpdateAsync(IEnumerable<TEntity> entities);
        Task<IActionResult> RemoveAsync(int id);
        Task<IActionResult> RemoveAsync(IEnumerable<int> identifiers);
    }
}
