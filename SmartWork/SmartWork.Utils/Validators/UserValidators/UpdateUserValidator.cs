using FluentValidation;
using SmartWork.Core.DTOs.UserDTOs;

namespace SmartWork.Utils.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserDTO>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.FullName).NotEmpty().MaximumLength(128)
                .WithMessage("Please, specify your full name");
            RuleFor(x => x.PhoneNumber).PhoneNumber();
            RuleFor(x => x.DateOfBirth).BirthDate();
        }
    }
}
