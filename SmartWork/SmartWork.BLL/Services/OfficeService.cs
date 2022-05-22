using SmartWork.Core.Abstractions.EntityConvertors;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.DTOs.OfficeDTOs;
using SmartWork.Core.Entities;

namespace SmartWork.BLL.Services
{
    public class OfficeService :
        EntityService<Office, AddOfficeDTO, UpdateOfficeDTO>,
        IOfficeService
    {
        private readonly IGeneralEntityService<Office> _generalEntityService;
        private readonly IOfficeEntityConverter _entityConverter;

        public OfficeService(IGeneralEntityService<Office> generalEntityService,
             IOfficeEntityConverter entityConverter) :
             base(generalEntityService, entityConverter)
        {
            _generalEntityService = generalEntityService;
            _entityConverter = entityConverter;
        }
    }
}
