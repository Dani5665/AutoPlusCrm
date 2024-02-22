using AutoPlusCrm.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutoPlusCrm.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ClientModel> ClientModels { get; set; }
        public DbSet<ClientTypeModel> ClientTypeModels { get; set; }
        public DbSet<CreditLimitModel> CreditLimitModels { get; set; }
        public DbSet<MainDiscountModel> MainDiscountModels { get; set; }
        public DbSet<StoreModel> StoreModels { get; set; }
        public DbSet<TaskModel> TaskModels { get; set; }
        public DbSet<VisitGradeModel> VisitGradeModels { get; set; }
        public DbSet<VisitModel> VisitModels { get; set; }
    }
}
