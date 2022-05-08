using FluentValidation;
using SmartWork.Core.Entities;

namespace SmartWork.Utils.Validators
{
    public class OfficeValidator : AbstractValidator<Office>
    {
        public OfficeValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(256).Matches(@"^\D+$")
                .WithMessage("Please, specify an office name");
            RuleFor(x => x.Address).Address();
            RuleFor(x => x.PhoneNumber).PhoneNumber();
            RuleFor(x => x.PhotoFileName).NotEmpty()
                .WithMessage("Please, specify a photo file name");
            RuleFor(x => x.CompanyId).NotEmpty().GreaterThan(0)
                .WithMessage("Specify the company for this office");
        }
    }
}
