using SmartWork.Core.Abstractions;

namespace SmartWork.Core.DTOs.UserDTOs
{
    public class UpdateUserDTO : IDTO
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string DisplayName { get; set; }

        public string PhoneNumber { get; set; }
    }
}
