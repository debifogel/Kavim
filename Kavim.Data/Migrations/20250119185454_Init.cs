﻿using System;
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
                name: "buses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "streets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_streets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schdule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusId = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    TimeStart = table.Column<TimeOnly>(type: "time", nullable: false),
                    TimeEnd = table.Column<TimeOnly>(type: "time", nullable: false),
                    frenquecy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schdule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schdule_buses_BusId",
                        column: x => x.BusId,
                        principalTable: "buses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    InStreetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_stations_streets_InStreetId",
                        column: x => x.InStreetId,
                        principalTable: "streets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StationAndi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    InOrder = table.Column<int>(type: "int", nullable: false),
                    StopId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_StationAndi_stations_StopId",
                        column: x => x.StopId,
                        principalTable: "stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schdule_BusId",
                table: "Schdule",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_StationAndi_BusId",
                table: "StationAndi",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_StationAndi_StopId",
                table: "StationAndi",
                column: "StopId");

            migrationBuilder.CreateIndex(
                name: "IX_stations_InStreetId",
                table: "stations",
                column: "InStreetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schdule");

            migrationBuilder.DropTable(
                name: "StationAndi");

            migrationBuilder.DropTable(
                name: "buses");

            migrationBuilder.DropTable(
                name: "stations");

            migrationBuilder.DropTable(
                name: "streets");
        }
    }
}
