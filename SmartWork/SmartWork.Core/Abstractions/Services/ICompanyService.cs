using SmartWork.Core.DTOs.CompanyDTOs;
using SmartWork.Core.Entities;

namespace SmartWork.Core.Abstractions.Services
{
    public interface ICompanyService : IEntityService<Company, AddCompanyDTO, UpdateCompanyDTO>
    {
    }
}
