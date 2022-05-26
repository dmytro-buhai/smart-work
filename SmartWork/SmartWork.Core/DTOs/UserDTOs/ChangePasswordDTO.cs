using System.ComponentModel.DataAnnotations;

namespace SmartWork.Core.DTOs.UserDTOs
{
    public class ChangePasswordDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Old password")]
        public string OldPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }
    }
}
