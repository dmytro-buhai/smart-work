using FluentValidation;
using SmartWork.Core.DTOs.SubscribeDTOs;

namespace SmartWork.Utils.Validators.SubscribeValidators
{
    public class UpdateSubscribeDetailValidator : AbstractValidator<UpdateSubscribeDetailDTO>
    {
        public UpdateSubscribeDetailValidator()
        {
            RuleFor(x => x.RoomId).NotEmpty().GreaterThan(0)
               .WithMessage("Specify the room for this subscribe");
            RuleFor(x => x.Name).ObjectName();
            RuleFor(x => x.Description).MaximumLength(512);
            RuleFor(x => x.Price).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Type).NotEmpty();
        }
    }
}
