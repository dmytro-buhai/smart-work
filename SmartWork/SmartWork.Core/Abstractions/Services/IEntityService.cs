using Microsoft.AspNetCore.Mvc;
using SmartWork.Core.Entities;
using SmartWork.Core.Models;
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
        Task<TEntity> FindWithIncludeAsync(int id, string includeName);
        Task<IActionResult> FindAsync(Expression<Func<TEntity, bool>> expression);
        Task<IActionResult> AnyAsync(Expression<Func<TEntity, bool>> expression = null);
        Task<IActionResult> GetAsync(PageInfo pageInfo);
        Task<IActionResult> GetAsyncWithInclude(PageInfo pageInfo, string includeName);
        Task<IActionResult> RemoveAsync(TEntity company);
        Task<IActionResult> RemoveAsync(IEnumerable<TEntity> companies);
        Task<IActionResult> UpdateAsync(TUpdateDTO model);
        Task<IActionResult> UpdateAsync(IEnumerable<TUpdateDTO> models);
    }
}
