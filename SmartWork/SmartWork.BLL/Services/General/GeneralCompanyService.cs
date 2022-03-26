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
            return new OkObjectResult("added");
        }

        public async Task<IActionResult> AddAsync(IEnumerable<Company> entities)
        {
            await _repository.AddAsync(entities);
            return new OkObjectResult("added");
        }

        public async Task<Company> FindAsync(int id) =>
            await _repository.FindAsync(id);

        public async Task<Company> FindAsync(Expression<Func<Company, bool>> expression) =>
            await _repository.FindAsync(expression);

        public async Task<IEnumerable<Company>> GetAsync(Expression<Func<Company, bool>> expression) =>
            await _repository.GetAsync(expression);

        public async Task<IActionResult> RemoveAsync(Company entity)
        {
            await _repository.RemoveAsync(entity);
            return new OkObjectResult("removed");
        }

        public async Task<IActionResult> RemoveAsync(IEnumerable<Company> entities)
        {
            await _repository.RemoveAsync(entities);
            return new OkObjectResult("removed");
        }

        public async Task<IActionResult> UpdateAsync(Company entity)
        {
            await _repository.UpdateAsync(entity);
            return new OkObjectResult("updated");
        }

        public async Task<IActionResult> UpdateAsync(IEnumerable<Company> entities)
        {
            await _repository.UpdateAsync(entities);
            return new OkObjectResult("updated");
        }
    }
}
