using CarInsurance.Models;
using Microsoft.EntityFrameworkCore;

namespace CarInsurance.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Policy> Policies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { Id = 1, Name = "Ford", Model = "Ecosport", Version = "2015", OwnerName = "Giang", BodyNumber = "ABC123", EngineNumber = "XYZ789", Number = "30A8686T", Rate = 50, VehicleValue = 20000 },
                new Vehicle { Id = 2, Name = "Toyota", Model = "Vios", Version = "2023", OwnerName = "Hoang", BodyNumber = "ABC456", EngineNumber = "XYZ123", Number = "30A9999T", Rate = 100, VehicleValue = 50000 },
                new Vehicle { Id = 3, Name = "MecedesBenz", Model = "G63", Version = "2023", OwnerName = "Nam", BodyNumber = "ABC789", EngineNumber = "XYZ789", Number = "30A6789T", Rate = 70, VehicleValue = 100000 }
                );

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
