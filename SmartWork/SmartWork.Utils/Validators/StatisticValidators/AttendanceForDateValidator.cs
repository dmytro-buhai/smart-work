using FluentValidation;
using SmartWork.Core.DTOs.StatisticDTOs;
using System;

namespace SmartWork.Utils.Validators.StatisticValidators
{
    public class AttendanceForDateValidator : AbstractValidator<AttendanceForDateDTO>
    {
        public AttendanceForDateValidator()
        {
            RuleFor(x => x.StatisticId).NotEmpty().GreaterThan(0)
              .WithMessage("Specify the statistic for this data");
            RuleFor(x => x.Date).Must(x => x.Date.Year == DateTime.Now.Year);
            RuleFor(x => x.Date).NotEmpty();
        }
    }
}
