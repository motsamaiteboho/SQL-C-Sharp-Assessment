using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RouletteGameApi.Migrations
{
    public partial class updatemigratt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SpinId",
                table: "Payouts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Bets",
                keyColumn: "BetId",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                column: "TimestampUtc",
                value: new DateTime(2022, 8, 9, 16, 42, 17, 584, DateTimeKind.Utc).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "Bets",
                keyColumn: "BetId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                column: "TimestampUtc",
                value: new DateTime(2022, 8, 9, 16, 42, 17, 584, DateTimeKind.Utc).AddTicks(8375));

            migrationBuilder.UpdateData(
                table: "Payouts",
                keyColumn: "PayoutId",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                columns: new[] { "SpinId", "TimestampUtc" },
                values: new object[] { new Guid("c8d4c053-49b6-410c-bc78-2d54a9891870"), new DateTime(2022, 8, 9, 16, 42, 17, 584, DateTimeKind.Utc).AddTicks(8031) });

            migrationBuilder.UpdateData(
                table: "Payouts",
                keyColumn: "PayoutId",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                columns: new[] { "SpinId", "TimestampUtc" },
                values: new object[] { new Guid("4d490a70-94ce-4d15-9494-5248280c2ce3"), new DateTime(2022, 8, 9, 16, 42, 17, 584, DateTimeKind.Utc).AddTicks(8038) });

            migrationBuilder.UpdateData(
                table: "Spins",
                keyColumn: "SpinId",
                keyValue: new Guid("4d490a70-94ce-4d15-9494-5248280c2ce3"),
                column: "TimestampUtc",
                value: new DateTime(2022, 8, 9, 16, 42, 17, 584, DateTimeKind.Utc).AddTicks(7238));

            migrationBuilder.UpdateData(
                table: "Spins",
                keyColumn: "SpinId",
                keyValue: new Guid("c8d4c053-49b6-410c-bc78-2d54a9891870"),
                column: "TimestampUtc",
                value: new DateTime(2022, 8, 9, 16, 42, 17, 584, DateTimeKind.Utc).AddTicks(7225));

            migrationBuilder.CreateIndex(
                name: "IX_Payouts_SpinId",
                table: "Payouts",
                column: "SpinId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payouts_Spins_SpinId",
                table: "Payouts",
                column: "SpinId",
                principalTable: "Spins",
                principalColumn: "SpinId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payouts_Spins_SpinId",
                table: "Payouts");

            migrationBuilder.DropIndex(
                name: "IX_Payouts_SpinId",
                table: "Payouts");

            migrationBuilder.DropColumn(
                name: "SpinId",
                table: "Payouts");

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
                column: "TimestampUtc",
                value: new DateTime(2022, 8, 9, 15, 58, 54, 334, DateTimeKind.Utc).AddTicks(7131));

            migrationBuilder.UpdateData(
                table: "Payouts",
                keyColumn: "PayoutId",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                column: "TimestampUtc",
                value: new DateTime(2022, 8, 9, 15, 58, 54, 334, DateTimeKind.Utc).AddTicks(7133));

            migrationBuilder.UpdateData(
                table: "Spins",
                keyColumn: "SpinId",
                keyValue: new Guid("4d490a70-94ce-4d15-9494-5248280c2ce3"),
                column: "TimestampUtc",
                value: new DateTime(2022, 8, 9, 15, 58, 54, 334, DateTimeKind.Utc).AddTicks(6951));

            migrationBuilder.UpdateData(
                table: "Spins",
                keyColumn: "SpinId",
                keyValue: new Guid("c8d4c053-49b6-410c-bc78-2d54a9891870"),
                column: "TimestampUtc",
                value: new DateTime(2022, 8, 9, 15, 58, 54, 334, DateTimeKind.Utc).AddTicks(6946));
        }
    }
}
