using SmartWork.Core.DTOs.StatisticDTOs;
using SmartWork.Core.Entities;
using SmartWork.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWork.Core.Abstractions.Services
{
    public interface IStatisticService
    {
        public Task<bool> AddAsync(IEnumerable<AddStatisticDTO> statistics);
        public Task<StatisticType> GetStatisticType(int statisticId);
        public Task<bool> SetData(int statisticId, string data);
    }
}
