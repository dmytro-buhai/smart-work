using SmartWork.Core.Abstractions.EntityConvertors;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.DTOs.RoomDTOs;
using SmartWork.Core.Entities;

namespace SmartWork.BLL.Services
{
    public class RoomService : 
        EntityService<Room, AddRoomDTO, UpdateRoomDTO>, 
        IRoomService
    {
        private readonly IGeneralEntityService<Room> _generalEntityService;
        private readonly IRoomEntityConverter _entityConverter;

        public RoomService(IGeneralEntityService<Room> generalEntityService,
             IRoomEntityConverter entityConverter) :
             base(generalEntityService, entityConverter)
        {
            _generalEntityService = generalEntityService;
            _entityConverter = entityConverter;
        }
    }
}
