using SmartWork.Core.Abstractions;

namespace SmartWork.Core.DTOs.SubscribeDTOs
{
    public class InfoSubscribeDetailDTO : IDTO
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}
