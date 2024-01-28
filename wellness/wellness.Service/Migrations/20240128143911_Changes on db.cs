using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wellness.Service.Migrations
{
    /// <inheritdoc />
    public partial class Changesondb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Memberships_MemberShipId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "PaymentGateway",
                table: "Transactions",
                newName: "PaymentMethod");

            migrationBuilder.RenameColumn(
                name: "MemberShipId",
                table: "Transactions",
                newName: "MemberShipTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_MemberShipId",
                table: "Transactions",
                newName: "IX_Transactions_MemberShipTypeId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 1, 28, 14, 39, 11, 148, DateTimeKind.Utc).AddTicks(5762), new DateTime(2024, 1, 28, 15, 39, 11, 148, DateTimeKind.Utc).AddTicks(5764) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 1, 28, 14, 39, 11, 148, DateTimeKind.Utc).AddTicks(6262), new DateTime(2024, 1, 28, 15, 39, 11, 148, DateTimeKind.Utc).AddTicks(6263) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TokenCreated", "TokenExpires" },
                values: new object[] { new DateTime(2024, 1, 28, 14, 39, 11, 148, DateTimeKind.Utc).AddTicks(6386), new DateTime(2024, 1, 28, 15, 39, 11, 148, DateTimeKind.Utc).AddTicks(6386) });

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_MembershipTypes_MemberShipTypeId",
                table: "Transactions",
                column: "MemberShipTypeId",
                principalTable: "MembershipTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_MembershipTypes_MemberShipTypeId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "PaymentMethod",
                table: "Transactions",
                newName: "PaymentGateway");

            migrationBuilder.RenameColumn(
                name: "MemberShipTypeId",
                table: "Transactions",
                newName: "MemberShipId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_MemberShipTypeId",
                table: "Transactions",
                newName: "IX_Transactions_MemberShipId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Memberships_MemberShipId",
                table: "Transactions",
                column: "MemberShipId",
                principalTable: "Memberships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
