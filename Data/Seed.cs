using Microsoft.AspNetCore.Identity;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class Seed 
{
   public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
   {
    using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
    {
        //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUserEntity>>();
                string adminUserEmail = "madusaralakshan@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUserEntity()
                    {
                        UserName = "teddysmithdev",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        Address = "Colombo",
                        FullName = "Teddy Smith",
                        
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }
                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUserEntity()
                    {
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        Address = "Colombo",
                        FullName = "App User",
                        
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }

    }
   } 
}