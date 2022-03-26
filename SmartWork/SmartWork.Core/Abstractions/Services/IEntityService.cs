using Microsoft.AspNetCore.Mvc;
using SmartWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartWork.Core.Abstractions.Services
{
    public interface IEntityService<TEntity> where TEntity : Entity
    {
        Task<TEntity> FindAsync(int id);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression);
        Task<IActionResult> AddAsync(TEntity entity);
        Task<IActionResult> AddAsync(IEnumerable<TEntity> entities);
        Task<IActionResult> UpdateAsync(TEntity entity);
        Task<IActionResult> UpdateAsync(IEnumerable<TEntity> entities);
        Task<IActionResult> RemoveAsync(TEntity entity);
        Task<IActionResult> RemoveAsync(IEnumerable<TEntity> entities);
    }
}
