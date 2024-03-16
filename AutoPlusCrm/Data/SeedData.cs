using AutoPlusCrm.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AutoPlusCrm.Data
{
    public class SeedData
    {
        private readonly ApplicationDbContext data;

        public SeedData(ApplicationDbContext context)
        {
            data = context;
        }

        public static async Task InitializeUserRoles(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var roles = new[] { "Admin", "Manager", "User" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }
            }
        }

        public static async Task InitializeRetailerStores(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.RetailerStores.Any())
                {
                    return;
                }

                context.RetailerStores.AddRange(
                    new RetailerStores { Name = "Магазин София" },
                    new RetailerStores { Name = "Магазин Варна" },
                    new RetailerStores { Name = "Магазин Пловдив" },
                    new RetailerStores { Name = "Магазин Стара Загора" }
                );

                await context.SaveChangesAsync();
            }
        }

        public static async Task InitializeClientTypes(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.ClientTypes.Any())
                {
                    return;
                }

                context.ClientTypes.AddRange(
                    new ClientType { Type = "Магазин" },
                    new ClientType { Type = "Сервиз" }
                );

                await context.SaveChangesAsync();
            }
        }

        public static async Task InitializeAdminUser(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                string email = "admin@admin.com"; ;
                string password = "Admin@1234";

                if (await userManager.FindByNameAsync(email) == null)
                {
                    var user = new ApplicationUser();
                    user.UserName = email;
                    user.Email = email;
                    user.UserStoreId = 1;
                    user.UserFullName = "Admin User";

                    await userManager.CreateAsync(user, password);

                    await userManager.AddToRoleAsync(user, "Admin");
                }
            };
        }
    }
}
