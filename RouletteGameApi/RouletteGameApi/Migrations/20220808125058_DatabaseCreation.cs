using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RouletteGameApi.Migrations
{
    public partial class DatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payouts",
                columns: table => new
                {
                    PayoutId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TimestampUtc = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payouts", x => x.PayoutId);
                });

            migrationBuilder.CreateTable(
                name: "Spins",
                columns: table => new
                {
                    SpinId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SpinResult = table.Column<long>(type: "INTEGER", nullable: true),
                    TimestampUtc = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spins", x => x.SpinId);
                });

            migrationBuilder.CreateTable(
                name: "Bets",
                columns: table => new
                {
                    BetId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BetOn = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    TimestampUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BetValue = table.Column<decimal>(type: "decimal(8, 2)", nullable: false),
                    BetWinnings = table.Column<decimal>(type: "TEXT", nullable: true),
                    PayoutId = table.Column<Guid>(type: "TEXT", nullable: true),
                    SpinId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bets", x => x.BetId);
                    table.ForeignKey(
                        name: "FK_Bets_Payouts_PayoutId",
                        column: x => x.PayoutId,
                        principalTable: "Payouts",
                        principalColumn: "PayoutId");
                    table.ForeignKey(
                        name: "FK_Bets_Spins_SpinId",
                        column: x => x.SpinId,
                        principalTable: "Spins",
                        principalColumn: "SpinId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bets_PayoutId",
                table: "Bets",
                column: "PayoutId");

            migrationBuilder.CreateIndex(
                name: "IX_Bets_SpinId",
                table: "Bets",
                column: "SpinId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bets");

            migrationBuilder.DropTable(
                name: "Payouts");

            migrationBuilder.DropTable(
                name: "Spins");
        }
    }
}
