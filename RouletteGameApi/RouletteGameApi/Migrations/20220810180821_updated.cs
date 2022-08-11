using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RouletteGameApi.Migrations
{
    public partial class updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Payouts_BetId",
                table: "Payouts");

            migrationBuilder.AddColumn<Guid>(
                name: "BetId",
                table: "Spins",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Bets",
                keyColumn: "BetId",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                columns: new[] { "SpinId", "TimestampUtc" },
                values: new object[] { null, new DateTime(2022, 8, 10, 18, 8, 20, 324, DateTimeKind.Utc).AddTicks(554) });

            migrationBuilder.UpdateData(
                table: "Bets",
                keyColumn: "BetId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                columns: new[] { "SpinId", "TimestampUtc" },
                values: new object[] { null, new DateTime(2022, 8, 10, 18, 8, 20, 324, DateTimeKind.Utc).AddTicks(552) });

            migrationBuilder.UpdateData(
                table: "Payouts",
                keyColumn: "PayoutId",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                column: "TimestampUtc",
                value: new DateTime(2022, 8, 10, 18, 8, 20, 324, DateTimeKind.Utc).AddTicks(481));

            migrationBuilder.UpdateData(
                table: "Payouts",
                keyColumn: "PayoutId",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                column: "TimestampUtc",
                value: new DateTime(2022, 8, 10, 18, 8, 20, 324, DateTimeKind.Utc).AddTicks(485));

            migrationBuilder.UpdateData(
                table: "Spins",
                keyColumn: "SpinId",
                keyValue: new Guid("4d490a70-94ce-4d15-9494-5248280c2ce3"),
                columns: new[] { "BetId", "TimestampUtc" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new DateTime(2022, 8, 10, 18, 8, 20, 324, DateTimeKind.Utc).AddTicks(268) });

            migrationBuilder.UpdateData(
                table: "Spins",
                keyColumn: "SpinId",
                keyValue: new Guid("c8d4c053-49b6-410c-bc78-2d54a9891870"),
                columns: new[] { "BetId", "TimestampUtc" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new DateTime(2022, 8, 10, 18, 8, 20, 324, DateTimeKind.Utc).AddTicks(262) });

            migrationBuilder.CreateIndex(
                name: "IX_Payouts_BetId",
                table: "Payouts",
                column: "BetId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Payouts_BetId",
                table: "Payouts");

            migrationBuilder.DropColumn(
                name: "BetId",
                table: "Spins");

            migrationBuilder.UpdateData(
                table: "Bets",
                keyColumn: "BetId",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                columns: new[] { "SpinId", "TimestampUtc" },
                values: new object[] { new Guid("4d490a70-94ce-4d15-9494-5248280c2ce3"), new DateTime(2022, 8, 9, 16, 42, 17, 584, DateTimeKind.Utc).AddTicks(8380) });

            migrationBuilder.UpdateData(
                table: "Bets",
                keyColumn: "BetId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                columns: new[] { "SpinId", "TimestampUtc" },
                values: new object[] { new Guid("c8d4c053-49b6-410c-bc78-2d54a9891870"), new DateTime(2022, 8, 9, 16, 42, 17, 584, DateTimeKind.Utc).AddTicks(8375) });

            migrationBuilder.UpdateData(
                table: "Payouts",
                keyColumn: "PayoutId",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                column: "TimestampUtc",
                value: new DateTime(2022, 8, 9, 16, 42, 17, 584, DateTimeKind.Utc).AddTicks(8031));

            migrationBuilder.UpdateData(
                table: "Payouts",
                keyColumn: "PayoutId",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                column: "TimestampUtc",
                value: new DateTime(2022, 8, 9, 16, 42, 17, 584, DateTimeKind.Utc).AddTicks(8038));

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
                name: "IX_Payouts_BetId",
                table: "Payouts",
                column: "BetId");
        }
    }
}
