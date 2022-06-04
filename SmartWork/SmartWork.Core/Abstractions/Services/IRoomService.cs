using SmartWork.Core.DTOs.RoomDTOs;
using SmartWork.Core.DTOs.SubscribeDTOs;
using SmartWork.Core.Entities;
using System.Threading.Tasks;

namespace SmartWork.Core.Abstractions.Services
{
    public interface IRoomService : IEntityService<Room, AddRoomDTO, UpdateRoomDTO>
    {
        Task<InfoRoomDTO> GetRoomInfoById(int roomId);
        public Task<bool> UpdateSubscribeDetails(UpdateSubscribeDetailDTO newSubscribeDetails);
    }
}
