using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wellness.Service.Migrations
{
    /// <inheritdoc />
    public partial class ReservationfromdateTimetostring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2023, 12, 20, 17, 47, 16, 379, DateTimeKind.Utc).AddTicks(1608), new DateTime(2023, 12, 20, 18, 47, 16, 379, DateTimeKind.Utc).AddTicks(1611) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2023, 12, 20, 17, 47, 16, 379, DateTimeKind.Utc).AddTicks(1796), new DateTime(2023, 12, 20, 18, 47, 16, 379, DateTimeKind.Utc).AddTicks(1797) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2023, 12, 20, 17, 47, 16, 379, DateTimeKind.Utc).AddTicks(2235), new DateTime(2023, 12, 20, 18, 47, 16, 379, DateTimeKind.Utc).AddTicks(2236) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2023, 12, 17, 19, 55, 11, 554, DateTimeKind.Utc).AddTicks(1694), new DateTime(2023, 12, 17, 20, 55, 11, 554, DateTimeKind.Utc).AddTicks(1697) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2023, 12, 17, 19, 55, 11, 554, DateTimeKind.Utc).AddTicks(1942), new DateTime(2023, 12, 17, 20, 55, 11, 554, DateTimeKind.Utc).AddTicks(1942) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2023, 12, 17, 19, 55, 11, 554, DateTimeKind.Utc).AddTicks(2124), new DateTime(2023, 12, 17, 20, 55, 11, 554, DateTimeKind.Utc).AddTicks(2124) });
        }
    }
}
