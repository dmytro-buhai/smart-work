using SmartWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartWork.Core.Abstractions.ModelConvertors
{
    public interface IModelConverter<TEnity, TInfoModel, TAddModel, TUpdateModel>
        where TEnity : Entity
        where TInfoModel : class
        where TAddModel : class
        where TUpdateModel : class
    {
        public TEnity InfoModelToEntity(TInfoModel model);
        public TEnity AddModelToEntity(TAddModel model);
        public TEnity UpdateModelToEntity(TUpdateModel model);
    }
}
