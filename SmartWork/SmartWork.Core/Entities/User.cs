using Microsoft.AspNetCore.Identity;
using System;

namespace SmartWork.Core.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}