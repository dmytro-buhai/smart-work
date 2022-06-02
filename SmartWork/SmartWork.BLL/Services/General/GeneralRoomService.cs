using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SmartWork.Core.Abstractions.Repositories;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.Entities;
using SmartWork.Core.Enums;
using SmartWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartWork.BLL.Services.General
{
    public class GeneralRoomService : GeneralEntityService<Room>
    {
        private readonly IStatisticService _statisticService;
        private readonly ISubscribeService _subscribeService;
        private readonly IEntityRepository<Room> _repository;
        private readonly ILogger<GeneralRoomService> _logger;

        public GeneralRoomService(IStatisticService statisticService,
            ISubscribeService subscribeService,
            IEntityRepository<Room> repository,
            ILogger<GeneralRoomService> logger) : base(repository, logger)
        {
            _statisticService = statisticService;
            _subscribeService = subscribeService;
            _repository = repository;
            _logger = logger;
        }

        public override async Task<bool> AddAsync(Room entity)
        {
            try
            {
                var statisticCollection = new List<Statistic>{
                    new Statistic{
                        RoomId = entity.Id,
                        Title = string.Empty,
                        Type = StatisticType.Attendance,
                        Data = JsonConvert.SerializeObject(new List<AttendanceStatisticForDate>()),
                        Description = $"Statistic type: {StatisticType.Attendance} " +
                        $"for room {entity.Name} {entity.Number}"
                    },
                    new Statistic{
                        RoomId = entity.Id,
                        Title = string.Empty,
                        Type = StatisticType.Climate,
                        Data = string.Empty,
                        Description = $"Statistic type: {StatisticType.Climate} " +
                        $"for room {entity.Name} {entity.Number}"
                    },
                    new Statistic{
                        RoomId = entity.Id,
                        Title = string.Empty,
                        Type = StatisticType.Lighting,
                        Data = string.Empty,
                        Description = $"Statistic type: {StatisticType.Lighting} " +
                        $"for room {entity.Name} {entity.Number}"
                    }
                };

                entity.Statistics = statisticCollection;
                
                var room = await _repository.AddAsync(entity);
                await _repository.SaveChangesAsync();
                await _subscribeService.AddDefaultsSubscribeDetailsForRoom(room);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error during adding new room: {ex.Message}");
                return false;
            }
        }
    }
}
