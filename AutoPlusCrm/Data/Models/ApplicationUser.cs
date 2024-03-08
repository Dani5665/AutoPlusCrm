using Microsoft.AspNetCore.Identity;

namespace AutoPlusCrm.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? UserFullName { get; set; } = string.Empty;

        public string? UserStore { get; set; } = string.Empty;
    }
}
