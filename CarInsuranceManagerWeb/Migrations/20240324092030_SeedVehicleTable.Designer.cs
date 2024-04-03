﻿// <auto-generated />
using CarInsuranceManagerWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarInsuranceManagerWeb.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240324092030_SeedVehicleTable")]
    partial class SeedVehicleTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarInsuranceManagerWeb.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BodyNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EngineNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

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
                            Rate = 5,
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
                            Rate = 8,
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
                            Rate = 15,
                            Version = "2023"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}