using SmartWork.Core.Entities;

namespace SmartWork.Core.Abstractions.ModelConvertors
{
    public interface IModelConverter<TEnity, TInfoDTO, TAddDTO, TUpdateDTO>
        where TEnity : Entity
        where TInfoDTO : class
        where TAddDTO : class
        where TUpdateDTO : class
    {
        public TEnity ToEntity(TInfoDTO model);
        public TEnity ToEntity(TAddDTO model);
        public TEnity ToEntity(TUpdateDTO model);
    }
}
