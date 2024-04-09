using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarInsurance.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addRecordModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Version",
                table: "Estimates",
                newName: "VehicleVersion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VehicleVersion",
                table: "Estimates",
                newName: "Version");
        }
    }
}
