using FluentValidation;
using SmartWork.Core.ViewModels.UserViewModels;

namespace SmartWork.Utils.Validators
{
    public class EditUserValidator : AbstractValidator<EditUserViewModel>
    {
        public EditUserValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.FullName).NotEmpty().MaximumLength(128)
                .WithMessage("Please, specify your full name");
            RuleFor(x => x.PhoneNumber).Password();
        }
    }
}
