using SmartWork.Core.DTOs.RoomDTOs;
using SmartWork.Core.Entities;

namespace SmartWork.Core.Abstractions.EntityConvertors
{
    public interface IRoomEntityConverter : IEntityConverter<Room, AddRoomDTO, UpdateRoomDTO>
    {
    }
}
