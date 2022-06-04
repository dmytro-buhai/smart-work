using SmartWork.Core.Abstractions.EntityConvertors;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.DTOs.EquipmentDTOs;
using SmartWork.Core.DTOs.RoomDTOs;
using SmartWork.Core.DTOs.StatisticDTOs;
using SmartWork.Core.DTOs.SubscribeDTOs;
using SmartWork.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartWork.BLL.Services
{
    public class RoomService : 
        EntityService<Room, AddRoomDTO, UpdateRoomDTO>, 
        IRoomService
    {
        private readonly IGeneralEntityService<Room> _generalRoomService;
        private readonly IRoomEntityConverter _entityConverter;
        private readonly ISubscribeService _subscribeService;

        public RoomService(IGeneralEntityService<Room> generalRoomService,
             IRoomEntityConverter entityConverter,
             ISubscribeService subscribeService) :
             base(generalRoomService, entityConverter)
        {
            _generalRoomService = generalRoomService;
            _entityConverter = entityConverter;
            _subscribeService = subscribeService;
        }

        public Task<bool> UpdateSubscribeDetails(UpdateSubscribeDetailDTO newSubscribeDetails)
        {
            return _subscribeService.UpdateSubscribeDetailsForRoom(newSubscribeDetails);
        }

        public async Task<InfoRoomDTO> GetRoomInfoById(int roomId)
        {
            var includesForRoom = new string[] { "Equipment", "Statistics", "SubscribeDetails" };
            var room = await _generalRoomService.FindWithIncludesAsync(roomId, includesForRoom);

            if(room == null)
            {
                return default;
            }

            var roomInfo = new InfoRoomDTO
            {
                Id = room.Id,
                OfficeId = room.OfficeId,
                Name = room.Name,
                Number = room.Number,
                Square = room.Square.ToString(),
                AmountOfWorkplaces = room.AmountOfWorkplaces.ToString(),
                PhotoFileName = room.PhotoFileName,
            };

            var equipments = new List<InfoEquipmentDTO>();
            var subscribeDetails = new List<InfoSubscribeDetailDTO>();
            var statistics = new List<InfoStatisticDTO>();

            foreach (var equipment in room.Equipment)
            {
                equipments.Add(new InfoEquipmentDTO
                {
                    Id = equipment.Id,
                    RoomId = equipment.RoomId,
                    Type = (int)equipment.Type,
                    Name = equipment.Name,
                    Description = equipment.Description,
                    Amount = equipment.Amount,
                    IsAvailable = equipment.IsAvailable
                });
            }

            foreach (var subscribeDetail in room.SubscribeDetails)
            {
                subscribeDetails.Add(new InfoSubscribeDetailDTO
                {
                    Id = subscribeDetail.Id,
                    Type = $"{subscribeDetail.Type}",
                    Name = subscribeDetail.Name,
                    Price = subscribeDetail.Price,
                    Description = subscribeDetail.Description
                });
            }

            foreach (var statistic in room.Statistics)
            {
                statistics.Add(new InfoStatisticDTO
                {
                    Id = statistic.Id,
                    Type = $"{statistic.Type}",
                    Title = statistic.Title,
                    Description = statistic.Description,
                    Data = statistic.Data
                });
            }

            roomInfo.Equipments = equipments;
            roomInfo.SubscribeDetails = subscribeDetails;
            roomInfo.Statistics = statistics;

            return roomInfo;
        }
    }
}
