using SmartWork.Core.Abstractions;
using System;

namespace SmartWork.Core.DTOs.StatisticDTOs
{
    public class AttendanceForDateDTO : IDTO
    {
        public int StatisticId { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }
    }
}
