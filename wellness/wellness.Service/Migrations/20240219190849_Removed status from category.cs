using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wellness.Service.Migrations
{
    /// <inheritdoc />
    public partial class Removedstatusfromcategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 19, 19, 8, 48, 654, DateTimeKind.Utc).AddTicks(6338), new DateTime(2024, 2, 19, 20, 8, 48, 654, DateTimeKind.Utc).AddTicks(6340) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 19, 19, 8, 48, 654, DateTimeKind.Utc).AddTicks(6522), new DateTime(2024, 2, 19, 20, 8, 48, 654, DateTimeKind.Utc).AddTicks(6522) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 19, 19, 8, 48, 654, DateTimeKind.Utc).AddTicks(6689), new DateTime(2024, 2, 19, 20, 8, 48, 654, DateTimeKind.Utc).AddTicks(6689) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 18, 19, 1, 5, 641, DateTimeKind.Utc).AddTicks(4573), new DateTime(2024, 2, 18, 20, 1, 5, 641, DateTimeKind.Utc).AddTicks(4577) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 18, 19, 1, 5, 641, DateTimeKind.Utc).AddTicks(4742), new DateTime(2024, 2, 18, 20, 1, 5, 641, DateTimeKind.Utc).AddTicks(4743) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 18, 19, 1, 5, 641, DateTimeKind.Utc).AddTicks(4961), new DateTime(2024, 2, 18, 20, 1, 5, 641, DateTimeKind.Utc).AddTicks(4962) });
        }
    }
}
