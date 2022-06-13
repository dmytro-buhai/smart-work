using SmartWork.Core.Abstractions;
using System;

namespace SmartWork.Core.DTOs.StatisticDTOs
{
    public class SimpleClimateForDateDTO : IDTO
    {
        public DateTime Date { get; set; }
        public int Temperature { get; set; }
    }
}
