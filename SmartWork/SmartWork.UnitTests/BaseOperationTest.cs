using Microsoft.Extensions.Logging;
using Moq;
using SmartWork.Core.Abstractions;
using SmartWork.Core.Abstractions.EntityConvertors;
using SmartWork.Core.Abstractions.Repositories;
using SmartWork.Core.Entities;


namespace SmartWork.UnitTests
{
    public class BaseOperationTest<TEntity, TAddDTO, TUpdateDTO>
        where TEntity : Entity
        where TAddDTO : IDTO
        where TUpdateDTO : IDTO
    {
        protected Mock<IEntityRepository<TEntity>> TestEntityRepository;
        protected IEntityConverter<TEntity, TAddDTO, TUpdateDTO> TestEntityConverter;
        protected Mock<ILogger<GeneralEntityOperationsWrapper<TEntity, TAddDTO, TUpdateDTO>>> TestLogger;
    }
}