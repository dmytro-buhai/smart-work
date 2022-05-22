using FluentValidation;
using SmartWork.Core.DTOs.CompanyDTOs;

namespace SmartWork.Utils.Validators.CompanyValidators
{
    public class UpdateCompanyValidator : AbstractValidator<UpdateCompanyDTO>
    {
        public UpdateCompanyValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
            RuleFor(x => x.Name).ObjectName();
            RuleFor(x => x.Address).Address();
            RuleFor(x => x.PhoneNumber).PhoneNumber();
            RuleFor(x => x.Description).MaximumLength(512);
            RuleFor(x => x.PhotoFileName).PhotoFileName();
        }
    }
}
