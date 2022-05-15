using Microsoft.Extensions.Logging;
using SmartWork.Core.Abstractions.Repositories;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmartWork.BLL.Services.General
{
    public class GeneralOfficeService : IEntityService<Office>
    {
        private readonly IEntityRepository<Office> _repository;
        private readonly ILogger<GeneralOfficeService> _logger;

        public GeneralOfficeService(IEntityRepository<Office> repository,
            ILogger<GeneralOfficeService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public Task<bool> AddAsync(Office entity)
        {
            try
            {
                _repository.AddAsync(entity);
                _repository.SaveChangesAsync();
                return Task.FromResult<bool>(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(GetType().Name, " : ", "AddAsync -> ", ex.Message));
                return Task.FromResult<bool>(false);
            }
        }

        public Task<bool> AddAsync(IEnumerable<Office> entities)
        {
            try
            {
                _repository.AddAsync(entities);
                _repository.SaveChangesAsync();
                return Task.FromResult<bool>(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(GetType().Name, " : ", "AddAsync -> ", ex.Message));
                return Task.FromResult<bool>(false);
            }
        }

        public Task<bool> AnyAsync(Expression<Func<Office, bool>> expression = null)
        {
            try
            {
                return _repository.AnyAsync(expression);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(GetType().Name, " : ", "AnyAsync -> ", ex.Message));
                return Task.FromResult<bool>(false);
            }
        }

        public Task<Office> FindAsync(int id)
        {
            try
            {
                return _repository.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(GetType().Name, " : ", "FindAsync -> ", ex.Message));
                return Task.FromResult<Office>(null);
            }
        }

        public Task<Office> FindAsync(Expression<Func<Office, bool>> expression)
        {
            try
            {
                return _repository.FindAsync(expression);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(GetType().Name, " : ", "FindAsync -> ", ex.Message));
                return Task.FromResult<Office>(null);
            }
        }

        public Task<IEnumerable<Office>> GetAsync(Expression<Func<Office, bool>> expression)
        {
            try
            {
                return _repository.GetAsync(expression);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(GetType().Name, " : ", "GetAsync -> ", ex.Message));
                return Task.FromResult<IEnumerable<Office>>(null);
            }
        }

        public Task<bool> RemoveAsync(Office entity)
        {
            try
            {
                _repository.RemoveAsync(entity);
                _repository.SaveChangesAsync();
                return Task.FromResult<bool>(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(GetType().Name, " : ", "RemoveAsync -> ", ex.Message));
                return Task.FromResult<bool>(false);
            }
        }

        public Task<bool> RemoveAsync(IEnumerable<Office> entities)
        {
            try
            {
                _repository.RemoveAsync(entities);
                _repository.SaveChangesAsync();
                return Task.FromResult<bool>(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(GetType().Name, " : ", "RemoveAsync -> ", ex.Message));
                return Task.FromResult<bool>(false);
            }
        }

        public Task<bool> UpdateAsync(Office entity)
        {
            try
            {
                _repository.UpdateAsync(entity);
                _repository.SaveChangesAsync();
                return Task.FromResult<bool>(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(GetType().Name, " : ", "UpdateAsync -> ", ex.Message));
                return Task.FromResult<bool>(false);
            }
        }

        public Task<bool> UpdateAsync(IEnumerable<Office> entities)
        {
            try
            {
                _repository.UpdateAsync(entities);
                _repository.SaveChangesAsync();
                return Task.FromResult<bool>(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(GetType().Name, " : ", "UpdateAsync -> ", ex.Message));
                return Task.FromResult<bool>(false);
            }
        }
    }
}
