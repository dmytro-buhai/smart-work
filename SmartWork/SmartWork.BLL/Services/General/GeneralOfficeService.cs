using Microsoft.Extensions.Logging;
using SmartWork.Core.Abstractions.Repositories;
using SmartWork.Core.Entities;

namespace SmartWork.BLL.Services.General
{
    public class GeneralOfficeService : GeneralEntityService<Office>
    {
        private readonly IEntityRepository<Office> _repository;
        private readonly ILogger<GeneralOfficeService> _logger;

        public GeneralOfficeService(IEntityRepository<Office> repository,
            ILogger<GeneralOfficeService> logger) : base(repository, logger)
        {
            _repository = repository;
            _logger = logger;
        }
    }
}
