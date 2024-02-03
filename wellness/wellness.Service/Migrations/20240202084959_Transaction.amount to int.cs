using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wellness.Service.Migrations
{
    /// <inheritdoc />
    public partial class Transactionamounttoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { new DateTime(2024, 1, 28, 14, 39, 11, 148, DateTimeKind.Utc).AddTicks(5762), new DateTime(2024, 1, 28, 15, 39, 11, 148, DateTimeKind.Utc).AddTicks(5764) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 1, 28, 14, 39, 11, 148, DateTimeKind.Utc).AddTicks(6262), new DateTime(2024, 1, 28, 15, 39, 11, 148, DateTimeKind.Utc).AddTicks(6263) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 1, 28, 14, 39, 11, 148, DateTimeKind.Utc).AddTicks(6386), new DateTime(2024, 1, 28, 15, 39, 11, 148, DateTimeKind.Utc).AddTicks(6386) });
        }
    }
}
