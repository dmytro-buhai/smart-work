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

        public override async Task<bool> AddAsync(TAddDTO addEntityDTO)
        {
            try
            {
                var entity = _entityConverter.ToEntity(addEntityDTO);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public override Task<TEntity> FindAsync(int id)
        {

            var entity = new Mock<TEntity>().Object;
            entity.Id = id;
            _testEntities.Add(entity);

            var result = _testEntities.FirstOrDefault(x => x.Id == id);
            
            return Task.FromResult(result);
        }
    }
}
