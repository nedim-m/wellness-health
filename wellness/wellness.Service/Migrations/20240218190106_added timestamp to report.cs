using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wellness.Service.Migrations
{
    /// <inheritdoc />
    public partial class addedtimestamptoreport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "Reports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Reports");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 16, 20, 59, 48, 721, DateTimeKind.Utc).AddTicks(4505), new DateTime(2024, 2, 16, 21, 59, 48, 721, DateTimeKind.Utc).AddTicks(4508) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 16, 20, 59, 48, 721, DateTimeKind.Utc).AddTicks(4632), new DateTime(2024, 2, 16, 21, 59, 48, 721, DateTimeKind.Utc).AddTicks(4632) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 16, 20, 59, 48, 721, DateTimeKind.Utc).AddTicks(4794), new DateTime(2024, 2, 16, 21, 59, 48, 721, DateTimeKind.Utc).AddTicks(4795) });
        }
    }
}
