using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarInsurance.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addClaimModeltoDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BillingId = table.Column<int>(type: "int", nullable: false),
                    BillNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehiclePolicyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PolicyStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PolicyEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PolicyDuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VehicleModel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VehicleNumber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    VehicleVersion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VehicleRate = table.Column<int>(type: "int", nullable: false),
                    VehicleWarranty = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    InsuranceCost = table.Column<double>(type: "float", nullable: false),
                    PlaceOfAccident = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DateOfAccident = table.Column<DateTime>(type: "datetime2", maxLength: 200, nullable: false),
                    InsuranceAmount = table.Column<double>(type: "float", nullable: false),
                    ClaimableAmount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Claims_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Claims_Billings_BillingId",
                        column: x => x.BillingId,
                        principalTable: "Billings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Claims_BillingId",
                table: "Claims",
                column: "BillingId");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_CustomerId",
                table: "Claims",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claims");
        }
    }
}
