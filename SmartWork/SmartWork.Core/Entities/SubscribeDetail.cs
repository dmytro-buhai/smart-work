using SmartWork.Core.Enums;

namespace SmartWork.Core.Entities
{
    public class SubscribeDetail : Entity
    {
        public int RoomId { get; set; }
        public SubscribeType Type { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; } 
        public virtual Room Room { get; set; }
    }
}