using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wellness.Service.Migrations
{
    /// <inheritdoc />
    public partial class Removeuserandtreatmentfromratingfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 13, 17, 27, 51, 649, DateTimeKind.Utc).AddTicks(1236), new DateTime(2024, 2, 13, 18, 27, 51, 649, DateTimeKind.Utc).AddTicks(1239) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 13, 17, 27, 51, 649, DateTimeKind.Utc).AddTicks(1770), new DateTime(2024, 2, 13, 18, 27, 51, 649, DateTimeKind.Utc).AddTicks(1771) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 13, 17, 27, 51, 649, DateTimeKind.Utc).AddTicks(2229), new DateTime(2024, 2, 13, 18, 27, 51, 649, DateTimeKind.Utc).AddTicks(2230) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 13, 17, 26, 9, 749, DateTimeKind.Utc).AddTicks(1641), new DateTime(2024, 2, 13, 18, 26, 9, 749, DateTimeKind.Utc).AddTicks(1644) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 13, 17, 26, 9, 749, DateTimeKind.Utc).AddTicks(1883), new DateTime(2024, 2, 13, 18, 26, 9, 749, DateTimeKind.Utc).AddTicks(1884) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 13, 17, 26, 9, 749, DateTimeKind.Utc).AddTicks(2139), new DateTime(2024, 2, 13, 18, 26, 9, 749, DateTimeKind.Utc).AddTicks(2140) });
        }
    }
}
