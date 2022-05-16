using FluentValidation;
using SmartWork.Core.DTOs.OfficeDTOs;

namespace SmartWork.Utils.Validators.OfficeValidators
{
    public class UpdateOfficeValidator : AbstractValidator<UpdateOfficeDTO>
    {
        public UpdateOfficeValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
            RuleFor(x => x.Name).ObjectName();
            RuleFor(x => x.Address).Address();
            RuleFor(x => x.PhoneNumber).PhoneNumber();
            RuleFor(x => x.PhotoFileName).PhotoFileName();
            RuleFor(x => x.CompanyId).NotEmpty().GreaterThan(0)
                .WithMessage("Specify the company for this office");
            RuleFor(x => x.IsFavourite).NotEmpty();
        }
    }
}
