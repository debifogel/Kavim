using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kavim.Data.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_buses_stations_StationId",
                table: "buses");

            migrationBuilder.DropForeignKey(
                name: "FK_StationAndi_buses_BusId",
                table: "StationAndi");

            migrationBuilder.DropIndex(
                name: "IX_StationAndi_BusId",
                table: "StationAndi");

            migrationBuilder.DropIndex(
                name: "IX_buses_StationId",
                table: "buses");

            migrationBuilder.DropColumn(
                name: "BusId",
                table: "StationAndi");

            migrationBuilder.DropColumn(
                name: "StationId",
                table: "buses");

            migrationBuilder.AddColumn<int>(
                name: "_BusId",
                table: "StationAndi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StationAndi__BusId",
                table: "StationAndi",
                column: "_BusId");

            migrationBuilder.AddForeignKey(
                name: "FK_StationAndi_buses__BusId",
                table: "StationAndi",
                column: "_BusId",
                principalTable: "buses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StationAndi_buses__BusId",
                table: "StationAndi");

            migrationBuilder.DropIndex(
                name: "IX_StationAndi__BusId",
                table: "StationAndi");

            migrationBuilder.DropColumn(
                name: "_BusId",
                table: "StationAndi");

            migrationBuilder.AddColumn<int>(
                name: "BusId",
                table: "StationAndi",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StationId",
                table: "buses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StationAndi_BusId",
                table: "StationAndi",
                column: "BusId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_StationAndi_buses_BusId",
                table: "StationAndi",
                column: "BusId",
                principalTable: "buses",
                principalColumn: "Id");
        }
    }
}
