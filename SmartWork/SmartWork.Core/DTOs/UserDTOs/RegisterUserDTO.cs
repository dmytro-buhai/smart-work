using SmartWork.Core.Abstractions;

namespace SmartWork.Core.DTOs.UserDTOs
{
    public class RegisterUserDTO : IDTO
    {
        public string Email { get; set; }

        public string DisplayName { get; set; }

        public string Username { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public string PasswordConfirm { get; set; }
    }
}
