using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wellness.Service.Migrations
{
    /// <inheritdoc />
    public partial class ChangeamountfrominttodecimalTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 13, 9, 21, 9, 857, DateTimeKind.Utc).AddTicks(7749), new DateTime(2024, 2, 13, 10, 21, 9, 857, DateTimeKind.Utc).AddTicks(7753) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 13, 9, 21, 9, 857, DateTimeKind.Utc).AddTicks(8101), new DateTime(2024, 2, 13, 10, 21, 9, 857, DateTimeKind.Utc).AddTicks(8102) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 13, 9, 21, 9, 857, DateTimeKind.Utc).AddTicks(8423), new DateTime(2024, 2, 13, 10, 21, 9, 857, DateTimeKind.Utc).AddTicks(8425) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Transactions",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 2, 8, 49, 58, 686, DateTimeKind.Utc).AddTicks(1232), new DateTime(2024, 2, 2, 9, 49, 58, 686, DateTimeKind.Utc).AddTicks(1234) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 2, 8, 49, 58, 686, DateTimeKind.Utc).AddTicks(1582), new DateTime(2024, 2, 2, 9, 49, 58, 686, DateTimeKind.Utc).AddTicks(1582) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 2, 8, 49, 58, 686, DateTimeKind.Utc).AddTicks(1865), new DateTime(2024, 2, 2, 9, 49, 58, 686, DateTimeKind.Utc).AddTicks(1865) });
        }
    }
}
