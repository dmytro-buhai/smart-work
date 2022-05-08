using FluentValidation;
using SmartWork.Core.Entities;

namespace SmartWork.Utils.Validators
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(256).Matches(@"^\D+$")
                .WithMessage("Please, specify a company name");
            RuleFor(x => x.Address).Address();
            RuleFor(x => x.PhoneNumber).PhoneNumber();
            RuleFor(x => x.Description).MaximumLength(512);
            RuleFor(x => x.PhotoFileName).NotEmpty()
                .WithMessage("Please, specify a photo file name");
        }
    }
}
