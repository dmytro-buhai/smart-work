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

        public async Task<bool> AddSubscribeDetailsForRoom(Room room, int subscribeForDay, 
                int subscribeForWeek, int subscribeForMonth)
        {
            var subscribeDetails = new List<SubscribeDetail>
            {
                new SubscribeDetail
                {
                    Name = $"Subscribe for a {SubscribeType.Day}",
                    Description = $"Subscribe type: {SubscribeType.Day} " +
                    $"for room {room.Name} {room.Number}",
                    Type = SubscribeType.Day,
                    Price = subscribeForDay,
                    RoomId = room.Id
                },
                new SubscribeDetail
                {
                    Name = $"Subscribe for a {SubscribeType.Week}",
                    Description = $"Subscribe type: {SubscribeType.Week} " +
                    $"for room {room.Name} {room.Number}",
                    Type = SubscribeType.Week,
                    Price = subscribeForWeek,
                    RoomId = room.Id
                },
                new SubscribeDetail
                {
                    Name = $"Subscribe for a {SubscribeType.Month}",
                    Description = $"Subscribe type: {SubscribeType.Month} " +
                    $"for room {room.Name} {room.Number}",
                    Type = SubscribeType.Month,
                    Price = subscribeForMonth,
                    RoomId = room.Id
                }
            };

            try
            {
                await _subscribeDetailRepository.AddAsync(subscribeDetails);
                await _subscribeDetailRepository.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error duting adding room subscribe details: {ex.Message}");
                return false;
            }
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

        public async Task<List<InfoUserSubscribe>> GetUserSubscribesAsync(string userId)
        {
            var infoUserSubscribes = new List<InfoUserSubscribe>();
            try
            {
                var subscribes = await _subscribeRepository.GetAsync(x => x.UserId == userId);
                foreach (var sub in subscribes)
                {
                    infoUserSubscribes.Add(CreateInfoUserSubscribe(sub));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"error during detting user subscribes: {ex.Message}");
            }

            return infoUserSubscribes;
        }

        public async Task<InfoUserSubscribe> OrderSubscribe(OrderSubscribeDTO orderSubscribe)
        {
            try
            {
                var subscribe = new Subscribe
                {
                    RoomId = orderSubscribe.RoomId,
                    UserId = orderSubscribe.UserId,
                    StartDate = orderSubscribe.StartDate,
                    EndDate = orderSubscribe.EndDate
                };

                var currentSubscribe = await _subscribeRepository.AddAsync(subscribe);
                await _subscribeRepository.SaveChangesAsync();

                return new InfoUserSubscribe
                {
                    Id = currentSubscribe.Id,
                    RoomId = subscribe.RoomId,
                    UserId = subscribe.UserId,
                    StartDate = subscribe.StartDate,
                    EndDate = subscribe.EndDate
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"error during creating subscribe: ${ex.Message}");
                return default;
            }
        }

        public Task<List<SubscribeDetail>> GetSubscribeDetailsForRooms(int[] roomsIDs)
        {
            return _subscribeDetailRepository.GetAsync((sd => roomsIDs.Contains(sd.RoomId)));
        }

        public Task<List<SubscribeDetail>> GetSubscribeDetailsForRoom(int roomId)
        {
            return _subscribeDetailRepository.GetAsync(sd => sd.RoomId == roomId);
        }

        public async Task<bool> UpdateSubscribeDetailsForRoom(UpdateSubscribeDetailDTO subscribeDetail)
        {

            if(!await _subscribeDetailRepository.AnyAsync(d => d.RoomId == subscribeDetail.RoomId))
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

        private InfoUserSubscribe CreateInfoUserSubscribe(Subscribe userSubscribe)
        {
            return new InfoUserSubscribe
            {
                Id = userSubscribe.Id,
                RoomId = userSubscribe.RoomId,
                UserId = userSubscribe.UserId,
                StartDate = userSubscribe.StartDate,
                EndDate = userSubscribe.EndDate
            };
        }
    }
}
