using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wellness.Service.Migrations
{
    /// <inheritdoc />
    public partial class AddednewclassReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EarnedMoney = table.Column<float>(type: "real", nullable: false),
                    MemberShipTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_MembershipTypes_MemberShipTypeId",
                        column: x => x.MemberShipTypeId,
                        principalTable: "MembershipTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 15, 16, 13, 31, 963, DateTimeKind.Utc).AddTicks(5519), new DateTime(2024, 2, 15, 17, 13, 31, 963, DateTimeKind.Utc).AddTicks(5522) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 15, 16, 13, 31, 963, DateTimeKind.Utc).AddTicks(5809), new DateTime(2024, 2, 15, 17, 13, 31, 963, DateTimeKind.Utc).AddTicks(5810) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 15, 16, 13, 31, 963, DateTimeKind.Utc).AddTicks(6071), new DateTime(2024, 2, 15, 17, 13, 31, 963, DateTimeKind.Utc).AddTicks(6072) });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_MemberShipTypeId",
                table: "Reports",
                column: "MemberShipTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.AddColumn<int>(
                name: "TreatmentId",
                table: "Ratings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 13, 17, 27, 51, 649, DateTimeKind.Utc).AddTicks(1236), new DateTime(2024, 2, 13, 18, 27, 51, 649, DateTimeKind.Utc).AddTicks(1239) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 13, 17, 27, 51, 649, DateTimeKind.Utc).AddTicks(1770), new DateTime(2024, 2, 13, 18, 27, 51, 649, DateTimeKind.Utc).AddTicks(1771) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 2, 13, 17, 27, 51, 649, DateTimeKind.Utc).AddTicks(2229), new DateTime(2024, 2, 13, 18, 27, 51, 649, DateTimeKind.Utc).AddTicks(2230) });
        }
    }
}
