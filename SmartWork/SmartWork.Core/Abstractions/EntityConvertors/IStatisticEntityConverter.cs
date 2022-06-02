using SmartWork.Core.DTOs.StatisticDTOs;
using SmartWork.Core.Entities;

namespace SmartWork.Core.Abstractions.EntityConvertors
{
    public interface IStatisticEntityConverter : IEntityConverter<Statistic, AddStatisticDTO, UpdateStatisticDTO>
    {
    }
}
