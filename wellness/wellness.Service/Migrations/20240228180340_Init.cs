using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wellness.Service.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MembershipTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkingHours = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EarnedMoney = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalUsers = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TokenCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TokenExpires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Prisutan = table.Column<bool>(type: "bit", nullable: true),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Shifts_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Treatments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TreatmentTypeId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treatments_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Treatments_TreatmentTypes_TreatmentTypeId",
                        column: x => x.TreatmentTypeId,
                        principalTable: "TreatmentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpirationDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MemberShipTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Memberships_MembershipTypes_MemberShipTypeId",
                        column: x => x.MemberShipTypeId,
                        principalTable: "MembershipTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Memberships_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntryDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaveEntryDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Records_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MemberShipTypeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_MembershipTypes_MemberShipTypeId",
                        column: x => x.MemberShipTypeId,
                        principalTable: "MembershipTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    TreatmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "Treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StarRating = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Description of Category 1", "Category 1" },
                    { 2, "Description of Category 2", "Category 2" },
                    { 3, "Description of Category 3", "Category 3" }
                });

            migrationBuilder.InsertData(
                table: "MembershipTypes",
                columns: new[] { "Id", "Description", "Duration", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Opis membership 1", 30, "Membership 1", 60f },
                    { 2, "Opis membership 2", 60, "Membership 2", 120f }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Administracija", "Administrator" },
                    { 2, "Evidencija prisutnih, rezervacija i tretmana", "Employee" },
                    { 3, "Korisnik", "Member" }
                });

            migrationBuilder.InsertData(
                table: "Shifts",
                columns: new[] { "Id", "Name", "WorkingHours" },
                values: new object[,]
                {
                    { 1, "Admin/Member", " " },
                    { 2, "Prva smjena", "08:00 - 14:00" },
                    { 3, "Druga smjena", "14:00 - 20:00" }
                });

            migrationBuilder.InsertData(
                table: "TreatmentTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Description of TreatmentType 1", "TreatmentType 1" },
                    { 2, "Description of TreatmentType 2", "TreatmentType 2" },
                    { 3, "Description of TreatmentType 3", "TreatmentType 3" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Phone", "Picture", "Prisutan", "RefreshToken", "RoleId", "ShiftId", "Status", "TokenCreated", "TokenExpires", "UserName" },
                values: new object[,]
                {
                    { 1, "admin@admin.com", "Admin", "Admin", new byte[] { 121, 196, 229, 226, 156, 226, 132, 65, 207, 254, 90, 152, 15, 48, 147, 10, 89, 188, 65, 118, 220, 95, 122, 84, 106, 251, 167, 20, 10, 222, 210, 1, 240, 243, 68, 22, 243, 36, 222, 42, 114, 207, 117, 174, 34, 135, 67, 30, 40, 144, 21, 250, 33, 24, 220, 142, 39, 23, 128, 238, 188, 139, 4, 78 }, new byte[] { 75, 42, 158, 170, 242, 143, 49, 217, 11, 31, 60, 110, 3, 162, 244, 15, 64, 94, 80, 27, 194, 224, 95, 84, 48, 137, 97, 152, 191, 77, 4, 64, 228, 187, 93, 203, 209, 195, 10, 79, 104, 102, 93, 239, 221, 198, 205, 163, 233, 41, 66, 94, 12, 94, 221, 83, 37, 109, 174, 4, 57, 130, 84, 173, 232, 26, 71, 252, 179, 190, 224, 34, 89, 148, 191, 140, 142, 144, 249, 67, 210, 95, 74, 103, 212, 227, 49, 150, 210, 201, 150, 249, 28, 214, 117, 144, 115, 247, 175, 249, 6, 143, 5, 220, 125, 177, 84, 227, 243, 230, 189, 223, 14, 6, 213, 241, 83, 211, 21, 122, 147, 225, 62, 239, 53, 224, 105, 160 }, "061111222", null, null, "", 1, 1, true, new DateTime(2024, 2, 28, 18, 3, 39, 681, DateTimeKind.Utc).AddTicks(6600), new DateTime(2024, 2, 28, 19, 3, 39, 681, DateTimeKind.Utc).AddTicks(6603), "admin" },
                    { 2, "employee@admin.com", "Employee", "Employee", new byte[] { 121, 196, 229, 226, 156, 226, 132, 65, 207, 254, 90, 152, 15, 48, 147, 10, 89, 188, 65, 118, 220, 95, 122, 84, 106, 251, 167, 20, 10, 222, 210, 1, 240, 243, 68, 22, 243, 36, 222, 42, 114, 207, 117, 174, 34, 135, 67, 30, 40, 144, 21, 250, 33, 24, 220, 142, 39, 23, 128, 238, 188, 139, 4, 78 }, new byte[] { 75, 42, 158, 170, 242, 143, 49, 217, 11, 31, 60, 110, 3, 162, 244, 15, 64, 94, 80, 27, 194, 224, 95, 84, 48, 137, 97, 152, 191, 77, 4, 64, 228, 187, 93, 203, 209, 195, 10, 79, 104, 102, 93, 239, 221, 198, 205, 163, 233, 41, 66, 94, 12, 94, 221, 83, 37, 109, 174, 4, 57, 130, 84, 173, 232, 26, 71, 252, 179, 190, 224, 34, 89, 148, 191, 140, 142, 144, 249, 67, 210, 95, 74, 103, 212, 227, 49, 150, 210, 201, 150, 249, 28, 214, 117, 144, 115, 247, 175, 249, 6, 143, 5, 220, 125, 177, 84, 227, 243, 230, 189, 223, 14, 6, 213, 241, 83, 211, 21, 122, 147, 225, 62, 239, 53, 224, 105, 160 }, "061112333", null, null, "", 2, 2, true, new DateTime(2024, 2, 28, 18, 3, 39, 681, DateTimeKind.Utc).AddTicks(6789), new DateTime(2024, 2, 28, 19, 3, 39, 681, DateTimeKind.Utc).AddTicks(6790), "employee" },
                    { 3, "member@member.com", "Member", "Member", new byte[] { 121, 196, 229, 226, 156, 226, 132, 65, 207, 254, 90, 152, 15, 48, 147, 10, 89, 188, 65, 118, 220, 95, 122, 84, 106, 251, 167, 20, 10, 222, 210, 1, 240, 243, 68, 22, 243, 36, 222, 42, 114, 207, 117, 174, 34, 135, 67, 30, 40, 144, 21, 250, 33, 24, 220, 142, 39, 23, 128, 238, 188, 139, 4, 78 }, new byte[] { 75, 42, 158, 170, 242, 143, 49, 217, 11, 31, 60, 110, 3, 162, 244, 15, 64, 94, 80, 27, 194, 224, 95, 84, 48, 137, 97, 152, 191, 77, 4, 64, 228, 187, 93, 203, 209, 195, 10, 79, 104, 102, 93, 239, 221, 198, 205, 163, 233, 41, 66, 94, 12, 94, 221, 83, 37, 109, 174, 4, 57, 130, 84, 173, 232, 26, 71, 252, 179, 190, 224, 34, 89, 148, 191, 140, 142, 144, 249, 67, 210, 95, 74, 103, 212, 227, 49, 150, 210, 201, 150, 249, 28, 214, 117, 144, 115, 247, 175, 249, 6, 143, 5, 220, 125, 177, 84, 227, 243, 230, 189, 223, 14, 6, 213, 241, 83, 211, 21, 122, 147, 225, 62, 239, 53, 224, 105, 160 }, "061110121", null, null, "", 3, 1, true, new DateTime(2024, 2, 28, 18, 3, 39, 681, DateTimeKind.Utc).AddTicks(6966), new DateTime(2024, 2, 28, 19, 3, 39, 681, DateTimeKind.Utc).AddTicks(6967), "member" },
                    { 4, "korisnik@korisnik.com", "Korisnik", "Korisnik", new byte[] { 121, 196, 229, 226, 156, 226, 132, 65, 207, 254, 90, 152, 15, 48, 147, 10, 89, 188, 65, 118, 220, 95, 122, 84, 106, 251, 167, 20, 10, 222, 210, 1, 240, 243, 68, 22, 243, 36, 222, 42, 114, 207, 117, 174, 34, 135, 67, 30, 40, 144, 21, 250, 33, 24, 220, 142, 39, 23, 128, 238, 188, 139, 4, 78 }, new byte[] { 75, 42, 158, 170, 242, 143, 49, 217, 11, 31, 60, 110, 3, 162, 244, 15, 64, 94, 80, 27, 194, 224, 95, 84, 48, 137, 97, 152, 191, 77, 4, 64, 228, 187, 93, 203, 209, 195, 10, 79, 104, 102, 93, 239, 221, 198, 205, 163, 233, 41, 66, 94, 12, 94, 221, 83, 37, 109, 174, 4, 57, 130, 84, 173, 232, 26, 71, 252, 179, 190, 224, 34, 89, 148, 191, 140, 142, 144, 249, 67, 210, 95, 74, 103, 212, 227, 49, 150, 210, 201, 150, 249, 28, 214, 117, 144, 115, 247, 175, 249, 6, 143, 5, 220, 125, 177, 84, 227, 243, 230, 189, 223, 14, 6, 213, 241, 83, 211, 21, 122, 147, 225, 62, 239, 53, 224, 105, 160 }, "061110123", null, null, "", 3, 1, true, new DateTime(2024, 2, 28, 18, 3, 39, 681, DateTimeKind.Utc).AddTicks(7086), new DateTime(2024, 2, 28, 19, 3, 39, 681, DateTimeKind.Utc).AddTicks(7086), "korisnik" },
                    { 5, "nedim_misic@hotmail.com", "Nedim", "Misic", new byte[] { 121, 196, 229, 226, 156, 226, 132, 65, 207, 254, 90, 152, 15, 48, 147, 10, 89, 188, 65, 118, 220, 95, 122, 84, 106, 251, 167, 20, 10, 222, 210, 1, 240, 243, 68, 22, 243, 36, 222, 42, 114, 207, 117, 174, 34, 135, 67, 30, 40, 144, 21, 250, 33, 24, 220, 142, 39, 23, 128, 238, 188, 139, 4, 78 }, new byte[] { 75, 42, 158, 170, 242, 143, 49, 217, 11, 31, 60, 110, 3, 162, 244, 15, 64, 94, 80, 27, 194, 224, 95, 84, 48, 137, 97, 152, 191, 77, 4, 64, 228, 187, 93, 203, 209, 195, 10, 79, 104, 102, 93, 239, 221, 198, 205, 163, 233, 41, 66, 94, 12, 94, 221, 83, 37, 109, 174, 4, 57, 130, 84, 173, 232, 26, 71, 252, 179, 190, 224, 34, 89, 148, 191, 140, 142, 144, 249, 67, 210, 95, 74, 103, 212, 227, 49, 150, 210, 201, 150, 249, 28, 214, 117, 144, 115, 247, 175, 249, 6, 143, 5, 220, 125, 177, 84, 227, 243, 230, 189, 223, 14, 6, 213, 241, 83, 211, 21, 122, 147, 225, 62, 239, 53, 224, 105, 160 }, "061110123", null, null, "", 3, 1, true, new DateTime(2024, 2, 28, 18, 3, 39, 681, DateTimeKind.Utc).AddTicks(7307), new DateTime(2024, 2, 28, 19, 3, 39, 681, DateTimeKind.Utc).AddTicks(7308), "nedim" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_MemberShipTypeId",
                table: "Memberships",
                column: "MemberShipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_UserId",
                table: "Memberships",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ReservationId",
                table: "Ratings",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_UserId",
                table: "Records",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_MemberShipTypeId",
                table: "Reports",
                column: "MemberShipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TreatmentId",
                table: "Reservations",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_MemberShipTypeId",
                table: "Transactions",
                column: "MemberShipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_CategoryId",
                table: "Treatments",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_TreatmentTypeId",
                table: "Treatments",
                column: "TreatmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ShiftId",
                table: "Users",
                column: "ShiftId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "MembershipTypes");

            migrationBuilder.DropTable(
                name: "Treatments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "TreatmentTypes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Shifts");
        }
    }
}
