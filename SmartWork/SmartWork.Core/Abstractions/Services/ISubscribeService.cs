using SmartWork.Core.DTOs.SubscribeDTOs;
using SmartWork.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartWork.Core.Abstractions.Services
{
    public interface ISubscribeService
    {
        public Task<bool> AddDefaultsSubscribeDetailsForRoom(Room room);
        Task<bool> AddSubscribeDetailsForRoom(Room room, int subscribeForDay,
                int subscribeForWeek, int subscribeForMonth);
        Task<List<SubscribeDetail>> GetSubscribeDetailsForRoom(int roomId);
        Task<List<SubscribeDetail>> GetSubscribeDetailsForRooms(int[] roomsIDs);
        Task<List<InfoUserSubscribe>> GetUserSubscribesAsync(string userId);
        Task<InfoUserSubscribe> OrderSubscribe(OrderSubscribeDTO orderSubscribe);
        public Task<bool> UpdateSubscribeDetailsForRoom(UpdateSubscribeDetailDTO subscribeDetail);
    }
}
