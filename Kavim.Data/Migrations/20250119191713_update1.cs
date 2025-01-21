using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kavim.Data.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StationId",
                table: "buses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_buses_StationId",
                table: "buses",
                column: "StationId");

            migrationBuilder.AddForeignKey(
                name: "FK_buses_stations_StationId",
                table: "buses",
                column: "StationId",
                principalTable: "stations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_buses_stations_StationId",
                table: "buses");

            migrationBuilder.DropIndex(
                name: "IX_buses_StationId",
                table: "buses");

            migrationBuilder.DropColumn(
                name: "StationId",
                table: "buses");
        }
    }
}
