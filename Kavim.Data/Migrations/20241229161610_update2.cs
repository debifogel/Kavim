using System;
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
                name: "FK_buses_TimeOfBus_TimingsId",
                table: "buses");

            migrationBuilder.DropTable(
                name: "TimeOfBus");

            migrationBuilder.DropIndex(
                name: "IX_buses_TimingsId",
                table: "buses");

            migrationBuilder.DropColumn(
                name: "TimingsId",
                table: "buses");

            migrationBuilder.CreateTable(
                name: "Schdule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<int>(type: "int", nullable: false),
                    TimeStart = table.Column<TimeOnly>(type: "time", nullable: false),
                    TimeEnd = table.Column<TimeOnly>(type: "time", nullable: false),
                    frenquecy = table.Column<int>(type: "int", nullable: false),
                    BusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schdule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schdule_buses_BusId",
                        column: x => x.BusId,
                        principalTable: "buses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schdule_BusId",
                table: "Schdule",
                column: "BusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schdule");

            migrationBuilder.AddColumn<int>(
                name: "TimingsId",
                table: "buses",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_buses_TimingsId",
                table: "buses",
                column: "TimingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_buses_TimeOfBus_TimingsId",
                table: "buses",
                column: "TimingsId",
                principalTable: "TimeOfBus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
