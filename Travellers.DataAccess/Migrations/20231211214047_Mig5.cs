using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travellers.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TourId",
                table: "FlightTickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FlightTickets_TourId",
                table: "FlightTickets",
                column: "TourId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightTickets_Tours_TourId",
                table: "FlightTickets",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightTickets_Tours_TourId",
                table: "FlightTickets");

            migrationBuilder.DropIndex(
                name: "IX_FlightTickets_TourId",
                table: "FlightTickets");

            migrationBuilder.DropColumn(
                name: "TourId",
                table: "FlightTickets");
        }
    }
}
