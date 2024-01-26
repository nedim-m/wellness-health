using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wellness.Service.Migrations
{
    /// <inheritdoc />
    public partial class addeddurationforMiembershipType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "MembershipTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 1, 26, 15, 50, 38, 335, DateTimeKind.Utc).AddTicks(666), new DateTime(2024, 1, 26, 16, 50, 38, 335, DateTimeKind.Utc).AddTicks(669) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 1, 26, 15, 50, 38, 335, DateTimeKind.Utc).AddTicks(965), new DateTime(2024, 1, 26, 16, 50, 38, 335, DateTimeKind.Utc).AddTicks(965) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 1, 26, 15, 50, 38, 335, DateTimeKind.Utc).AddTicks(1228), new DateTime(2024, 1, 26, 16, 50, 38, 335, DateTimeKind.Utc).AddTicks(1229) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "MembershipTypes");

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
    }
}
