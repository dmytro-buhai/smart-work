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
    public abstract class GeneralEntityService<TEntity> : IEntityService<TEntity> 
        where TEntity : Entity
    {
        private readonly IEntityRepository<TEntity> _repository;
        private readonly ILogger<GeneralEntityService<TEntity>> _logger;

        public GeneralEntityService(IEntityRepository<TEntity> repository,
            ILogger<GeneralEntityService<TEntity>> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public Task<bool> AddAsync(TEntity entity)
        {
            try
            {
                _repository.AddAsync(entity);
                _repository.SaveChangesAsync();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(GetType().Name, " : ", "AddAsync -> ", ex.Message));
                return default;
            }
        }

        public Task<bool> AddAsync(IEnumerable<TEntity> entities)
        {
            try
            {
                _repository.AddAsync(entities);
                _repository.SaveChangesAsync();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(GetType().Name, " : ", "AddAsync -> ", ex.Message));
                return default;
            }
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            try
            {
                return _repository.AnyAsync(expression);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(GetType().Name, " : ", "AnyAsync -> ", ex.Message));
                return default;
            }
        }

        public Task<TEntity> FindAsync(int id)
        {
            try
            {
                return _repository.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(GetType().Name, " : ", "FindAsync -> ", ex.Message));
                return default;
            }
        }

        public Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                return _repository.FindAsync(expression);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(GetType().Name, " : ", "FindAsync -> ", ex.Message));
                return default;
            }
        }

        public Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                return _repository.GetAsync(expression);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(GetType().Name, " : ", "GetAsync -> ", ex.Message));
                return default;
            }
        }

        public Task<bool> RemoveAsync(TEntity entity)
        {
            try
            {
                _repository.RemoveAsync(entity);
                _repository.SaveChangesAsync();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(GetType().Name, " : ", "RemoveAsync -> ", ex.Message));
                return default;
            }
        }

        public Task<bool> RemoveAsync(IEnumerable<TEntity> entities)
        {
            try
            {
                _repository.RemoveAsync(entities);
                _repository.SaveChangesAsync();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(GetType().Name, " : ", "RemoveAsync -> ", ex.Message));
                return default;
            }
        }

        public Task<bool> UpdateAsync(TEntity entity)
        {
            try
            {
                _repository.UpdateAsync(entity);
                _repository.SaveChangesAsync();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(GetType().Name, " : ", "UpdateAsync -> ", ex.Message));
                return default;
            }
        }

        public Task<bool> UpdateAsync(IEnumerable<TEntity> entities)
        {
            try
            {
                _repository.UpdateAsync(entities);
                _repository.SaveChangesAsync();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(GetType().Name, " : ", "UpdateAsync -> ", ex.Message));
                return default;
            }
        }
    }
}
