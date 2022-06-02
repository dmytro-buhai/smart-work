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
        private readonly IEntityRepository<Statistic> _repository;
        private readonly IStatisticEntityConverter _entityConverter;
        private readonly ILogger<StatisticService> _logger;

        public StatisticService(IEntityRepository<Statistic> repository,
            IStatisticEntityConverter entityConverter,
            ILogger<StatisticService> logger)
        {
            _repository = repository;
            _entityConverter = entityConverter;
            _logger = logger;
        }

        public Task<List<Statistic>> GetAsync(PageInfo pageInfo)
        {
            return _repository.GetAsync(pageInfo);
        }

        public Task<Statistic> FindAsync(int id)
        {
            try
            {
                return _repository.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"error during finding statistic by id: {ex.Message}");
                return default;
            }
        }

        public async Task<bool> AddAttendanceStatisticInfoAsync(int statisticId, 
            AttendanceStatisticForDate attendanceStatistic)
        {
            var statistic = await _repository.FindAsync(statisticId);
            return await AddStatisticDataForAttendance(statistic, attendanceStatistic);
        }

        public async Task<bool> AddClimateStatisticInfoAsync(int statisticId,
            ClimateStatisticForDate climateStatistic)
        {
            var statistic = await _repository.FindAsync(statisticId);
            return await AddStatisticDataForClimate(statistic, climateStatistic);
        }

        public async Task<bool> AddLightingStatisticInfo(int statisticId,
            LightingStatisticForDate lightingStatistic)
        {
            var statistic = await _repository.FindAsync(statisticId);
            return await AddStatisticDataForLighting(statistic, lightingStatistic);
        }

        public async Task<bool> AddAsync(IEnumerable<AddStatisticDTO> statistics)
        {
            try
            {
                await _repository.AddAsync(_entityConverter.ToEntities(statistics));
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
            var statistic = await _repository.FindAsync(s => s.Id == statisticId);

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
            AttendanceStatisticForDate attendanceStatistic)
        {
            if(statistic.Type != StatisticType.Attendance)
            {
                return false;
            }

            try
            {
                AddStatisticData(ref statistic, attendanceStatistic);
                await _repository.UpdateAsync(statistic);
                await _repository.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error during adding attendance statistic: {ex.Message}");
                return false;
            }
        }

        private async Task<bool> AddStatisticDataForAttendance(Statistic statistic, 
            List<AttendanceStatisticForDate> attendanceStatistics)
        {
            if (statistic.Type != StatisticType.Attendance)
            {
                return false;
            }

            try
            {
                AddStatisticData(ref statistic, attendanceStatistics);
                await _repository.UpdateAsync(statistic);
                await _repository.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error during adding attendance statistic: {ex.Message}");
                return false;
            }
        }

        private async Task<bool> AddStatisticDataForClimate(Statistic statistic,
           ClimateStatisticForDate climateStatistic)
        {
            if (statistic.Type != StatisticType.Climate)
            {
                return false;
            }

            try
            {
                AddStatisticData(ref statistic, climateStatistic);
                await _repository.UpdateAsync(statistic);
                await _repository.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error during adding climate statistic: {ex.Message}");
                return false;
            }
        }

        private async Task<bool> AddStatisticDataForLighting(Statistic statistic,
           LightingStatisticForDate lightingStatistic)
        {
            if (statistic.Type != StatisticType.Lighting)
            {
                return false;
            }

            try
            {
                AddStatisticData(ref statistic, lightingStatistic);
                await _repository.UpdateAsync(statistic);
                await _repository.SaveChangesAsync();

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
