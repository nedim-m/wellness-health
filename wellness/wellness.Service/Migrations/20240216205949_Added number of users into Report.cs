using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wellness.Service.Migrations
{
    /// <inheritdoc />
    public partial class AddednumberofusersintoReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalUsers",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalUsers",
                table: "Reports");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 16, 20, 28, 1, 161, DateTimeKind.Utc).AddTicks(3687), new DateTime(2024, 2, 16, 21, 28, 1, 161, DateTimeKind.Utc).AddTicks(3690) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 16, 20, 28, 1, 161, DateTimeKind.Utc).AddTicks(3870), new DateTime(2024, 2, 16, 21, 28, 1, 161, DateTimeKind.Utc).AddTicks(3871) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 16, 20, 28, 1, 161, DateTimeKind.Utc).AddTicks(4095), new DateTime(2024, 2, 16, 21, 28, 1, 161, DateTimeKind.Utc).AddTicks(4095) });
        }
    }
}
