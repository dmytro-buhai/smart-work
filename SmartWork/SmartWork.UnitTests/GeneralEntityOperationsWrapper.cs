using Microsoft.Extensions.Logging;
using Moq;
using SmartWork.BLL.Services.General;
using SmartWork.Core.Abstractions;
using SmartWork.Core.Abstractions.EntityConvertors;
using SmartWork.Core.Abstractions.Repositories;
using SmartWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartWork.UnitTests
{
    public class GeneralEntityOperationsWrapper<TEntity, TAddDTO, TUpdateDTO>
        : GeneraEntityOperations<TEntity, TAddDTO, TUpdateDTO>
        where TEntity : Entity
        where TAddDTO : IDTO
        where TUpdateDTO : IDTO
    {
        private readonly IEntityRepository<TEntity> _repository;
        private readonly IEntityConverter<TEntity, TAddDTO, TUpdateDTO> _entityConverter;
        private readonly ILogger<GeneralEntityOperationsWrapper<TEntity, TAddDTO, TUpdateDTO>> _logger;

        private List<TEntity> _testEntities;

        public GeneralEntityOperationsWrapper(IEntityRepository<TEntity> repository,
             IEntityConverter<TEntity, TAddDTO, TUpdateDTO> entityConverter,
             ILogger<GeneralEntityOperationsWrapper<TEntity, TAddDTO, TUpdateDTO>> logger)
             : base(repository, entityConverter, logger)
        {
            _testEntities = new List<TEntity>();
            _repository = repository;
            _entityConverter = entityConverter;
            _logger = logger;
        }

        public override Task<int> AddAsync(TAddDTO addEntityDTO)
        {
            if (addEntityDTO == null)
            {
                return default;
            }

            try
            {
                var entity = _entityConverter.ToEntity(addEntityDTO);
                entity.Id = 1;

                return Task.FromResult(entity.Id);
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        public override Task<TEntity> FindAsync(int id)
        {
            if (id < 0)
            {
                return null;
            }

            var entity = new Mock<TEntity>().Object;
            entity.Id = id;
            _testEntities.Add(entity);

            var result = _testEntities.FirstOrDefault(x => x.Id == id);
            
            return Task.FromResult(result);
        }

        public override Task<bool> UpdateAsync(TUpdateDTO updateEntityDTO)
        {
            if(updateEntityDTO == null)
            {
                return default;
            }

            var entity = new Mock<TEntity>().Object;
            entity = new Mock<TEntity>().Object;

            var result = entity.Id != -1;

            return Task.FromResult(result);
        }

        public override Task<bool> RemoveAsync(int entityId)
        {
            var entity = new Mock<TEntity>().Object;
            entity.Id = entityId;
            _testEntities.Add(entity);
            _testEntities.Remove(entity);

            var result = _testEntities.Count == 0;

            return Task.FromResult(result);
        }
    }
}
