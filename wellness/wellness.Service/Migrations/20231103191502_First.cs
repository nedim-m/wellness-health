using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wellness.Service.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2023, 11, 3, 19, 15, 1, 797, DateTimeKind.Utc).AddTicks(9715), new DateTime(2023, 11, 3, 20, 15, 1, 797, DateTimeKind.Utc).AddTicks(9717) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2023, 11, 3, 19, 15, 1, 797, DateTimeKind.Utc).AddTicks(9893), new DateTime(2023, 11, 3, 20, 15, 1, 797, DateTimeKind.Utc).AddTicks(9894) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2023, 11, 3, 19, 15, 1, 798, DateTimeKind.Utc).AddTicks(56), new DateTime(2023, 11, 3, 20, 15, 1, 798, DateTimeKind.Utc).AddTicks(57) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2023, 10, 31, 7, 55, 42, 537, DateTimeKind.Utc).AddTicks(2589), new DateTime(2023, 10, 31, 8, 55, 42, 537, DateTimeKind.Utc).AddTicks(2593) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2023, 10, 31, 7, 55, 42, 537, DateTimeKind.Utc).AddTicks(2772), new DateTime(2023, 10, 31, 8, 55, 42, 537, DateTimeKind.Utc).AddTicks(2773) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2023, 10, 31, 7, 55, 42, 537, DateTimeKind.Utc).AddTicks(2937), new DateTime(2023, 10, 31, 8, 55, 42, 537, DateTimeKind.Utc).AddTicks(2938) });
        }
    }
}
