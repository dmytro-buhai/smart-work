using SmartWork.Core.Abstractions;
using SmartWork.Core.Enums;

namespace SmartWork.Core.DTOs.SubscribeDTOs
{
    public class UpdateSubscribeDetailDTO : IDTO
    { 
        public int RoomId { get; set; }
        public SubscribeType Type { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}
