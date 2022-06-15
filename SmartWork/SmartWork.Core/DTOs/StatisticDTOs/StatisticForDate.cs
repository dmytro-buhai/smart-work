using SmartWork.Core.Abstractions;
using System;

namespace SmartWork.Core.DTOs.StatisticDTOs
{
    public class StatisticForDate: IDTO
    {
        public int StatisticId { get; set; }
        public DateTime Date { get; set; }
    }
}
