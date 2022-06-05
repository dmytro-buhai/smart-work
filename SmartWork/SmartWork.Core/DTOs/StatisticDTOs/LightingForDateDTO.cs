using SmartWork.Core.Abstractions;
using System;

namespace SmartWork.Core.DTOs.StatisticDTOs
{
    public class LightingForDateDTO : IDTO
    {
        public int StatisticId { get; set; }
        public DateTime Date { get; set; }
        public int Lumens { get; set; }
    }
}
