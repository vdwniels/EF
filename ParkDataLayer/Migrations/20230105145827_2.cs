using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkDataLayer.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Huis_Park_ParkId1",
                table: "Huis");

            migrationBuilder.DropIndex(
                name: "IX_Huis_ParkId1",
                table: "Huis");

            migrationBuilder.DropColumn(
                name: "ParkId1",
                table: "Huis");

            migrationBuilder.AlterColumn<string>(
                name: "ParkId",
                table: "Huis",
                type: "nvarchar(20)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Huis_Park_ParkId",
                table: "Huis",
                column: "ParkId",
                principalTable: "Park",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Huis_Park_ParkId",
                table: "Huis");

            migrationBuilder.AlterColumn<int>(
                name: "ParkId",
                table: "Huis",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");

            migrationBuilder.AddColumn<string>(
                name: "ParkId1",
                table: "Huis",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Huis_ParkId1",
                table: "Huis",
                column: "ParkId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Huis_Park_ParkId1",
                table: "Huis",
                column: "ParkId1",
                principalTable: "Park",
                principalColumn: "Id");
        }
    }
}
