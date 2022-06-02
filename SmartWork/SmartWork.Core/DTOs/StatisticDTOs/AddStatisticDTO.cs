using SmartWork.Core.Abstractions;
using SmartWork.Core.Enums;

namespace SmartWork.Core.DTOs.StatisticDTOs
{
    public class AddStatisticDTO : IDTO
    {
        public int RoomId { get; set; }
        public StatisticType Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Data { get; set; }
    }
}
