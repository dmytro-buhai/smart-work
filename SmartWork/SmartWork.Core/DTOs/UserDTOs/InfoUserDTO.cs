using SmartWork.Core.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;

namespace SmartWork.Core.DTOs.UserDTOs
{
    public class InfoUserDTO : IDTO
    {
        public string Id { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Full name")]
        public string FullName { get; set; }

        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
    }
}
