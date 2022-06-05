using SmartWork.Core.DTOs.StatisticDTOs;
using SmartWork.Core.Entities;
using SmartWork.Core.Enums;
using SmartWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWork.Core.Abstractions.Services
{
    public interface IStatisticService
    {
        public Task<Statistic> FindAsync(int id);
        public Task<List<Statistic>> GetAsync(PageInfo pageInfo);
        public Task<bool> AddAsync(IEnumerable<AddStatisticDTO> statistics);
        public Task<bool> AddAttendanceStatisticInfoAsync(AttendanceForDateDTO attendanceStatistic);
        public Task<bool> AddClimateStatisticInfoAsync(ClimateForDateDTO climateStatistic);
        public Task<bool> AddLightingStatisticInfo(LightingForDateDTO lightingStatistic);
        public Task<StatisticType> GetStatisticType(int statisticId);
        Task<bool> AddDefaultsStatisticDataForRoom(Room room);
    }
}
