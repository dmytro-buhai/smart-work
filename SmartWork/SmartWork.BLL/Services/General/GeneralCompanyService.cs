using Microsoft.AspNetCore.Mvc;
using SmartWork.Core.Abstractions.Repositories;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartWork.BLL.Services.General
{
    public class GeneralCompanyService : IEntityService<Company>
    {
        private readonly IEntityRepository<Company> _repository;

        public GeneralCompanyService(IEntityRepository<Company> repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> AddAsync(Company entity)
        {
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return new OkObjectResult("added");
        }

        public async Task<IActionResult> AddAsync(IEnumerable<Company> entities)
        {
            await _repository.AddAsync(entities);
            await _repository.SaveChangesAsync();
            return new OkObjectResult("added");
        }

        public Task<bool> AnyAsync(Expression<Func<Company, bool>> expression = null) => 
            _repository.AnyAsync(expression);

        public Task<Company> FindAsync(int id) =>
             _repository.FindAsync(id);

        public Task<Company> FindAsync(Expression<Func<Company, bool>> expression) =>
             _repository.FindAsync(expression);

        public Task<IEnumerable<Company>> GetAsync(Expression<Func<Company, bool>> expression) =>
             _repository.GetAsync(expression);

        public async Task<IActionResult> RemoveAsync(Company entity)
        {
            await _repository.RemoveAsync(entity);
            await _repository.SaveChangesAsync();
            return new OkObjectResult("removed");
        }

        public async Task<IActionResult> RemoveAsync(IEnumerable<Company> entities)
        {
            await _repository.RemoveAsync(entities);
            await _repository.SaveChangesAsync();
            return new OkObjectResult("removed");
        }

        public async Task<IActionResult> UpdateAsync(Company entity)
        {
            await _repository.UpdateAsync(entity);
            await _repository.SaveChangesAsync();
            return new OkObjectResult("updated");
        }

        public async Task<IActionResult> UpdateAsync(IEnumerable<Company> entities)
        {
            await _repository.UpdateAsync(entities);
            await _repository.SaveChangesAsync();
            return new OkObjectResult("updated");
        }
    }
}
