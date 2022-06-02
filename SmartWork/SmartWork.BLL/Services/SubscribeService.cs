using Microsoft.Extensions.Logging;
using SmartWork.Core.Abstractions.Repositories;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.DTOs.SubscribeDTOs;
using SmartWork.Core.Entities;
using SmartWork.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWork.BLL.Services
{
    public class SubscribeService : ISubscribeService
    {
        private readonly IEntityRepository<Subscribe> _subscribeRepository;
        private readonly IEntityRepository<SubscribeDetail> _subscribeDetailRepository;
        private readonly ILogger<SubscribeService> _logger;

        public SubscribeService(IEntityRepository<Subscribe> subscribeRepository,
            IEntityRepository<SubscribeDetail> subscribeDetailRepository,
            ILogger<SubscribeService> logger)
        {
            _subscribeRepository = subscribeRepository;
            _subscribeDetailRepository = subscribeDetailRepository;
            _logger = logger;
        }

        public async Task<bool> AddDefaultsSubscribeDetailsForRoom(Room room)
        {
            var subscribeDetails = new List<SubscribeDetail>
            {
                new SubscribeDetail
                {
                    Name = $"Subscribe for a {SubscribeType.Day}",
                    Description = $"Subscribe type: {SubscribeType.Day} " +
                    $"for room {room.Name} {room.Number}",
                    Type = SubscribeType.Day,
                    Price = 5,
                    RoomId = room.Id
                },
                new SubscribeDetail
                {
                    Name = $"Subscribe for a {SubscribeType.Week}",
                    Description = $"Subscribe type: {SubscribeType.Week} " +
                    $"for room {room.Name} {room.Number}",
                    Type = SubscribeType.Week,
                    Price = 20,
                    RoomId = room.Id
                },
                new SubscribeDetail
                {
                    Name = $"Subscribe for a {SubscribeType.Month}",
                    Description = $"Subscribe type: {SubscribeType.Month} " +
                    $"for room {room.Name} {room.Number}",
                    Type = SubscribeType.Month,
                    Price = 65,
                    RoomId = room.Id
                }
            };

            try
            {
                await _subscribeDetailRepository.AddAsync(subscribeDetails);
                await _subscribeDetailRepository.SaveChangesAsync();

                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError($"error duting adding room subscribe details: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateSubscribeDetailsForRoom(int roomId, UpdateSubscribeDetailDTO subscribeDetail)
        {

            if(!await _subscribeDetailRepository.AnyAsync(d => d.RoomId == roomId))
            {
                return false;
            }

            try
            {
                return await UpdateSubscribeDetails(subscribeDetail);
            }
            catch(Exception ex)
            {
                _logger.LogError($"error during updating subscribe details for room: {ex.Message}");
                return false;
            }
        }

        private async Task<bool> UpdateSubscribeDetails(UpdateSubscribeDetailDTO subscribeDetail)
        {
            var currentSubscribeDetail = await _subscribeDetailRepository
                .FindAsync(d => d.Type == subscribeDetail.Type && d.RoomId == subscribeDetail.RoomId);

            if(currentSubscribeDetail == null)
            {
                return false;
            }

            currentSubscribeDetail.Name = subscribeDetail.Name;
            currentSubscribeDetail.Price = subscribeDetail.Price;
            currentSubscribeDetail.Description = subscribeDetail.Description;

            await _subscribeDetailRepository.UpdateAsync(currentSubscribeDetail);
            await _subscribeDetailRepository.SaveChangesAsync();

            return true;
        }
    }
}
