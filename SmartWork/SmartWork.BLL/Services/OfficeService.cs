using Microsoft.Extensions.Logging;
using SmartWork.BLL.Services.General;
using SmartWork.Core.Abstractions.EntityConvertors;
using SmartWork.Core.Abstractions.Repositories;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.DTOs.OfficeDTOs;
using SmartWork.Core.Entities;

namespace SmartWork.BLL.Services
{
    public class OfficeService :
        GeneraEntityOperations<Office, AddOfficeDTO, UpdateOfficeDTO>,
        IOfficeService
    {
        private readonly IEntityRepository<Office> _officeRepository;
        private readonly IOfficeEntityConverter _entityConverter;
        private readonly ILogger<OfficeService> _logger;

        public OfficeService(IEntityRepository<Office> officeRepository,
             IOfficeEntityConverter entityConverter,
             ILogger<OfficeService> logger) :
             base(officeRepository, entityConverter, logger)
        {
            _officeRepository = officeRepository;
            _entityConverter = entityConverter;
            _logger = logger;
        }
    }
}
