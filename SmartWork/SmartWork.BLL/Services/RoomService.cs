using SmartWork.Core.Abstractions.EntityConvertors;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.DTOs.RoomDTOs;
using SmartWork.Core.DTOs.SubscribeDTOs;
using SmartWork.Core.Entities;
using System.Threading.Tasks;

namespace SmartWork.BLL.Services
{
    public class RoomService : 
        EntityService<Room, AddRoomDTO, UpdateRoomDTO>, 
        IRoomService
    {
        private readonly IGeneralEntityService<Room> _generalEntityService;
        private readonly IRoomEntityConverter _entityConverter;
        private readonly ISubscribeService _subscribeService;

        public RoomService(IGeneralEntityService<Room> generalEntityService,
             IRoomEntityConverter entityConverter,
             ISubscribeService subscribeService) :
             base(generalEntityService, entityConverter)
        {
            _generalEntityService = generalEntityService;
            _entityConverter = entityConverter;
            _subscribeService = subscribeService;
        }

        public Task<bool> UpdateSubscribeDetails(int roomId, UpdateSubscribeDetailDTO newSubscribeDetails)
        {
            return _subscribeService.UpdateSubscribeDetailsForRoom(roomId, newSubscribeDetails);
        }
    }
}
