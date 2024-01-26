using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wellness.Service.Migrations
{
    /// <inheritdoc />
    public partial class RemovepricefromTreatmentType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "TreatmentTypes");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "TreatmentTypes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

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
    }
}
