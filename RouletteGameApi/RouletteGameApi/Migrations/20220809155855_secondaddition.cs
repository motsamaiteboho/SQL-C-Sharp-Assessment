using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RouletteGameApi.Migrations
{
    public partial class secondaddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Payouts_PayoutId",
                table: "Bets");

            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Spins_SpinId",
                table: "Bets");

            migrationBuilder.DropIndex(
                name: "IX_Bets_PayoutId",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "BetWinnings",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "PayoutId",
                table: "Bets");

            migrationBuilder.AddColumn<Guid>(
                name: "BetId",
                table: "Payouts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPayout",
                table: "Payouts",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<Guid>(
                name: "SpinId",
                table: "Bets",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "Bets",
                keyColumn: "BetId",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                column: "TimestampUtc",
                value: new DateTime(2022, 8, 9, 15, 58, 54, 334, DateTimeKind.Utc).AddTicks(7210));

            migrationBuilder.UpdateData(
                table: "Bets",
                keyColumn: "BetId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                column: "TimestampUtc",
                value: new DateTime(2022, 8, 9, 15, 58, 54, 334, DateTimeKind.Utc).AddTicks(7207));

            migrationBuilder.UpdateData(
                table: "Payouts",
                keyColumn: "PayoutId",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                columns: new[] { "BetId", "TimestampUtc", "TotalPayout" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new DateTime(2022, 8, 9, 15, 58, 54, 334, DateTimeKind.Utc).AddTicks(7131), 522.5m });

            migrationBuilder.UpdateData(
                table: "Payouts",
                keyColumn: "PayoutId",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                columns: new[] { "BetId", "TimestampUtc", "TotalPayout" },
                values: new object[] { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new DateTime(2022, 8, 9, 15, 58, 54, 334, DateTimeKind.Utc).AddTicks(7133), 145.5m });

            migrationBuilder.UpdateData(
                table: "Spins",
                keyColumn: "SpinId",
                keyValue: new Guid("4d490a70-94ce-4d15-9494-5248280c2ce3"),
                columns: new[] { "SpinResult", "TimestampUtc" },
                values: new object[] { 7L, new DateTime(2022, 8, 9, 15, 58, 54, 334, DateTimeKind.Utc).AddTicks(6951) });

            migrationBuilder.UpdateData(
                table: "Spins",
                keyColumn: "SpinId",
                keyValue: new Guid("c8d4c053-49b6-410c-bc78-2d54a9891870"),
                column: "TimestampUtc",
                value: new DateTime(2022, 8, 9, 15, 58, 54, 334, DateTimeKind.Utc).AddTicks(6946));

            migrationBuilder.CreateIndex(
                name: "IX_Payouts_BetId",
                table: "Payouts",
                column: "BetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Spins_SpinId",
                table: "Bets",
                column: "SpinId",
                principalTable: "Spins",
                principalColumn: "SpinId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payouts_Bets_BetId",
                table: "Payouts",
                column: "BetId",
                principalTable: "Bets",
                principalColumn: "BetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Spins_SpinId",
                table: "Bets");

            migrationBuilder.DropForeignKey(
                name: "FK_Payouts_Bets_BetId",
                table: "Payouts");

            migrationBuilder.DropIndex(
                name: "IX_Payouts_BetId",
                table: "Payouts");

            migrationBuilder.DropColumn(
                name: "BetId",
                table: "Payouts");

            migrationBuilder.DropColumn(
                name: "TotalPayout",
                table: "Payouts");

            migrationBuilder.AlterColumn<Guid>(
                name: "SpinId",
                table: "Bets",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BetWinnings",
                table: "Bets",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PayoutId",
                table: "Bets",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Bets",
                keyColumn: "BetId",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                columns: new[] { "BetWinnings", "PayoutId", "TimestampUtc" },
                values: new object[] { 384.78m, new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), new DateTime(2022, 8, 8, 14, 35, 34, 390, DateTimeKind.Utc).AddTicks(1358) });

            migrationBuilder.UpdateData(
                table: "Bets",
                keyColumn: "BetId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                columns: new[] { "BetWinnings", "PayoutId", "TimestampUtc" },
                values: new object[] { 560.20m, new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), new DateTime(2022, 8, 8, 14, 35, 34, 390, DateTimeKind.Utc).AddTicks(1354) });

            migrationBuilder.UpdateData(
                table: "Payouts",
                keyColumn: "PayoutId",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                column: "TimestampUtc",
                value: new DateTime(2022, 8, 8, 14, 35, 34, 390, DateTimeKind.Utc).AddTicks(1291));

            migrationBuilder.UpdateData(
                table: "Payouts",
                keyColumn: "PayoutId",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                column: "TimestampUtc",
                value: new DateTime(2022, 8, 8, 14, 35, 34, 390, DateTimeKind.Utc).AddTicks(1293));

            migrationBuilder.UpdateData(
                table: "Spins",
                keyColumn: "SpinId",
                keyValue: new Guid("4d490a70-94ce-4d15-9494-5248280c2ce3"),
                columns: new[] { "SpinResult", "TimestampUtc" },
                values: new object[] { 5L, new DateTime(2022, 8, 8, 14, 35, 34, 390, DateTimeKind.Utc).AddTicks(1140) });

            migrationBuilder.UpdateData(
                table: "Spins",
                keyColumn: "SpinId",
                keyValue: new Guid("c8d4c053-49b6-410c-bc78-2d54a9891870"),
                column: "TimestampUtc",
                value: new DateTime(2022, 8, 8, 14, 35, 34, 390, DateTimeKind.Utc).AddTicks(1137));

            migrationBuilder.CreateIndex(
                name: "IX_Bets_PayoutId",
                table: "Bets",
                column: "PayoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Payouts_PayoutId",
                table: "Bets",
                column: "PayoutId",
                principalTable: "Payouts",
                principalColumn: "PayoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Spins_SpinId",
                table: "Bets",
                column: "SpinId",
                principalTable: "Spins",
                principalColumn: "SpinId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
