using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace AutoPlusCrm.Data.Models
{
    public class AdminUserCreation
    {
        public class SampleData
        {
            public static void Initialize(IServiceProvider serviceProvider)
            {
                var context = serviceProvider.GetService();
                string[] roles = new string[] { "Owner", "Administrator", "Manager", "Editor", "Buyer", "Business", "Seller", "Subscriber" };
                foreach (string role in roles)
                {
                    var roleStore = new RoleStore(context);
                    if (!context.Roles.Any(r => r.Name == role))
                    {
                        roleStore.CreateAsync(new IdentityRole(role));
                    }
                }
                var user = new ApplicationUser
                {
                    FirstName = "XXXX",
                    LastName = "XXXX",
                    Email = "xxxx@example.com",
                    NormalizedEmail = "XXXX@EXAMPLE.COM",
                    UserName = "Owner",
                    NormalizedUserName = "OWNER",
                    PhoneNumber = "+111111111111",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };
                if (!context.Users.Any(u => u.UserName == user.UserName))
                {
                    var password = new PasswordHasher();
                    var hashed = password.HashPassword(user, "secret");
                    user.PasswordHash = hashed;
                    var userStore = new UserStore(context);
                    var result = userStore.CreateAsync(user);
                }
                AssignRoles(serviceProvider, user.Email, roles);
                context.SaveChangesAsync();
            }
            public static async Task AssignRoles(IServiceProvider services, string email, string[] roles)
            {
                UserManager _userManager = services.GetService > ();
                ApplicationUser user = await _userManager.FindByEmailAsync(email);
                var result = await _userManager.AddToRolesAsync(user, roles);
                return result;
            }
        }
    }
}
