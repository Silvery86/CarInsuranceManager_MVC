using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarInsurance.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateEstimateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VehicleNumber",
                table: "Estimates",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "VehicleValue",
                table: "Estimates",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Version",
                table: "Estimates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleNumber",
                table: "Estimates");

            migrationBuilder.DropColumn(
                name: "VehicleValue",
                table: "Estimates");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Estimates");
        }
    }
}
