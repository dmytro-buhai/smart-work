using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SmartWork.Core.Abstractions.EntityConvertors;
using SmartWork.Core.Abstractions.Repositories;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.DTOs.StatisticDTOs;
using SmartWork.Core.Entities;
using SmartWork.Core.Enums;
using SmartWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartWork.BLL.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IEntityRepository<Statistic> _statisticRepository;
        private readonly IStatisticEntityConverter _entityConverter;
        private readonly ILogger<StatisticService> _logger;

        public StatisticService(IEntityRepository<Statistic> statisticRepository,
            IStatisticEntityConverter entityConverter,
            ILogger<StatisticService> logger)
        {
            _statisticRepository = statisticRepository;
            _entityConverter = entityConverter;
            _logger = logger;
        }

        public async Task<bool> AddDefaultsStatisticDataForRoom(Room room)
        {
            var statisticCollection = new List<Statistic>{
                new Statistic{
                    RoomId = room.Id,
                    Title = string.Empty,
                    Type = StatisticType.Attendance,
                    Data = JsonConvert.SerializeObject(new List<AttendanceForDateDTO>()),
                    Description = $"Statistic type: {StatisticType.Attendance} " +
                    $"for room {room.Name} {room.Number}"
                },
                new Statistic{
                    RoomId = room.Id,
                    Title = string.Empty,
                    Type = StatisticType.Climate,
                    Data = JsonConvert.SerializeObject(new List<ClimateForDateDTO>()),
                    Description = $"Statistic type: {StatisticType.Climate} " +
                    $"for room {room.Name} {room.Number}"
                },
                new Statistic{
                    RoomId = room.Id,
                    Title = string.Empty,
                    Type = StatisticType.Lighting,
                    Data =JsonConvert.SerializeObject(new List<LightingForDateDTO>()),
                    Description = $"Statistic type: {StatisticType.Lighting} " +
                    $"for room {room.Name} {room.Number}"
                }
            };
            try
            {
                await _statisticRepository.AddAsync(statisticCollection);
                await _statisticRepository.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error duting adding room statistics: {ex.Message}");
                return false;
            }
        }

        public Task<List<Statistic>> GetAsync(PageInfo pageInfo)
        {
            return _statisticRepository.GetAsync(pageInfo);
        }

        public Task<Statistic> FindAsync(int id)
        {
            try
            {
                return _statisticRepository.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"error during finding statistic by id: {ex.Message}");
                return default;
            }
        }

        public async Task<bool> AddAttendanceStatisticInfoAsync(AttendanceForDateDTO attendanceByDay)
        {
            var statistic = await _statisticRepository.FindAsync(attendanceByDay.StatisticId);
            return await AddStatisticDataForAttendance(statistic, attendanceByDay);
        }

        public async Task<bool> AddClimateStatisticInfoAsync(ClimateForDateDTO climateByDay)
        {
            var statistic = await _statisticRepository.FindAsync(climateByDay.StatisticId);
            return await AddStatisticDataForClimate(statistic, climateByDay);
        }

        public async Task<bool> AddLightingStatisticInfo(LightingForDateDTO lightingByDay)
        {
            var statistic = await _statisticRepository.FindAsync(lightingByDay.StatisticId);
            return await AddStatisticDataForLighting(statistic, lightingByDay);
        }

        public async Task<bool> AddAsync(IEnumerable<AddStatisticDTO> statistics)
        {
            try
            {
                await _statisticRepository.AddAsync(_entityConverter.ToEntities(statistics));
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error during adding set of rooms statistic: {ex.Message}");
                return false;
            }
        }

        public async Task<StatisticType> GetStatisticType(int statisticId)
        {
            var statistic = await _statisticRepository.FindAsync(s => s.Id == statisticId);

            if (statistic == null)
            {
                return default;
            }

            return statistic.Type;
        }

        private static void AddStatisticData<T>(ref Statistic statistic, T newStatisticInfo)
        {
            var data = (List<T>)JsonConvert.DeserializeObject(statistic.Data);

            if (data == null)
            {
                data = new List<T>();
            }

            data.Add(newStatisticInfo);
            statistic.Data = JsonConvert.SerializeObject(data);
        }

        private static void AddStatisticData<T>(ref Statistic statistic, List<T> newStatisticInfo)
        {
            var data = (List<T>)JsonConvert.DeserializeObject(statistic.Data);

            if (data == null)
            {
                data = new List<T>();
            }

            data.AddRange(newStatisticInfo);
            statistic.Data = JsonConvert.SerializeObject(data);
        }

        private async Task<bool> AddStatisticDataForAttendance(Statistic statistic,
            AttendanceForDateDTO attendanceByDay)
        {
            if(statistic.Type != StatisticType.Attendance)
            {
                return false;
            }

            try
            {
                AddStatisticData(ref statistic, attendanceByDay);
                await _statisticRepository.UpdateAsync(statistic);
                await _statisticRepository.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error during adding attendance statistic: {ex.Message}");
                return false;
            }
        }

        private async Task<bool> AddStatisticDataForAttendance(Statistic statistic, 
            List<AttendanceForDateDTO> attendanceStatistics)
        {
            if (statistic.Type != StatisticType.Attendance)
            {
                return false;
            }

            try
            {
                AddStatisticData(ref statistic, attendanceStatistics);
                await _statisticRepository.UpdateAsync(statistic);
                await _statisticRepository.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error during adding attendance statistic: {ex.Message}");
                return false;
            }
        }

        private async Task<bool> AddStatisticDataForClimate(Statistic statistic,
            ClimateForDateDTO climateByDay)
        {
            if (statistic.Type != StatisticType.Climate)
            {
                return false;
            }

            try
            {
                AddStatisticData(ref statistic, climateByDay);
                await _statisticRepository.UpdateAsync(statistic);
                await _statisticRepository.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error during adding climate statistic: {ex.Message}");
                return false;
            }
        }

        private async Task<bool> AddStatisticDataForLighting(Statistic statistic,
            LightingForDateDTO lightingByDay)
        {
            if (statistic.Type != StatisticType.Lighting)
            {
                return false;
            }

            try
            {
                AddStatisticData(ref statistic, lightingByDay);
                await _statisticRepository.UpdateAsync(statistic);
                await _statisticRepository.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error during adding lighting statistic: {ex.Message}");
                return false;
            }
        }
    }
}
