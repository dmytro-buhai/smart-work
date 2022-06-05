using SmartWork.Core.DTOs.OfficeDTOs;
using SmartWork.Core.Entities;

namespace SmartWork.Core.Abstractions.Services
{
    public interface IOfficeService : IGeneralEntityOperations<Office, AddOfficeDTO, UpdateOfficeDTO>
    {
    }
}
