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
                var room = await _repository.AddAsync(entity);
                await _repository.SaveChangesAsync();
                await _subscribeService.AddDefaultsSubscribeDetailsForRoom(room);
                await _statisticService.AddDefaultsStatisticDataForRoom(room);

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
