using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travellers.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Mig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightTickets_Categories_CategoryId",
                table: "FlightTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightTickets_Tours_TourId",
                table: "FlightTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Categories_CategoryId",
                table: "Hotels");

            migrationBuilder.CreateTable(
                name: "WinterHolidays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    HotelName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Region = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    AccommodationType = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    FacilityAmenities = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    DateOfEntry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WinterHolidays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WinterHolidays_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WinterHolidays_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WinterHolidays_CategoryId",
                table: "WinterHolidays",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WinterHolidays_TourId",
                table: "WinterHolidays",
                column: "TourId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightTickets_Categories_CategoryId",
                table: "FlightTickets",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightTickets_Tours_TourId",
                table: "FlightTickets",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Categories_CategoryId",
                table: "Hotels",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightTickets_Categories_CategoryId",
                table: "FlightTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightTickets_Tours_TourId",
                table: "FlightTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Categories_CategoryId",
                table: "Hotels");

            migrationBuilder.DropTable(
                name: "WinterHolidays");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightTickets_Categories_CategoryId",
                table: "FlightTickets",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightTickets_Tours_TourId",
                table: "FlightTickets",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Categories_CategoryId",
                table: "Hotels",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
