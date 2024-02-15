using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wellness.Service.Migrations
{
    /// <inheritdoc />
    public partial class ChangefromfloattodecimalinReporttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "EarnedMoney",
                table: "Reports",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 15, 17, 1, 54, 206, DateTimeKind.Utc).AddTicks(1243), new DateTime(2024, 2, 15, 18, 1, 54, 206, DateTimeKind.Utc).AddTicks(1246) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 15, 17, 1, 54, 206, DateTimeKind.Utc).AddTicks(1486), new DateTime(2024, 2, 15, 18, 1, 54, 206, DateTimeKind.Utc).AddTicks(1486) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 15, 17, 1, 54, 206, DateTimeKind.Utc).AddTicks(1791), new DateTime(2024, 2, 15, 18, 1, 54, 206, DateTimeKind.Utc).AddTicks(1792) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "EarnedMoney",
                table: "Reports",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 15, 16, 13, 31, 963, DateTimeKind.Utc).AddTicks(5519), new DateTime(2024, 2, 15, 17, 13, 31, 963, DateTimeKind.Utc).AddTicks(5522) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 15, 16, 13, 31, 963, DateTimeKind.Utc).AddTicks(5809), new DateTime(2024, 2, 15, 17, 13, 31, 963, DateTimeKind.Utc).AddTicks(5810) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 15, 16, 13, 31, 963, DateTimeKind.Utc).AddTicks(6071), new DateTime(2024, 2, 15, 17, 13, 31, 963, DateTimeKind.Utc).AddTicks(6072) });
        }
    }
}
