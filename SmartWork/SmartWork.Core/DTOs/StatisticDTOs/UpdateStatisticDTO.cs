using SmartWork.Core.Abstractions;
using SmartWork.Core.Enums;

namespace SmartWork.Core.DTOs.StatisticDTOs
{
    public class UpdateStatisticDTO : IDTO
    {
        public int StatisticId { get; set; }
        public int RoomId { get; set; }
        public StatisticType Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Data { get; set; }
    }
}
