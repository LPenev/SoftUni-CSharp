using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaApp.Data.Seeding;

public class RoleSeeder
{
    public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
    {
        var managerEmail = "manager@abv.bg"; // Set the email for the manager role here, e.g., "
        var managerPassword = "123456"; // Set the password for the manager role here, e.g., "123456"

        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

        string[] roles = { "Manager", "User" };
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                var identityRole = new IdentityRole(role);
                await roleManager.CreateAsync(identityRole);
            }
        }

        if (userManager != null)
        {
            var user = new IdentityUser
            {
                UserName = managerEmail,
                Email = managerEmail
            };

            var result = await userManager.CreateAsync(user, managerPassword);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Manager");
            }
        }
    }
}
