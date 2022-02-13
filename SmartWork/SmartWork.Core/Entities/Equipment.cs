using SmartWork.Core.Enums;

namespace SmartWork.Core.Entities
{
    public class Equipment : Entity
    {
        public int RoomId { get; set; }
        public EquipmentType Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public bool IsAvailable { get; set; }
    }
}