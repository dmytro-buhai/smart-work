using SmartWork.Core.Entities;

namespace SmartWork.Core.Abstractions.EntityConvertors
{
    public interface IEntityConverter<TEnity, TInfoDTO, TAddDTO, TUpdateDTO>
        where TEnity : Entity
        where TInfoDTO : IDTO
        where TAddDTO : IDTO
        where TUpdateDTO : IDTO
    {
        public TEnity ToEntity(TInfoDTO model);
        public TEnity ToEntity(TAddDTO model);
        public TEnity ToEntity(TUpdateDTO model);
    }
}
