﻿// <auto-generated />
using System;
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

            modelBuilder.Entity("CarInsurance.Models.Billing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("BillNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BillingAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerAddProve")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CustomerPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PolicyDuration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PolicyEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PolicyStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("VehicleModel")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("VehicleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("VehicleNumber")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("VehiclePolicyType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("VehicleRate")
                        .HasColumnType("int");

                    b.Property<decimal>("VehicleValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("VehicleVersion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleWarranty")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Billings");
                });

            modelBuilder.Entity("CarInsurance.Models.Claim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BillNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BillingId")
                        .HasColumnType("int");

                    b.Property<double>("ClaimableAmount")
                        .HasColumnType("float");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DateOfAccident")
                        .HasMaxLength(200)
                        .HasColumnType("datetime2");

                    b.Property<double>("InsuranceAmount")
                        .HasColumnType("float");

                    b.Property<double>("InsuranceCost")
                        .HasColumnType("float");

                    b.Property<string>("PlaceOfAccident")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PolicyDuration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PolicyEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PolicyStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("VehicleModel")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("VehicleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("VehicleNumber")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("VehiclePolicyType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("VehicleRate")
                        .HasColumnType("int");

                    b.Property<decimal>("VehicleValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("VehicleVersion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleWarranty")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("BillingId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Claims");
                });

            modelBuilder.Entity("CarInsurance.Models.Estimate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CustomerAddProve")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CustomerPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("EstimateCost")
                        .HasColumnType("float");

                    b.Property<double>("PolicyAnnualCost")
                        .HasColumnType("float");

                    b.Property<double>("PolicyBaseCost")
                        .HasColumnType("float");

                    b.Property<int>("PolicyId")
                        .HasColumnType("int");

                    b.Property<string>("VehicleModel")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("VehicleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("VehicleNumber")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("VehiclePolicyType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("VehicleRate")
                        .HasColumnType("int");

                    b.Property<decimal>("VehicleValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("VehicleVersion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleWarranty")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PolicyId");

                    b.ToTable("Estimates");
                });

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

            modelBuilder.Entity("CarInsurance.Models.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CustomerAddProve")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CustomerPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("InsuranceCost")
                        .HasColumnType("float");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PolicyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PolicyDuration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleModel")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("VehicleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("VehicleNumber")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("VehiclePolicyType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("VehicleRate")
                        .HasColumnType("int");

                    b.Property<decimal>("VehicleValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("VehicleVersion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleWarranty")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("isBilled")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Records");
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

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("VehicleValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CarInsurance.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("CarInsurance.Models.Billing", b =>
                {
                    b.HasOne("CarInsurance.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("CarInsurance.Models.Claim", b =>
                {
                    b.HasOne("CarInsurance.Models.Billing", "Billing")
                        .WithMany()
                        .HasForeignKey("BillingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarInsurance.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Billing");
                });

            modelBuilder.Entity("CarInsurance.Models.Estimate", b =>
                {
                    b.HasOne("CarInsurance.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarInsurance.Models.Policy", "Policy")
                        .WithMany()
                        .HasForeignKey("PolicyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Policy");
                });

            modelBuilder.Entity("CarInsurance.Models.Record", b =>
                {
                    b.HasOne("CarInsurance.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("CarInsurance.Models.Vehicle", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
