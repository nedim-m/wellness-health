using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wellness.Service.Migrations
{
    /// <inheritdoc />
    public partial class AddTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentGateway = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MemberShipId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Memberships_MemberShipId",
                        column: x => x.MemberShipId,
                        principalTable: "Memberships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 1, 27, 20, 56, 49, 239, DateTimeKind.Utc).AddTicks(6913), new DateTime(2024, 1, 27, 21, 56, 49, 239, DateTimeKind.Utc).AddTicks(6916) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 1, 27, 20, 56, 49, 239, DateTimeKind.Utc).AddTicks(7136), new DateTime(2024, 1, 27, 21, 56, 49, 239, DateTimeKind.Utc).AddTicks(7137) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 1, 27, 20, 56, 49, 239, DateTimeKind.Utc).AddTicks(7357), new DateTime(2024, 1, 27, 21, 56, 49, 239, DateTimeKind.Utc).AddTicks(7357) });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_MemberShipId",
                table: "Transactions",
                column: "MemberShipId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

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
    }
}
