using FluentValidation;
using SmartWork.Core.DTOs.CompanyDTOs;

namespace SmartWork.Utils.Validators.CompanyValidators
{
    public class AddCompanyValidator : AbstractValidator<AddCompanyDTO>
    {
        public AddCompanyValidator()
        {
            RuleFor(x => x.Name).ObjectName();
            RuleFor(x => x.Address).Address();
            RuleFor(x => x.PhoneNumber).PhoneNumber();
            RuleFor(x => x.Description).MaximumLength(512);
            RuleFor(x => x.PhotoFileName).NotEmpty()
                .WithMessage("Please, specify a photo file name");
        }
    }
}
