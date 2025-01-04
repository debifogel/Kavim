using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kavim.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StationAndi_stations_BusStopId",
                table: "StationAndi");

            migrationBuilder.RenameColumn(
                name: "BusStopId",
                table: "StationAndi",
                newName: "StopId");

            migrationBuilder.RenameIndex(
                name: "IX_StationAndi_BusStopId",
                table: "StationAndi",
                newName: "IX_StationAndi_StopId");

            migrationBuilder.AddColumn<int>(
                name: "InOrder",
                table: "StationAndi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_StationAndi_stations_StopId",
                table: "StationAndi",
                column: "StopId",
                principalTable: "stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StationAndi_stations_StopId",
                table: "StationAndi");

            migrationBuilder.DropColumn(
                name: "InOrder",
                table: "StationAndi");

            migrationBuilder.RenameColumn(
                name: "StopId",
                table: "StationAndi",
                newName: "BusStopId");

            migrationBuilder.RenameIndex(
                name: "IX_StationAndi_StopId",
                table: "StationAndi",
                newName: "IX_StationAndi_BusStopId");

            migrationBuilder.AddForeignKey(
                name: "FK_StationAndi_stations_BusStopId",
                table: "StationAndi",
                column: "BusStopId",
                principalTable: "stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
