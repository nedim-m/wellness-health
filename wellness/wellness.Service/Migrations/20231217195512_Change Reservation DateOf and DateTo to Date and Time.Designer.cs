﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using wellness.Service.Database;

#nullable disable

namespace wellness.Service.Migrations
{
    [DbContext(typeof(DbWellnessContext))]
    [Migration("20231217195512_Change Reservation DateOf and DateTo to Date and Time")]
    partial class ChangeReservationDateOfandDateTotoDateandTime
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("wellness.Service.Database.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("wellness.Service.Database.Membership", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MemberShipTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "MemberShipTypeId" }, "IX_Memberships_MemberShipTypeId");

                    b.HasIndex(new[] { "UserId" }, "IX_Memberships_UserId");

                    b.ToTable("Memberships");
                });

            modelBuilder.Entity("wellness.Service.Database.MembershipType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("MembershipTypes");
                });

            modelBuilder.Entity("wellness.Service.Database.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StarRating")
                        .HasColumnType("int");

                    b.Property<int>("TreatmentId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "TreatmentId" }, "IX_Ratings_TreatmentId");

                    b.HasIndex(new[] { "UserId" }, "IX_Ratings_UserId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("wellness.Service.Database.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EntryDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LeaveEntryDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "UserId" }, "IX_Records_UserId");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("wellness.Service.Database.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TreatmentId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "TreatmentId" }, "IX_Reservations_TreatmentId");

                    b.HasIndex(new[] { "UserId" }, "IX_Reservations_UserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("wellness.Service.Database.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShiftTime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Administracija",
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Administrator"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Evidencija prisutnih, rezervacija i tretmana",
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Worker-first-shift",
                            ShiftTime = "od 08:00 do 16:00"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Korisnik",
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Member"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Evidencija prisutnih, rezervacija i tretmana",
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Worker-second-shift",
                            ShiftTime = "od 16:00 do 23:00"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Fitnes trener",
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Trainer-first-shift",
                            ShiftTime = "od 08:00 do 16:00"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Fitnes trener",
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Trainer-second-shift",
                            ShiftTime = "od 16:00 do 23:00"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Fizijatar",
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Physiotherapist-first-shift",
                            ShiftTime = "od 08:00 do 16:00"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Fizijatar",
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Physiotherapist-second-shift",
                            ShiftTime = "od 16:00 do 23:00"
                        });
                });

            modelBuilder.Entity("wellness.Service.Database.Treatment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Picture")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("TreatmentTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CategoryId" }, "IX_Treatments_CategoryId");

                    b.HasIndex(new[] { "TreatmentTypeId" }, "IX_Treatments_TreatmentTypeId");

                    b.ToTable("Treatments");
                });

            modelBuilder.Entity("wellness.Service.Database.TreatmentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("TreatmentTypes");
                });

            modelBuilder.Entity("wellness.Service.Database.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool?>("Prisutan")
                        .HasColumnType("bit");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime>("TokenCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TokenExpires")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "RoleId" }, "IX_Users_RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@admin.com",
                            FirstName = "Admin",
                            LastName = "Admin",
                            PasswordHash = new byte[] { 121, 196, 229, 226, 156, 226, 132, 65, 207, 254, 90, 152, 15, 48, 147, 10, 89, 188, 65, 118, 220, 95, 122, 84, 106, 251, 167, 20, 10, 222, 210, 1, 240, 243, 68, 22, 243, 36, 222, 42, 114, 207, 117, 174, 34, 135, 67, 30, 40, 144, 21, 250, 33, 24, 220, 142, 39, 23, 128, 238, 188, 139, 4, 78 },
                            PasswordSalt = new byte[] { 75, 42, 158, 170, 242, 143, 49, 217, 11, 31, 60, 110, 3, 162, 244, 15, 64, 94, 80, 27, 194, 224, 95, 84, 48, 137, 97, 152, 191, 77, 4, 64, 228, 187, 93, 203, 209, 195, 10, 79, 104, 102, 93, 239, 221, 198, 205, 163, 233, 41, 66, 94, 12, 94, 221, 83, 37, 109, 174, 4, 57, 130, 84, 173, 232, 26, 71, 252, 179, 190, 224, 34, 89, 148, 191, 140, 142, 144, 249, 67, 210, 95, 74, 103, 212, 227, 49, 150, 210, 201, 150, 249, 28, 214, 117, 144, 115, 247, 175, 249, 6, 143, 5, 220, 125, 177, 84, 227, 243, 230, 189, 223, 14, 6, 213, 241, 83, 211, 21, 122, 147, 225, 62, 239, 53, 224, 105, 160 },
                            Phone = "061111222",
                            RefreshToken = "",
                            RoleId = 1,
                            Status = true,
                            TokenCreated = new DateTime(2023, 12, 17, 19, 55, 11, 554, DateTimeKind.Utc).AddTicks(1694),
                            TokenExpires = new DateTime(2023, 12, 17, 20, 55, 11, 554, DateTimeKind.Utc).AddTicks(1697),
                            UserName = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Email = "worker@admin.com",
                            FirstName = "Worker",
                            LastName = "Worker",
                            PasswordHash = new byte[] { 121, 196, 229, 226, 156, 226, 132, 65, 207, 254, 90, 152, 15, 48, 147, 10, 89, 188, 65, 118, 220, 95, 122, 84, 106, 251, 167, 20, 10, 222, 210, 1, 240, 243, 68, 22, 243, 36, 222, 42, 114, 207, 117, 174, 34, 135, 67, 30, 40, 144, 21, 250, 33, 24, 220, 142, 39, 23, 128, 238, 188, 139, 4, 78 },
                            PasswordSalt = new byte[] { 75, 42, 158, 170, 242, 143, 49, 217, 11, 31, 60, 110, 3, 162, 244, 15, 64, 94, 80, 27, 194, 224, 95, 84, 48, 137, 97, 152, 191, 77, 4, 64, 228, 187, 93, 203, 209, 195, 10, 79, 104, 102, 93, 239, 221, 198, 205, 163, 233, 41, 66, 94, 12, 94, 221, 83, 37, 109, 174, 4, 57, 130, 84, 173, 232, 26, 71, 252, 179, 190, 224, 34, 89, 148, 191, 140, 142, 144, 249, 67, 210, 95, 74, 103, 212, 227, 49, 150, 210, 201, 150, 249, 28, 214, 117, 144, 115, 247, 175, 249, 6, 143, 5, 220, 125, 177, 84, 227, 243, 230, 189, 223, 14, 6, 213, 241, 83, 211, 21, 122, 147, 225, 62, 239, 53, 224, 105, 160 },
                            Phone = "061112333",
                            RefreshToken = "",
                            RoleId = 2,
                            Status = true,
                            TokenCreated = new DateTime(2023, 12, 17, 19, 55, 11, 554, DateTimeKind.Utc).AddTicks(1942),
                            TokenExpires = new DateTime(2023, 12, 17, 20, 55, 11, 554, DateTimeKind.Utc).AddTicks(1942),
                            UserName = "worker"
                        },
                        new
                        {
                            Id = 3,
                            Email = "member@admin.com",
                            FirstName = "Member",
                            LastName = "Member",
                            PasswordHash = new byte[] { 121, 196, 229, 226, 156, 226, 132, 65, 207, 254, 90, 152, 15, 48, 147, 10, 89, 188, 65, 118, 220, 95, 122, 84, 106, 251, 167, 20, 10, 222, 210, 1, 240, 243, 68, 22, 243, 36, 222, 42, 114, 207, 117, 174, 34, 135, 67, 30, 40, 144, 21, 250, 33, 24, 220, 142, 39, 23, 128, 238, 188, 139, 4, 78 },
                            PasswordSalt = new byte[] { 75, 42, 158, 170, 242, 143, 49, 217, 11, 31, 60, 110, 3, 162, 244, 15, 64, 94, 80, 27, 194, 224, 95, 84, 48, 137, 97, 152, 191, 77, 4, 64, 228, 187, 93, 203, 209, 195, 10, 79, 104, 102, 93, 239, 221, 198, 205, 163, 233, 41, 66, 94, 12, 94, 221, 83, 37, 109, 174, 4, 57, 130, 84, 173, 232, 26, 71, 252, 179, 190, 224, 34, 89, 148, 191, 140, 142, 144, 249, 67, 210, 95, 74, 103, 212, 227, 49, 150, 210, 201, 150, 249, 28, 214, 117, 144, 115, 247, 175, 249, 6, 143, 5, 220, 125, 177, 84, 227, 243, 230, 189, 223, 14, 6, 213, 241, 83, 211, 21, 122, 147, 225, 62, 239, 53, 224, 105, 160 },
                            Phone = "061110121",
                            RefreshToken = "",
                            RoleId = 3,
                            Status = true,
                            TokenCreated = new DateTime(2023, 12, 17, 19, 55, 11, 554, DateTimeKind.Utc).AddTicks(2124),
                            TokenExpires = new DateTime(2023, 12, 17, 20, 55, 11, 554, DateTimeKind.Utc).AddTicks(2124),
                            UserName = "worker"
                        });
                });

            modelBuilder.Entity("wellness.Service.Database.Membership", b =>
                {
                    b.HasOne("wellness.Service.Database.MembershipType", "MemberShipType")
                        .WithMany("Memberships")
                        .HasForeignKey("MemberShipTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wellness.Service.Database.User", "User")
                        .WithMany("Memberships")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MemberShipType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("wellness.Service.Database.Rating", b =>
                {
                    b.HasOne("wellness.Service.Database.Treatment", "Treatment")
                        .WithMany("Ratings")
                        .HasForeignKey("TreatmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wellness.Service.Database.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Treatment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("wellness.Service.Database.Record", b =>
                {
                    b.HasOne("wellness.Service.Database.User", "User")
                        .WithMany("Records")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("wellness.Service.Database.Reservation", b =>
                {
                    b.HasOne("wellness.Service.Database.Treatment", "Treatment")
                        .WithMany("Reservations")
                        .HasForeignKey("TreatmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wellness.Service.Database.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Treatment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("wellness.Service.Database.Treatment", b =>
                {
                    b.HasOne("wellness.Service.Database.Category", "Category")
                        .WithMany("Treatments")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wellness.Service.Database.TreatmentType", "TreatmentType")
                        .WithMany("Treatments")
                        .HasForeignKey("TreatmentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("TreatmentType");
                });

            modelBuilder.Entity("wellness.Service.Database.User", b =>
                {
                    b.HasOne("wellness.Service.Database.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("wellness.Service.Database.Category", b =>
                {
                    b.Navigation("Treatments");
                });

            modelBuilder.Entity("wellness.Service.Database.MembershipType", b =>
                {
                    b.Navigation("Memberships");
                });

            modelBuilder.Entity("wellness.Service.Database.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("wellness.Service.Database.Treatment", b =>
                {
                    b.Navigation("Ratings");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("wellness.Service.Database.TreatmentType", b =>
                {
                    b.Navigation("Treatments");
                });

            modelBuilder.Entity("wellness.Service.Database.User", b =>
                {
                    b.Navigation("Memberships");

                    b.Navigation("Ratings");

                    b.Navigation("Records");

                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
