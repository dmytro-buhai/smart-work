using SmartWork.Core.DTOs.SubscribeDTOs;
using SmartWork.Core.Entities;
using System.Threading.Tasks;

namespace SmartWork.Core.Abstractions.Services
{
    public interface ISubscribeService
    {
        public Task<bool> AddDefaultsSubscribeDetailsForRoom(Room room);
        public Task<bool> UpdateSubscribeDetailsForRoom(UpdateSubscribeDetailDTO subscribeDetail);
    }
}
