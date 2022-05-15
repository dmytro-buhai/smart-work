using SmartWork.Core.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;

namespace SmartWork.Core.ViewModels.UserViewModels
{
    public class EditUserViewModel : IDTO
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Full name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
    }
}
