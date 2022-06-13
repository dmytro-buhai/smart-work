using FluentValidation;
using SmartWork.Core.DTOs.RoomDTOs;

namespace SmartWork.Utils.Validators.RoomValidators
{
    public class UpdateRoomValidator : AbstractValidator<UpdateRoomDTO>
    {
        public UpdateRoomValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.OfficeId).NotEmpty().GreaterThan(0)
               .WithMessage("Specify the company for this office");
            RuleFor(x => x.Name).ObjectName();
            RuleFor(x => x.Number).Matches(@"^\w+$");
            RuleFor(x => x.Square).NotEmpty().GreaterThan(0);
            RuleFor(x => x.AmountOfWorkplaces).GreaterThan(0);
            RuleFor(x => x.PhotoFileName).PhotoFileName();
        }
    }
}
