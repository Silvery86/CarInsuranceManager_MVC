using CarInsurance.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarInsurance.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Estimate> Estimates { get; set; }

        public DbSet<Record> Records { get; set; }

        public DbSet<Billing> Billings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Policy>().HasData(
                new Policy
                {
                    Id = 1,
                    Name = "Basic",
                    Warranty = "Damage third-party vehicle,Own Damage Theft",
                    BaseCost = 70,
                    AnnualCost = 0.25,
                    Description = "Basic Insurance Policy",
                },
                 new Policy
                 {
                     Id = 2,
                     Name = "Standard",
                     Warranty = "Damage third-party vehicle,Own Damage Theft,Damage due to fire,Naturaly damage",
                     BaseCost = 90,
                     AnnualCost = 0.27,
                     Description = "Standard Insurance Policy",
                 },
                  new Policy
                  {
                      Id = 3,
                      Name = "Extended",
                      Warranty = "Damage third-party vehicle,Own Damage Theft,Damage due to fire,Naturaly damage,Personal Accident cover",
                      BaseCost = 120,
                      AnnualCost = 0.29,
                      Description = "Extended Insurance Policy",
                  }

                );
        }
    }
}
