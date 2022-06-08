using Microsoft.Extensions.Logging;
using SmartWork.Core.Abstractions;
using SmartWork.Core.Abstractions.EntityConvertors;
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
    public abstract class GeneraEntityOperations<TEntity, TAddDTO, TUpdateDTO> : 
        IGeneralEntityOperations<TEntity, TAddDTO, TUpdateDTO> 
        where TEntity : Entity
        where TAddDTO : IDTO
        where TUpdateDTO : IDTO
    {
        private readonly IEntityRepository<TEntity> _repository;
        private readonly IEntityConverter<TEntity, TAddDTO, TUpdateDTO> _entityConverter;
        private readonly ILogger<GeneraEntityOperations<TEntity, TAddDTO, TUpdateDTO>> _logger;

        public GeneraEntityOperations(IEntityRepository<TEntity> repository,
            IEntityConverter<TEntity, TAddDTO, TUpdateDTO> entityConverter,
            ILogger<GeneraEntityOperations<TEntity, TAddDTO, TUpdateDTO>> logger)
        {
            _repository = repository;
            _entityConverter = entityConverter;
            _logger = logger;
        }

        public virtual async Task<int> AddAsync(TAddDTO addEntityDTO)
        {
            try
            {
                var entity = _entityConverter.ToEntity(addEntityDTO);
                await _repository.AddAsync(entity);
                await _repository.SaveChangesAsync();
                return entity.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error during adding {typeof(TEntity).Name}: {ex.Message}");
                return default;
            }
        }

        public virtual async Task<bool> AddAsync(IEnumerable<TAddDTO> transferObjects)
        {
            try
            {
                var entities = _entityConverter.ToEntities(transferObjects);
                await _repository.AddAsync(entities);
                await _repository.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error during adding {typeof(TEntity).Name}: {ex.Message}");
                return false;
            }
        }

        public virtual Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            try
            {
                return _repository.AnyAsync(expression);
            }
            catch (Exception ex)
            {
                _logger.LogError($"error during finding any type of {typeof(TEntity).Name} in db: {ex.Message}");
                return default;
            }
        }

        public virtual Task<TEntity> FindAsync(int id)
        {
            try
            {
                return _repository.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"error during finding {typeof(TEntity).Name}: {ex.Message}");
                return default;
            }
        }

        public virtual Task<TEntity> FindWithIncludeAsync(int id, string includeName)
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
                _logger.LogError($"error during finding {typeof(TEntity).Name}: {ex.Message}");
                return default;
            }
        }

        public virtual Task<TEntity> FindWithIncludesAsync(int id, string[] includeNames)
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
                _logger.LogError($"error during finding {typeof(TEntity).Name}: {ex.Message}");
                return default;
            }
        }

        public virtual Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                return _repository.FindAsync(expression);
            }
            catch (Exception ex)
            {
                _logger.LogError($"error during finding {typeof(TEntity).Name}: {ex.Message}");
                return default;
            }
        }

        public virtual Task<List<TEntity>> GetAsync(PageInfo pageInfo)
        {
            try
            {
                return _repository.GetAsync(pageInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError($"error during getting '{typeof(TEntity).Name}' from db: {ex.Message}");
                return default;
            }
        }

        public virtual Task<List<TEntity>> GetAsyncWithInclude(PageInfo pageInfo, string includeName)
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

        public virtual Task<List<TEntity>> GetAsyncWithIncludes(PageInfo pageInfo, string[] includeNames)
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

        public virtual async Task<bool> RemoveAsync(int entityId)
        {
            try
            {
                var entity = await _repository.FindAsync(entityId);
                await _repository.RemoveAsync(entity);
                await _repository.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error during removing '{typeof(TEntity).Name}' from db: {ex.Message}");
                return default;
            }
        }

        public virtual async Task<bool> RemoveAsync(IEnumerable<TEntity> entities)
        {
            try
            {
                await _repository.RemoveAsync(entities);
                await _repository.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error during removing '{typeof(TEntity).Name}' from db: {ex.Message}");
                return default;
            }
        }

        public virtual async Task<bool> UpdateAsync(TUpdateDTO updateEntityDTO)
        {
            try
            {
                var entity = _entityConverter.ToEntity(updateEntityDTO);
                await _repository.UpdateAsync(entity);
                await _repository.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error during updating '{typeof(TEntity).Name}': {ex.Message}");
                return default;
            }
        }

        public virtual async Task<bool> UpdateAsync(IEnumerable<TUpdateDTO> transferObjects)
        {
            try
            {
                var entities = _entityConverter.ToEntities(transferObjects);
                await _repository.UpdateAsync(entities);
                await _repository.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error during updating '{typeof(TEntity).Name}': {ex.Message}");
                return default;
            }
        }

        private static void ValidateIncludeName(string includeName, out string errorMessage)
        {
            errorMessage = string.Empty;

            var propertyInfo = typeof(TEntity).GetProperties();

            if (!propertyInfo.Any(pif => pif.Name == includeName))
            {
                errorMessage = "wrong include name";
            }
        }

        private static void ValidateIncludeNames(string[] includeNames, out string errorMessage)
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
