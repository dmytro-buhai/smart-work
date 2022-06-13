using SmartWork.Core.Abstractions;

namespace SmartWork.Core.DTOs.EquipmentDTOs
{
    public class AddEquipmentDTO : IDTO
    {
        public int RoomId { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public bool IsAvailable { get; set; }
    }
}
