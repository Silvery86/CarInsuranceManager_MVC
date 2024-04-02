using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarInsurance.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddDatabaseAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
