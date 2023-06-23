using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pallets",
                columns: table => new
                {
                    PalletID = table.Column<Guid>(type: "uuid", nullable: false),
                    PalletWidth = table.Column<double>(type: "double precision", nullable: false),
                    PalletHeight = table.Column<double>(type: "double precision", nullable: false),
                    PalletDepth = table.Column<double>(type: "double precision", nullable: false),
                    PalletWeight = table.Column<double>(type: "double precision", nullable: false),
                    PalletVolume = table.Column<double>(type: "double precision", nullable: false),
                    PalletExpirationDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pallets", x => x.PalletID);
                });

            migrationBuilder.CreateTable(
                name: "Boxes",
                columns: table => new
                {
                    BoxID = table.Column<Guid>(type: "uuid", nullable: false),
                    PalletID = table.Column<Guid>(type: "uuid", nullable: false),
                    BoxWidth = table.Column<double>(type: "double precision", nullable: false),
                    BoxHeight = table.Column<double>(type: "double precision", nullable: false),
                    BoxDepth = table.Column<double>(type: "double precision", nullable: false),
                    BoxWeight = table.Column<double>(type: "double precision", nullable: false),
                    BoxVolume = table.Column<double>(type: "double precision", nullable: false),
                    BoxExpirationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    BoxProductionDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boxes", x => x.BoxID);
                    table.ForeignKey(
                        name: "FK_Boxes_Pallets_PalletID",
                        column: x => x.PalletID,
                        principalTable: "Pallets",
                        principalColumn: "PalletID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boxes_PalletID",
                table: "Boxes",
                column: "PalletID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boxes");

            migrationBuilder.DropTable(
                name: "Pallets");
        }
    }
}
