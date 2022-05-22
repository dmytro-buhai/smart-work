using SmartWork.Core.Abstractions.EntityConvertors;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.DTOs.CompanyDTOs;
using SmartWork.Core.Entities;

namespace SmartWork.BLL.Services
{
    public class CompanyService : 
        EntityService<Company, AddCompanyDTO, UpdateCompanyDTO>,
        ICompanyService
    {
        private readonly IGeneralEntityService<Company> _generalEntityService;
        private readonly ICompanyEntityConverter _entityConverter;

        public CompanyService(IGeneralEntityService<Company> generalEntityService, 
            ICompanyEntityConverter entityConverter) :
            base(generalEntityService, entityConverter)
        {
            _generalEntityService = generalEntityService;
            _entityConverter = entityConverter;
        }
    }
}
