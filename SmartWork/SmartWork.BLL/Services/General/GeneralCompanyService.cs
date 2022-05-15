using Microsoft.Extensions.Logging;
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
        private readonly ILogger<GeneralCompanyService> _logger;

        public GeneralCompanyService(IEntityRepository<Company> repository, 
            ILogger<GeneralCompanyService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public Task<bool> AddAsync(Company entity)
        {
            try
            {
                _repository.AddAsync(entity);
                _repository.SaveChangesAsync();
                return Task.FromResult<bool>(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat("AddAsync -> ", ex.Message));
                return Task.FromResult<bool>(false);
            }
        }

        public Task<bool> AddAsync(IEnumerable<Company> entities)
        {
            try
            {
                 _repository.AddAsync(entities);
                 _repository.SaveChangesAsync();
                return Task.FromResult<bool>(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat("AddAsync -> ", ex.Message));
                return Task.FromResult<bool>(false);
            }
        }

        public Task<bool> AnyAsync(Expression<Func<Company, bool>> expression = null)
        {
            try
            {
                return _repository.AnyAsync(expression);
            }
            catch(Exception ex)
            {
                _logger.LogError(string.Concat("AnyAsync -> ", ex.Message));
                return Task.FromResult<bool>(false);
            }
        }   

        public Task<Company> FindAsync(int id)
        {
            try
            {
                return _repository.FindAsync(id);
            }
            catch(Exception ex)
            {
                _logger.LogError(string.Concat("FindAsync -> ", ex.Message));
                return Task.FromResult<Company>(null);
            }
        }

        public Task<Company> FindAsync(Expression<Func<Company, bool>> expression)
        {
            try
            {
                return _repository.FindAsync(expression);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat("FindAsync -> ", ex.Message));
                return Task.FromResult<Company>(null);
            }
        }

        public Task<IEnumerable<Company>> GetAsync(Expression<Func<Company, bool>> expression)
        {
            try
            {
                return _repository.GetAsync(expression);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat("GetAsync -> ", ex.Message));
                return Task.FromResult<IEnumerable<Company>>(null);
            }
        }          

        public Task<bool> RemoveAsync(Company entity)
        {
            try
            {
                _repository.RemoveAsync(entity);
                _repository.SaveChangesAsync();
                return Task.FromResult<bool>(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat("RemoveAsync -> ", ex.Message));
                return Task.FromResult<bool>(false);
            }
        }

        public Task<bool> RemoveAsync(IEnumerable<Company> entities)
        {
            try
            {
                _repository.RemoveAsync(entities);
                _repository.SaveChangesAsync();
                return Task.FromResult<bool>(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat("RemoveAsync -> ", ex.Message));
                return Task.FromResult<bool>(false);
            }
        }

        public Task<bool> UpdateAsync(Company entity)
        {
            try
            {
                _repository.UpdateAsync(entity);
                _repository.SaveChangesAsync();
                return Task.FromResult<bool>(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat("UpdateAsync -> ", ex.Message));
                return Task.FromResult<bool>(false);
            }
        }

        public Task<bool> UpdateAsync(IEnumerable<Company> entities)
        {
            try
            {
                _repository.UpdateAsync(entities);
                _repository.SaveChangesAsync();
                return Task.FromResult<bool>(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat("UpdateAsync -> ", ex.Message));
                return Task.FromResult<bool>(false);
            }
        }
    }
}
