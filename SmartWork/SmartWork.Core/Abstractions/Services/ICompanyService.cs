using SmartWork.Core.DTOs.CompanyDTOs;
using SmartWork.Core.Entities;

namespace SmartWork.Core.Abstractions.Services
{
    public interface ICompanyService : IGeneralEntityOperations<Company, AddCompanyDTO, UpdateCompanyDTO>
    {
          
    }
}
