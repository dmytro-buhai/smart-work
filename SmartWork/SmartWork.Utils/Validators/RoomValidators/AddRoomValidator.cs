using FluentValidation;
using SmartWork.Core.DTOs.RoomDTOs;

namespace SmartWork.Utils.Validators.RoomValidators
{
    public class AddRoomValidator : AbstractValidator<AddRoomDTO>
    {
        public AddRoomValidator()
        {
            RuleFor(x => x.OfficeId).NotEmpty().GreaterThan(0)
               .WithMessage("Specify the company for this office");
            RuleFor(x => x.Name).ObjectName();
            RuleFor(x => x.Number).Matches(@"^\w+$");
            RuleFor(x => x.Square).Matches(@"^\d+$");
            RuleFor(x => x.PhotoFileName).PhotoFileName();
        }
    }
}
