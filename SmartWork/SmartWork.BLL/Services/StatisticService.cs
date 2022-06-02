using Microsoft.Extensions.Logging;
using SmartWork.Core.Abstractions.EntityConvertors;
using SmartWork.Core.Abstractions.Repositories;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.DTOs.StatisticDTOs;
using SmartWork.Core.Entities;
using SmartWork.Core.Enums;
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

        public async Task<bool> SetData(int statisticId, string data)
        {
            var statistic = await _repository.FindAsync(s => s.Id == statisticId);

            if(statistic == null)
            {
                return false;
            }

            try
            {
                statistic.Data = data;
                await _repository.UpdateAsync(statistic);
                await _repository.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error during set data operation: {ex.Message}");
                return false;
            }
        }
    }
}
