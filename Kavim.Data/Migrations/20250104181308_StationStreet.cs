using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kavim.Data.Migrations
{
    /// <inheritdoc />
    public partial class StationStreet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stations_streets_StreetId",
                table: "stations");

            migrationBuilder.DropIndex(
                name: "IX_stations_StreetId",
                table: "stations");

            migrationBuilder.DropColumn(
                name: "StreetId",
                table: "stations");

            migrationBuilder.AddColumn<int>(
                name: "StreetIdId",
                table: "stations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_stations_StreetIdId",
                table: "stations",
                column: "StreetIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_stations_streets_StreetIdId",
                table: "stations",
                column: "StreetIdId",
                principalTable: "streets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stations_streets_StreetIdId",
                table: "stations");

            migrationBuilder.DropIndex(
                name: "IX_stations_StreetIdId",
                table: "stations");

            migrationBuilder.DropColumn(
                name: "StreetIdId",
                table: "stations");

            migrationBuilder.AddColumn<int>(
                name: "StreetId",
                table: "stations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_stations_StreetId",
                table: "stations",
                column: "StreetId");

            migrationBuilder.AddForeignKey(
                name: "FK_stations_streets_StreetId",
                table: "stations",
                column: "StreetId",
                principalTable: "streets",
                principalColumn: "Id");
        }
    }
}
