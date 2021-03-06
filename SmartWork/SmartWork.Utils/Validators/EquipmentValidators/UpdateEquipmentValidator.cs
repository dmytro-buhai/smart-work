using FluentValidation;
using SmartWork.Core.DTOs.EquipmentDTOs;

namespace SmartWork.Utils.Validators.EquipmentValidators
{
    public class UpdateEquipmentValidator : AbstractValidator<UpdateEquipmentDTO>
    {
        public UpdateEquipmentValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.RoomId).NotEmpty().GreaterThan(0)
                .WithMessage("Specify the room for this equipment");
            RuleFor(x => x.Name).ObjectName();
            RuleFor(x => x.Type).NotEmpty();
            RuleFor(x => x.Description).MaximumLength(512);
            RuleFor(x => x.Amount).NotEmpty();
            RuleFor(x => x.IsAvailable).NotEmpty();
        }
    }
}
