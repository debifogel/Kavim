using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kavim.Data.Migrations
{
    /// <inheritdoc />
    public partial class update6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "BusStation",
                columns: table => new
                {
                    BusInStationId = table.Column<int>(type: "int", nullable: false),
                    ListofstationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusStation", x => new { x.BusInStationId, x.ListofstationsId });
                    table.ForeignKey(
                        name: "FK_BusStation_buses_BusInStationId",
                        column: x => x.BusInStationId,
                        principalTable: "buses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusStation_stations_ListofstationsId",
                        column: x => x.ListofstationsId,
                        principalTable: "stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusStation_ListofstationsId",
                table: "BusStation",
                column: "ListofstationsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusStation");

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
    }
}
