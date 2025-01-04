using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kavim.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "streets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_streets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeOfBus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeOfBus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "stations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    StreetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_stations_streets_StreetId",
                        column: x => x.StreetId,
                        principalTable: "streets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "buses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<int>(type: "int", nullable: false),
                    TimingsId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    StationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_buses_TimeOfBus_TimingsId",
                        column: x => x.TimingsId,
                        principalTable: "TimeOfBus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_buses_stations_StationId",
                        column: x => x.StationId,
                        principalTable: "stations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StationAndi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusStopId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    BusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationAndi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StationAndi_buses_BusId",
                        column: x => x.BusId,
                        principalTable: "buses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StationAndi_stations_BusStopId",
                        column: x => x.BusStopId,
                        principalTable: "stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_buses_StationId",
                table: "buses",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_buses_TimingsId",
                table: "buses",
                column: "TimingsId");

            migrationBuilder.CreateIndex(
                name: "IX_StationAndi_BusId",
                table: "StationAndi",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_StationAndi_BusStopId",
                table: "StationAndi",
                column: "BusStopId");

            migrationBuilder.CreateIndex(
                name: "IX_stations_StreetId",
                table: "stations",
                column: "StreetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StationAndi");

            migrationBuilder.DropTable(
                name: "buses");

            migrationBuilder.DropTable(
                name: "TimeOfBus");

            migrationBuilder.DropTable(
                name: "stations");

            migrationBuilder.DropTable(
                name: "streets");
        }
    }
}
