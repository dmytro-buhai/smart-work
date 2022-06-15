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
        Task<InfoStatisticDTO> FindAsync(int statId);
        public Task<List<Statistic>> GetAsync(PageInfo pageInfo);
        public Task<bool> AddAsync(IEnumerable<AddStatisticDTO> statistics);
        public Task<bool> AddAttendanceStatisticInfoAsync(AttendanceForDateDTO attendanceStatistic);
        public Task<bool> AddClimateStatisticInfoAsync(ClimateForDateDTO climateStatistic);
        public Task<bool> AddLightingStatisticInfo(LightingForDateDTO lightingStatistic);
        public Task<StatisticType> GetStatisticType(int statisticId);
        Task<bool> AddDefaultsStatisticDataForRoom(Room room);
        Task<List<InfoStatisticDTO>> GetAttendanceStatisticAsync(PageInfo pageInfo);
        Task<List<InfoStatisticDTO>> GetAttendanceStatisticForRoomAsync(int roomId);
        Task<List<InfoStatisticDTO>> GetByRoomIdAsync(int roomId);
        Task<bool> AddLightingStatisticDataFromFile(string data);
        Task<bool> AddClimateStatisticDataFromFile(string data);
        Task<bool> AddAttendanceStatisticDataFromFile(string data);
    }
}
