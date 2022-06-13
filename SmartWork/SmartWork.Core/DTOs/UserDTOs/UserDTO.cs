using SmartWork.Core.Abstractions;

namespace SmartWork.Core.DTOs.UserDTOs
{
    public class UserDTO : IDTO
    {
        public string DisplayName { get; set; }

        public string Token { get; set; }

        public string Username { get; set; }
    }
}
