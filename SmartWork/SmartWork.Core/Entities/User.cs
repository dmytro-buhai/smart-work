using Microsoft.AspNetCore.Identity;

namespace SmartWork.Core.Entities
{
    public class User : IdentityUser
    {
        public string DisplayName { get; set; }

    }
}