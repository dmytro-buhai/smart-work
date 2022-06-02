using SmartWork.Core.Abstractions.EntityConvertors;
using SmartWork.Core.DTOs.StatisticDTOs;
using SmartWork.Core.Entities;
using System.Collections.Generic;

namespace SmartWork.Utils.EntitiesUtils
{
    public class StatisticEntityConverter : IStatisticEntityConverter
    {
        public IEnumerable<Statistic> ToEntities(IEnumerable<AddStatisticDTO> transferObjects)
        {
            var statistics = new List<Statistic>();

            foreach (var transferObject in transferObjects)
            {
                statistics.Add(ToEntity(transferObject));
            }

            return statistics;
        }

        public IEnumerable<Statistic> ToEntities(IEnumerable<UpdateStatisticDTO> transferObjects)
        {
            var statistics = new List<Statistic>();

            foreach (var transferObject in transferObjects)
            {
                statistics.Add(ToEntity(transferObject));
            }

            return statistics;
        }

        public Statistic ToEntity(AddStatisticDTO transferObject)
        {
            return new Statistic
            {
                RoomId = transferObject.RoomId,
                Title = transferObject.Title,
                Type = transferObject.Type,
                Data = transferObject.Data,
                Description = transferObject.Description
            };
        }

        public Statistic ToEntity(UpdateStatisticDTO transferObject)
        {
            return new Statistic
            {
                Id = transferObject.StatisticId,
                RoomId = transferObject.RoomId,
                Title = transferObject.Title,
                Type = transferObject.Type,
                Data = transferObject.Data,
                Description = transferObject.Description
            };
        }
    }
}
