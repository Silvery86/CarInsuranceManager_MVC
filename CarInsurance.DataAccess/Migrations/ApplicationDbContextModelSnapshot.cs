﻿// <auto-generated />
using CarInsurance.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarInsurance.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarInsurance.Models.Policy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AnnualCost")
                        .HasColumnType("float");

                    b.Property<double>("BaseCost")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Warranty")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Policies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnnualCost = 0.25,
                            BaseCost = 70.0,
                            Description = "Basic Insurance Policy",
                            Name = "Basic",
                            Warranty = "Damage third-party vehicle,Own Damage Theft"
                        },
                        new
                        {
                            Id = 2,
                            AnnualCost = 0.27000000000000002,
                            BaseCost = 90.0,
                            Description = "Standard Insurance Policy",
                            Name = "Standard",
                            Warranty = "Damage third-party vehicle,Own Damage Theft,Damage due to fire,Naturaly damage"
                        },
                        new
                        {
                            Id = 3,
                            AnnualCost = 0.28999999999999998,
                            BaseCost = 120.0,
                            Description = "Extended Insurance Policy",
                            Name = "Extended",
                            Warranty = "Damage third-party vehicle,Own Damage Theft,Damage due to fire,Naturaly damage,Personal Accident cover"
                        });
                });

            modelBuilder.Entity("CarInsurance.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BodyNumber")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("EngineNumber")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<decimal>("VehicleValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BodyNumber = "ABC123",
                            EngineNumber = "XYZ789",
                            Model = "Ecosport",
                            Name = "Ford",
                            Number = "30A8686T",
                            OwnerName = "Giang",
                            Rate = 50,
                            VehicleValue = 20000m,
                            Version = "2015"
                        },
                        new
                        {
                            Id = 2,
                            BodyNumber = "ABC456",
                            EngineNumber = "XYZ123",
                            Model = "Vios",
                            Name = "Toyota",
                            Number = "30A9999T",
                            OwnerName = "Hoang",
                            Rate = 100,
                            VehicleValue = 50000m,
                            Version = "2023"
                        },
                        new
                        {
                            Id = 3,
                            BodyNumber = "ABC789",
                            EngineNumber = "XYZ789",
                            Model = "G63",
                            Name = "MecedesBenz",
                            Number = "30A6789T",
                            OwnerName = "Nam",
                            Rate = 70,
                            VehicleValue = 100000m,
                            Version = "2023"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
