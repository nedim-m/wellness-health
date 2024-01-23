using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wellness.Service.Migrations
{
    /// <inheritdoc />
    public partial class changedateTimetostringinMembership : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StartDate",
                table: "Memberships",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "ExpirationDate",
                table: "Memberships",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 1, 23, 19, 57, 48, 472, DateTimeKind.Utc).AddTicks(3087), new DateTime(2024, 1, 23, 20, 57, 48, 472, DateTimeKind.Utc).AddTicks(3090) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 1, 23, 19, 57, 48, 472, DateTimeKind.Utc).AddTicks(3534), new DateTime(2024, 1, 23, 20, 57, 48, 472, DateTimeKind.Utc).AddTicks(3535) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 1, 23, 19, 57, 48, 472, DateTimeKind.Utc).AddTicks(3897), new DateTime(2024, 1, 23, 20, 57, 48, 472, DateTimeKind.Utc).AddTicks(3898) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Memberships",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "Memberships",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 1, 20, 18, 14, 39, 558, DateTimeKind.Utc).AddTicks(534), new DateTime(2024, 1, 20, 19, 14, 39, 558, DateTimeKind.Utc).AddTicks(537) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 1, 20, 18, 14, 39, 558, DateTimeKind.Utc).AddTicks(721), new DateTime(2024, 1, 20, 19, 14, 39, 558, DateTimeKind.Utc).AddTicks(721) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 1, 20, 18, 14, 39, 558, DateTimeKind.Utc).AddTicks(892), new DateTime(2024, 1, 20, 19, 14, 39, 558, DateTimeKind.Utc).AddTicks(892) });
        }
    }
}
