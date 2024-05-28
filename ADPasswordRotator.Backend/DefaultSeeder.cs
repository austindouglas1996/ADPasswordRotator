using ADPasswordRotator.Shared.Model;
using Microsoft.AspNetCore.Identity;

namespace ADPasswordRotator.Backend
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Threading.Tasks;

    public static class DefaultSeeder
    {
        public static async Task SeedData(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<Admin>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Ensure the roles exist
            var roleName = "Admin";
            var roleExists = await roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            // Ensure the user exists
            var userName = "admin@example.com";
            var user = await userManager.FindByEmailAsync(userName);
            if (user == null)
            {
                user = new Admin
                {
                    UserName = userName,
                    Email = userName,
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(user, "SamplePassword123!");
                if (result.Succeeded)
                {
                    // Only assign the role if the user creation was successful
                    await userManager.AddToRoleAsync(user, roleName);
                }
                else
                {
                    // Handle errors here (optional)
                    throw new Exception("Failed to create user");
                }
            }
            else
            {
                // Ensure the user has the role
                if (!await userManager.IsInRoleAsync(user, roleName))
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }
    }

}
