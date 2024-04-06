using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarInsurance.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Warranty = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BaseCost = table.Column<double>(type: "float", nullable: false),
                    AnnualCost = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    BodyNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    EngineNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Policies",
                columns: new[] { "Id", "AnnualCost", "BaseCost", "Description", "Name", "Warranty" },
                values: new object[,]
                {
                    { 1, 0.25, 70.0, "Basic Insurance Policy", "Basic", "Damage third-party vehicle,Own Damage Theft" },
                    { 2, 0.27000000000000002, 90.0, "Standard Insurance Policy", "Standard", "Damage third-party vehicle,Own Damage Theft,Damage due to fire,Naturaly damage" },
                    { 3, 0.28999999999999998, 120.0, "Extended Insurance Policy", "Extended", "Damage third-party vehicle,Own Damage Theft,Damage due to fire,Naturaly damage,Personal Accident cover" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "BodyNumber", "EngineNumber", "Model", "Name", "Number", "OwnerName", "Rate", "VehicleValue", "Version" },
                values: new object[,]
                {
                    { 1, "ABC123", "XYZ789", "Ecosport", "Ford", "30A8686T", "Giang", 50, 20000m, "2015" },
                    { 2, "ABC456", "XYZ123", "Vios", "Toyota", "30A9999T", "Hoang", 100, 50000m, "2023" },
                    { 3, "ABC789", "XYZ789", "G63", "MecedesBenz", "30A6789T", "Nam", 70, 100000m, "2023" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
