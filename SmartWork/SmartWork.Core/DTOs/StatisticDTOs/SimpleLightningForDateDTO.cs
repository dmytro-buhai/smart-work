using SmartWork.Core.Abstractions;
using System;

namespace SmartWork.Core.DTOs.StatisticDTOs
{
    public class SimpleLightningForDateDTO : IDTO
    {
        public DateTime Date { get; set; }
        public int Lumens { get; set; }
    }
}
