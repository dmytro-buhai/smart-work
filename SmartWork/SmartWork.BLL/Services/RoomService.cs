using Microsoft.Extensions.Logging;
using SmartWork.BLL.Services.General;
using SmartWork.Core.Abstractions.EntityConvertors;
using SmartWork.Core.Abstractions.Repositories;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.DTOs.EquipmentDTOs;
using SmartWork.Core.DTOs.RoomDTOs;
using SmartWork.Core.DTOs.StatisticDTOs;
using SmartWork.Core.DTOs.SubscribeDTOs;
using SmartWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartWork.BLL.Services
{
    public class RoomService :
        GeneraEntityOperations<Room, AddRoomDTO, UpdateRoomDTO>, 
        IRoomService
    {
        private readonly IEntityRepository<Room> _roomRepository;
        private readonly IRoomEntityConverter _roomEntityConverter;
        private readonly ISubscribeService _subscribeService;
        private readonly IStatisticService _statisticService;
        private readonly ILogger<RoomService> _logger;

        public RoomService(IEntityRepository<Room> roomRepository,
             IRoomEntityConverter roomEntityConverter,
             ISubscribeService subscribeService,
             IStatisticService statisticService,
             ILogger<RoomService> logger) 
             : base(roomRepository, roomEntityConverter, logger)
        {
            _roomRepository = roomRepository;
            _subscribeService = subscribeService;
            _statisticService = statisticService;
            _roomEntityConverter = roomEntityConverter;
            _logger = logger;
        }

        public async Task<Room> AddRoomWithDetailsAsync(AddRoomDTO addRoomDTO)
        {
            try
            {
                var roomEntity = _roomEntityConverter.ToEntity(addRoomDTO);
                var room = await _roomRepository.AddAsync(roomEntity);
                await _roomRepository.SaveChangesAsync();
                await _subscribeService.AddSubscribeDetailsForRoom(room, addRoomDTO.SubscribeForDay, 
                    addRoomDTO.SubscribeForWeek, addRoomDTO.SubscribeForMonth);
                await _statisticService.AddDefaultsStatisticDataForRoom(room);

                return room;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error during adding new room: {ex.Message}");
                return default;
            }
        }

        public Task<bool> UpdateSubscribeDetails(UpdateSubscribeDetailDTO newSubscribeDetails)
        {
            return _subscribeService.UpdateSubscribeDetailsForRoom(newSubscribeDetails);
        }

        public async Task<InfoRoomDTO> GetRoomInfoById(int roomId)
        {
            var includesForRoom = new string[] { "Equipment", "Statistics", "SubscribeDetails" };
            var room = await FindWithIncludesAsync(roomId, includesForRoom);

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
                Square = room.Square,
                AmountOfWorkplaces = room.AmountOfWorkplaces.ToString(),
                PhotoFileName = room.PhotoFileName,
                Host = room.Host
            };

            var equipments = new List<InfoEquipmentDTO>();
            var subscribeDetails = new List<InfoSubscribeDetailDTO>();
            var statistics = new List<SimpleInfoStatisticDTO>();

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
                    Type = (int)subscribeDetail.Type,
                    Name = subscribeDetail.Name,
                    Price = subscribeDetail.Price,
                    Description = subscribeDetail.Description
                });
            }

            foreach (var statistic in room.Statistics)
            {
                statistics.Add(new SimpleInfoStatisticDTO
                {
                    Id = statistic.Id,
                    Type = $"{statistic.Type}",
                    Title = statistic.Title,
                    Description = statistic.Description
                });
            }

            roomInfo.Equipments = equipments;
            roomInfo.SubscribeDetails = subscribeDetails;
            roomInfo.Statistics = statistics;

            return roomInfo;
        }
    }
}
