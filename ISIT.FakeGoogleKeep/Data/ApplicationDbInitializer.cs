using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ISIT.FakeGoogleKeep.Data
{
    public static class ApplicationDbInitializer
    {
        public static async Task SeedUsersAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@localhost.net";
            string userEmail = "user@localhost.net";
            string password = "1qaz!QAZ";
            if (await roleManager.FindByNameAsync(Constants.AdministratorRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(Constants.AdministratorRole));
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
            if (await userManager.FindByNameAsync(userEmail) == null)
            {
                IdentityUser user = new IdentityUser { Email = userEmail, UserName = userEmail };
                IdentityResult result = await userManager.CreateAsync(user, password);
            }
        }
    }
}
