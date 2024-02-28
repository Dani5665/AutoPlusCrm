using AutoPlusCrm.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace AutoPlusCrm.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientType> ClientTypes { get; set; }
        public DbSet<CreditLimit> CreditLimits { get; set; }
        public DbSet<MainDiscount> MainDiscounts { get; set; }
        public DbSet<ClientStore> Stores { get; set; }
        public DbSet<Models.FutureTask> Tasks { get; set; }
        public DbSet<VisitGrade> VisitGrades { get; set; }
        public DbSet<Visit> Visits { get; set; }

    }
}
