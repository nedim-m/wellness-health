using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wellness.Service.Migrations
{
    /// <inheritdoc />
    public partial class ChangeReservationDateOfandDateTotoDateandTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOf",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "DateTo",
                table: "Reservations",
                newName: "Date");

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2023, 12, 17, 19, 55, 11, 554, DateTimeKind.Utc).AddTicks(1694), new DateTime(2023, 12, 17, 20, 55, 11, 554, DateTimeKind.Utc).AddTicks(1697) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2023, 12, 17, 19, 55, 11, 554, DateTimeKind.Utc).AddTicks(1942), new DateTime(2023, 12, 17, 20, 55, 11, 554, DateTimeKind.Utc).AddTicks(1942) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2023, 12, 17, 19, 55, 11, 554, DateTimeKind.Utc).AddTicks(2124), new DateTime(2023, 12, 17, 20, 55, 11, 554, DateTimeKind.Utc).AddTicks(2124) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Reservations",
                newName: "DateTo");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOf",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
    }
}
