using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkDataLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Huurder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huurder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Park",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    Locatie = table.Column<string>(type: "nvarchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Park", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Huis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Straat = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Nr = table.Column<int>(type: "int", nullable: false),
                    Actief = table.Column<bool>(type: "bit", nullable: false),
                    ParkId = table.Column<int>(type: "int", nullable: false),
                    ParkId1 = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Huis_Park_ParkId1",
                        column: x => x.ParkId1,
                        principalTable: "Park",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HuurContract",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    StartDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EindDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Aantaldagen = table.Column<int>(type: "int", nullable: false),
                    HuurderId = table.Column<int>(type: "int", nullable: false),
                    HuisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HuurContract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HuurContract_Huis_HuisId",
                        column: x => x.HuisId,
                        principalTable: "Huis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HuurContract_Huurder_HuurderId",
                        column: x => x.HuurderId,
                        principalTable: "Huurder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Huis_ParkId",
                table: "Huis",
                column: "ParkId");

            migrationBuilder.CreateIndex(
                name: "IX_Huis_ParkId1",
                table: "Huis",
                column: "ParkId1");

            migrationBuilder.CreateIndex(
                name: "IX_HuurContract_HuisId",
                table: "HuurContract",
                column: "HuisId");

            migrationBuilder.CreateIndex(
                name: "IX_HuurContract_HuurderId",
                table: "HuurContract",
                column: "HuurderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HuurContract");

            migrationBuilder.DropTable(
                name: "Huis");

            migrationBuilder.DropTable(
                name: "Huurder");

            migrationBuilder.DropTable(
                name: "Park");
        }
    }
}
