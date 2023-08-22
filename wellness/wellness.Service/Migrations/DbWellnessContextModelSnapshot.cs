﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using wellness.Service.Database;

#nullable disable

namespace wellness.Service.Migrations
{
    [DbContext(typeof(DbWellnessContext))]
    partial class DbWellnessContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LeaveEntryDate")
                        .HasColumnType("datetime2");

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

                    b.Property<DateTime>("DateOf")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

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
                            ShiftTime = "od 08:00 do 16:00"
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
                            Description = "Fitnes trener, rezervacija i tretmana",
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Trainer-second-shift",
                            ShiftTime = "od 08:00 do 16:00"
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
                            Description = "Fizijatar, rezervacija i tretmana",
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Physiotherapist-second-shift",
                            ShiftTime = "od 08:00 do 16:00"
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
