using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarInsuranceManagerWeb.Migrations
{
    /// <inheritdoc />
    public partial class SeedVehicleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "BodyNumber", "EngineNumber", "Model", "Name", "Number", "OwnerName", "Rate", "Version" },
                values: new object[,]
                {
                    { 1, "ABC123", "XYZ789", "Ecosport", "Ford", "30A8686T", "Giang", 5, "2015" },
                    { 2, "ABC456", "XYZ123", "Vios", "Toyota", "30A9999T", "Hoang", 8, "2023" },
                    { 3, "ABC789", "XYZ789", "G63", "MecedesBenz", "30A6789T", "Nam", 15, "2023" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
