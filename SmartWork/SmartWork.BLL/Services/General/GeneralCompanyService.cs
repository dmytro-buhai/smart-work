using Microsoft.Extensions.Logging;
using SmartWork.Core.Abstractions.Repositories;
using SmartWork.Core.Entities;

namespace SmartWork.BLL.Services.General
{
    public class GeneralCompanyService : GeneralEntityService<Company>
    {
        private readonly IEntityRepository<Company> _repository;
        private readonly ILogger<GeneralCompanyService> _logger;

        public GeneralCompanyService(IEntityRepository<Company> repository, 
            ILogger<GeneralCompanyService> logger) : base (repository, logger) 
        {
            _repository = repository;
            _logger = logger;
        }
    }
}
