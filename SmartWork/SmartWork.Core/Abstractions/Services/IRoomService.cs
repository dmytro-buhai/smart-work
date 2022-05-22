using SmartWork.Core.DTOs.RoomDTOs;
using SmartWork.Core.Entities;

namespace SmartWork.Core.Abstractions.Services
{
    public interface IRoomService : IEntityService<Room, AddRoomDTO, UpdateRoomDTO>
    {
    }
}
