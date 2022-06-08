using SmartWork.Core.DTOs.OfficeDTOs;
using SmartWork.Core.Entities;
using SmartWork.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartWork.Core.Abstractions.Services
{
    public interface IOfficeService : IGeneralEntityOperations<Office, AddOfficeDTO, UpdateOfficeDTO>
    {
        Task<List<InfoOfficeDTO>> GetOfficesWithCompanyAndRoomsAsync(PageInfo pageInfo);
    }
}
