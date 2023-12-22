using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wellness.Service.Migrations
{
    /// <inheritdoc />
    public partial class addnullablefieldforstatusinReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Reservations",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2023, 12, 20, 17, 47, 16, 379, DateTimeKind.Utc).AddTicks(1608), new DateTime(2023, 12, 20, 18, 47, 16, 379, DateTimeKind.Utc).AddTicks(1611) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2023, 12, 20, 17, 47, 16, 379, DateTimeKind.Utc).AddTicks(1796), new DateTime(2023, 12, 20, 18, 47, 16, 379, DateTimeKind.Utc).AddTicks(1797) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2023, 12, 20, 17, 47, 16, 379, DateTimeKind.Utc).AddTicks(2235), new DateTime(2023, 12, 20, 18, 47, 16, 379, DateTimeKind.Utc).AddTicks(2236) });
        }
    }
}
