using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wellness.Service.Migrations
{
    /// <inheritdoc />
    public partial class RemovedDescriptionfromRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Ratings");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2023, 12, 23, 14, 16, 40, 152, DateTimeKind.Utc).AddTicks(6482), new DateTime(2023, 12, 23, 15, 16, 40, 152, DateTimeKind.Utc).AddTicks(6483) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2023, 12, 23, 14, 16, 40, 152, DateTimeKind.Utc).AddTicks(6807), new DateTime(2023, 12, 23, 15, 16, 40, 152, DateTimeKind.Utc).AddTicks(6807) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2023, 12, 23, 14, 16, 40, 152, DateTimeKind.Utc).AddTicks(7056), new DateTime(2023, 12, 23, 15, 16, 40, 152, DateTimeKind.Utc).AddTicks(7057) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Ratings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2023, 12, 22, 12, 51, 56, 578, DateTimeKind.Utc).AddTicks(2280), new DateTime(2023, 12, 22, 13, 51, 56, 578, DateTimeKind.Utc).AddTicks(2283) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2023, 12, 22, 12, 51, 56, 578, DateTimeKind.Utc).AddTicks(2504), new DateTime(2023, 12, 22, 13, 51, 56, 578, DateTimeKind.Utc).AddTicks(2505) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2023, 12, 22, 12, 51, 56, 578, DateTimeKind.Utc).AddTicks(2672), new DateTime(2023, 12, 22, 13, 51, 56, 578, DateTimeKind.Utc).AddTicks(2672) });
        }
    }
}
