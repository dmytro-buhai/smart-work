using SmartWork.Core.DTOs.OfficeDTOs;
using SmartWork.Core.Entities;

namespace SmartWork.Core.Abstractions.EntityConvertors
{
    public interface IOfficeEntityConverter : IEntityConverter<Office, AddOfficeDTO, UpdateOfficeDTO>
    {
    }
}
