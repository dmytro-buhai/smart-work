using Microsoft.Extensions.Logging;
using SmartWork.Core.Abstractions.Repositories;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.Entities;
using SmartWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartWork.BLL.Services.General
{
    public abstract class GeneralEntityService<TEntity> : IGeneralEntityService<TEntity> 
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

        public virtual Task<bool> AddAsync(TEntity entity)
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

        public Task<TEntity> FindWithIncludeAsync(int id, string includeName)
        {
            ValidateIncludeName(includeName, out string errorMessage);

            if (errorMessage != string.Empty)
            {
                _logger.LogError(errorMessage);
                return default;
            }

            try
            {
                return _repository.FindWithIncludeAsync(id, includeName);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(GetType().Name, " : ", "FindAsync -> ", ex.Message));
                return default;
            }
        }

        public Task<TEntity> FindWithIncludesAsync(int id, string[] includeNames)
        {
            ValidateIncludeNames(includeNames, out string errorMessage);

            if(errorMessage != string.Empty)
            {
                _logger.LogError(errorMessage);
                return default;
            }

            try
            {
                return _repository.FindWithIncludesAsync(id, includeNames);
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

        public Task<List<TEntity>> GetAsync(PageInfo pageInfo)
        {
            try
            {
                return _repository.GetAsync(pageInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(GetType().Name, " : ", "GetAsync -> ", ex.Message));
                return default;
            }
        }

        public Task<List<TEntity>> GetAsyncWithInclude(PageInfo pageInfo, string includeName)
        {
            ValidateIncludeName(includeName, out string errorMessage);

            if (errorMessage != string.Empty)
            {
                _logger.LogError(errorMessage);
                return default;
            }

            try
            {
                return _repository.GetWithIncludeAsync(pageInfo, includeName);
            }
            catch (Exception ex)
            {
                _logger.LogError($"error during getting '{typeof(TEntity).Name}' from db: {ex.Message}");
                return default;
            }
        }

        public Task<List<TEntity>> GetAsyncWithIncludes(PageInfo pageInfo, string[] includeNames)
        {
            ValidateIncludeNames(includeNames, out string errorMessage);

            if (errorMessage != string.Empty)
            {
                _logger.LogError(errorMessage);
                return default;
            }

            try
            {
                return _repository.GetWithIncludesAsync(pageInfo, includeNames);
            }
            catch (Exception ex)
            {
                _logger.LogError($"error during getting '{typeof(TEntity).Name}' from db: {ex.Message}");
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
                _logger.LogError($"error during removing '{typeof(TEntity).Name}' from db: {ex.Message}");
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
                _logger.LogError($"error during removing '{typeof(TEntity).Name}' from db: {ex.Message}");
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

        private void ValidateIncludeName(string includeName, out string errorMessage)
        {
            errorMessage = string.Empty;

            var propertyInfo = typeof(TEntity).GetProperties();

            if (!propertyInfo.Any(pif => pif.Name == includeName))
            {
                errorMessage = "wrong include name";
            }
        }

        private void ValidateIncludeNames(string[] includeNames, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (includeNames.Length > 3)
            {
                errorMessage = "too many includes (max length is 3)";
            }

            var propertyInfo = typeof(TEntity).GetProperties();

            if (!propertyInfo.Any(pif => pif.Name == includeNames[0]) ||
                !propertyInfo.Any(pif => pif.Name == includeNames[1]))
            {
                errorMessage = "wrong include name";
            }
        }
    }
}
