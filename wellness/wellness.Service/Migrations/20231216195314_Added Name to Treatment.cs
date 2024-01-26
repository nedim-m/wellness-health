using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wellness.Service.Migrations
{
    /// <inheritdoc />
    public partial class AddedNametoTreatment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Treatments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2023, 12, 16, 19, 53, 14, 342, DateTimeKind.Utc).AddTicks(1319), new DateTime(2023, 12, 16, 20, 53, 14, 342, DateTimeKind.Utc).AddTicks(1321) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2023, 12, 16, 19, 53, 14, 342, DateTimeKind.Utc).AddTicks(1498), new DateTime(2023, 12, 16, 20, 53, 14, 342, DateTimeKind.Utc).AddTicks(1499) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2023, 12, 16, 19, 53, 14, 342, DateTimeKind.Utc).AddTicks(1798), new DateTime(2023, 12, 16, 20, 53, 14, 342, DateTimeKind.Utc).AddTicks(1798) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Treatments");

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
    }
}
