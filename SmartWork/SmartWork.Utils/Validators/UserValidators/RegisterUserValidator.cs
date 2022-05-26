using FluentValidation;
using SmartWork.Core.DTOs.UserDTOs;

namespace SmartWork.Utils.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserDTO>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.FullName).NotEmpty().MaximumLength(128)
                .WithMessage("Please, specify your full name");
            RuleFor(x => x.PhoneNumber).PhoneNumber();
            RuleFor(x => x.DateOfBirth).BirthDate();
            RuleFor(x => x.Password).Password();
            RuleFor(x => x).Must(x => x.Password == x.PasswordConfirm)
                .WithMessage("Password mismatch");
        }
    }
}
