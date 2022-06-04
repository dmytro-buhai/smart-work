﻿using SmartWork.Core.Abstractions;

namespace SmartWork.Core.DTOs.StatisticDTOs
{
    public class InfoStatisticDTO : IDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Data { get; set; }
    }
}
