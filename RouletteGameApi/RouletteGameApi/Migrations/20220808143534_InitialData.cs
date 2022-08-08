using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RouletteGameApi.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Payouts",
                columns: new[] { "PayoutId", "TimestampUtc" },
                values: new object[] { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), new DateTime(2022, 8, 8, 14, 35, 34, 390, DateTimeKind.Utc).AddTicks(1291) });

            migrationBuilder.InsertData(
                table: "Payouts",
                columns: new[] { "PayoutId", "TimestampUtc" },
                values: new object[] { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), new DateTime(2022, 8, 8, 14, 35, 34, 390, DateTimeKind.Utc).AddTicks(1293) });

            migrationBuilder.InsertData(
                table: "Spins",
                columns: new[] { "SpinId", "SpinResult", "TimestampUtc" },
                values: new object[] { new Guid("4d490a70-94ce-4d15-9494-5248280c2ce3"), 5L, new DateTime(2022, 8, 8, 14, 35, 34, 390, DateTimeKind.Utc).AddTicks(1140) });

            migrationBuilder.InsertData(
                table: "Spins",
                columns: new[] { "SpinId", "SpinResult", "TimestampUtc" },
                values: new object[] { new Guid("c8d4c053-49b6-410c-bc78-2d54a9891870"), 5L, new DateTime(2022, 8, 8, 14, 35, 34, 390, DateTimeKind.Utc).AddTicks(1137) });

            migrationBuilder.InsertData(
                table: "Bets",
                columns: new[] { "BetId", "BetOn", "BetValue", "BetWinnings", "PayoutId", "SpinId", "TimestampUtc" },
                values: new object[] { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "RED", 46.45m, 384.78m, new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), new Guid("4d490a70-94ce-4d15-9494-5248280c2ce3"), new DateTime(2022, 8, 8, 14, 35, 34, 390, DateTimeKind.Utc).AddTicks(1358) });

            migrationBuilder.InsertData(
                table: "Bets",
                columns: new[] { "BetId", "BetOn", "BetValue", "BetWinnings", "PayoutId", "SpinId", "TimestampUtc" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "HIGH", 50.62m, 560.20m, new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), new Guid("c8d4c053-49b6-410c-bc78-2d54a9891870"), new DateTime(2022, 8, 8, 14, 35, 34, 390, DateTimeKind.Utc).AddTicks(1354) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bets",
                keyColumn: "BetId",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.DeleteData(
                table: "Bets",
                keyColumn: "BetId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));

            migrationBuilder.DeleteData(
                table: "Payouts",
                keyColumn: "PayoutId",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"));

            migrationBuilder.DeleteData(
                table: "Payouts",
                keyColumn: "PayoutId",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"));

            migrationBuilder.DeleteData(
                table: "Spins",
                keyColumn: "SpinId",
                keyValue: new Guid("4d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.DeleteData(
                table: "Spins",
                keyColumn: "SpinId",
                keyValue: new Guid("c8d4c053-49b6-410c-bc78-2d54a9891870"));
        }
    }
}
