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
        private readonly IGeneralEntityService<Company> _generalCompanyService;
        private readonly ICompanyEntityConverter _entityConverter;

        public CompanyService(IGeneralEntityService<Company> generalCompanyService, 
            ICompanyEntityConverter entityConverter) :
            base(generalCompanyService, entityConverter)
        {
            _generalCompanyService = generalCompanyService;
            _entityConverter = entityConverter;
        }
    }
}
