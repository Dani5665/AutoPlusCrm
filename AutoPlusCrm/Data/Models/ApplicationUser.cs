using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPlusCrm.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? UserFullName { get; set; } = string.Empty;

        [ForeignKey(nameof(UserStore))]
        public int UserStoreId { get; set; }

        public RetailerStores UserStore { get; set; } = null!;

        public int GetUserStoreId()
        {
            return UserStoreId;
        }
    }
}
