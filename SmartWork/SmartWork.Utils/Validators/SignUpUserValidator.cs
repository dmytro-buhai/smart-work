using FluentValidation;
using SmartWork.Core.ViewModels.UserViewModels;

namespace SmartWork.Utils.Validators
{
    public class SignUpUserValidator : AbstractValidator<SignInViewModel>
    {
        public SignUpUserValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.FullName).NotEmpty().MaximumLength(128)
                .WithMessage("Please, specify your full name");
            RuleFor(x => x.Password).Password();
        }
    }
}
