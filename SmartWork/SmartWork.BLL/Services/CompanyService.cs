using Microsoft.Extensions.Logging;
using SmartWork.BLL.Services.General;
using SmartWork.Core.Abstractions.EntityConvertors;
using SmartWork.Core.Abstractions.Repositories;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.DTOs.CompanyDTOs;
using SmartWork.Core.Entities;
using SmartWork.Core.Models;
using System;
using System.Threading.Tasks;

namespace SmartWork.BLL.Services
{
    public class CompanyService : GeneraEntityOperations<Company, AddCompanyDTO, UpdateCompanyDTO>, 
        ICompanyService
    {
        private readonly IEntityRepository<Company> _companyRepository;
        private readonly ICompanyEntityConverter _companyEntityConverter;
        private readonly ILogger<CompanyService> _logger;

        public CompanyService(IEntityRepository<Company> companyRepository,
            ICompanyEntityConverter companyEntityConverter,
            ILogger<CompanyService> logger) 
            : base(companyRepository, companyEntityConverter, logger)
        {
            _companyRepository = companyRepository;
            _companyEntityConverter = companyEntityConverter;
            _logger = logger;
        }

        public async Task<PagedList<Company>> GetPagedListAsync(PagingParams param)
        {
            try
            {
                var companies = await PagedList<Company>
                    .CreateAsync(_companyRepository, param.PageNumber, param.PageSize);

                return companies;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error during getting '{typeof(Company).Name}' from db: {ex.Message}");
                return default;
            }
        }
    }
}
