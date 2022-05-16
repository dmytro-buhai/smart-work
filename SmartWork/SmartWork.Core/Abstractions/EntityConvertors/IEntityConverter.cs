using SmartWork.Core.Entities;
using System.Collections.Generic;

namespace SmartWork.Core.Abstractions.EntityConvertors
{
    public interface IEntityConverter<TEnity, TAddDTO, TUpdateDTO>
        where TEnity : Entity
        where TAddDTO : IDTO
        where TUpdateDTO : IDTO
    {

        public TEnity ToEntity(TAddDTO transferObject);

        public TEnity ToEntity(TUpdateDTO transferObject);

        public IEnumerable<TEnity> ToEntities(IEnumerable<TAddDTO> transferObjects);

        public IEnumerable<TEnity> ToEntities(IEnumerable<TUpdateDTO> transferObjects);
    }
}
