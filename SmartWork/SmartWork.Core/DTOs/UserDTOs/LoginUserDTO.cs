using SmartWork.Core.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace SmartWork.Core.DTOs.UserDTOs
{
    public class LoginUserDTO : IDTO
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
