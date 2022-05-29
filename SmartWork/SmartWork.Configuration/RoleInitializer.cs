using Microsoft.AspNetCore.Identity;
using SmartWork.Configuration.Resources;
using SmartWork.Core.Entities;
using System.Threading.Tasks;

namespace SmartWork.Configuration
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            // Default admin account
            var adminEmail = RoleInitializerResources.ResourceManager.GetString("AdminEmail");
            var adminPassword = RoleInitializerResources.ResourceManager.GetString("AdminPassword");

            // Roles
            var adminRole = RoleInitializerResources.ResourceManager.GetString("AdminRoleName");

            if ((await roleManager.FindByNameAsync(adminRole)) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
            }  

            if ((await userManager.FindByEmailAsync(adminEmail)) == null)
            {
                var admin = new User { Email = adminEmail, UserName = adminEmail, FullName = "admin" };
                var result = await userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, adminRole);
                }
            }
        }
    }
}