using SmartWork.Core.Abstractions;
using System;

namespace SmartWork.Core.DTOs.StatisticDTOs
{
    public class SimpleAttendanceForDateDTO : IDTO
    {
        public DateTime Date { get; set; }
        public int Count { get; set; }
    }
}
