using Microsoft.AspNetCore.Mvc;
using SmartWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartWork.Core.Abstractions.Services
{
    public interface IEntityService<TEntity, TAddDTO, TUpdateDTO>
        where TEntity : Entity
        where TAddDTO : IDTO
        where TUpdateDTO : IDTO
    {
        Task<IActionResult> AddAsync(TAddDTO model);
        Task<IActionResult> AddAsync(IEnumerable<TAddDTO> models);
        Task<IActionResult> FindAsync(int id);
        Task<IActionResult> FindAsync(Expression<Func<TEntity, bool>> expression);
        Task<IActionResult> AnyAsync(Expression<Func<TEntity, bool>> expression = null);
        Task<IActionResult> GetAsync(Expression<Func<TEntity, bool>> expression);
        Task<IActionResult> RemoveAsync(TEntity company);
        Task<IActionResult> RemoveAsync(IEnumerable<TEntity> companies);
        Task<IActionResult> UpdateAsync(TUpdateDTO model);
        Task<IActionResult> UpdateAsync(IEnumerable<TUpdateDTO> models);
    }
}
