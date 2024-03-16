using AutoPlusCrm.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutoPlusCrm.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Visit>()
            .HasOne(v => v.RetailerStore)
            .WithMany()
            .HasForeignKey(v => v.RetailerStoreId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApplicationUser>()
            .HasOne(au => au.UserStore)
            .WithMany()
            .HasForeignKey(au => au.UserStoreId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FutureTask>()
            .HasOne(ft => ft.RetailerStore)
            .WithMany()
            .HasForeignKey(ft => ft.RetailerStoreId)
            .OnDelete(DeleteBehavior.Restrict);

		}

        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientType> ClientTypes { get; set; }
        public DbSet<CreditLimit> CreditLimits { get; set; }
        public DbSet<MainDiscount> MainDiscounts { get; set; }
        public DbSet<ClientStore> Stores { get; set; }
        public DbSet<Models.FutureTask> Tasks { get; set; }
        public DbSet<VisitGrade> VisitGrades { get; set; }
        public DbSet<Visit> Visits { get; set; }
		public DbSet<RetailerStores> RetailerStores { get; set; }
	}
}
