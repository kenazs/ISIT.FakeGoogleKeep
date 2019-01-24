using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ISIT.FakeGoogleKeep.Data
{
    public static class ApplicationDbInitializer
    {
        public static async Task SeedUsersAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@localhost.net";
            string password = "1qaz!QAZ";
            if (await roleManager.FindByNameAsync(Constants.AdministratorRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(Constants.AdministratorRole));
            }
            if (await roleManager.FindByNameAsync(Constants.UserRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(Constants.UserRole));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                IdentityUser admin = new IdentityUser { Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, Constants.AdministratorRole);
                }
            }
        }
    }
}
