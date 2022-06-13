using SmartWork.Core.DTOs.CompanyDTOs;
using SmartWork.Core.Entities;
using SmartWork.Core.Models;
using System.Threading.Tasks;

namespace SmartWork.Core.Abstractions.Services
{
    public interface ICompanyService : IGeneralEntityOperations<Company, AddCompanyDTO, UpdateCompanyDTO>
    {
        Task<PagedList<Company>> GetPagedListAsync(PagingParams param);
    }
}
