using SmartWork.Core.Abstractions;
using System;
using System.Collections.Generic;

namespace SmartWork.Core.DTOs.StatisticDTOs
{
    public class InfoStatisticDTO : IDTO
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<DateTime> Dates { get; set; }
        public List<int> Values { get; set; }
    }
}
