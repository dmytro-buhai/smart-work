using SmartWork.Core.Enums;

namespace SmartWork.Core.Entities
{
    public class Statistic : Entity
    {
        public int RoomId { get; set; }
        public StatisticType Type { get; set; }
        public string Title{ get; set; }
        public string Description { get; set; }
        public string Data { get; set; }
    }
}