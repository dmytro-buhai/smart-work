using SmartWork.Core.DTOs.CompanyDTOs;
using SmartWork.Core.Entities;

namespace SmartWork.Core.Abstractions.EntityConvertors
{
    public interface ICompanyEntityConverter : IEntityConverter<Company, AddCompanyDTO, UpdateCompanyDTO>
    {
    }
}
