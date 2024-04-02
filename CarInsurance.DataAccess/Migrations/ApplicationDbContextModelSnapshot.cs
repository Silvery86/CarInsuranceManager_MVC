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
