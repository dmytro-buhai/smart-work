using FluentValidation;
using SmartWork.Core.DTOs.UserDTOs;

namespace SmartWork.Utils.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserDTO>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.DisplayName).NotEmpty().MaximumLength(128)
                .WithMessage("Please, specify your display name");
            RuleFor(x => x.PhoneNumber).PhoneNumber();
        }
    }
}
