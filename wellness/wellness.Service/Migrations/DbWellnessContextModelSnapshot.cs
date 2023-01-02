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

            modelBuilder.Entity("wellness.Service.Database.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "UserId" }, "IX_Members_UserId")
                        .IsUnique();

                    b.ToTable("Members");
                });

            modelBuilder.Entity("wellness.Service.Database.Membership", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("MemberShipTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "MemberId" }, "IX_Memberships_MemberId");

                    b.HasIndex(new[] { "MemberShipTypeId" }, "IX_Memberships_MemberShipTypeId");

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

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("Rating1")
                        .HasColumnType("int")
                        .HasColumnName("Rating");

                    b.Property<int>("TreatmentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "MemberId" }, "IX_Ratings_MemberId");

                    b.HasIndex(new[] { "TreatmentId" }, "IX_Ratings_TreatmentId");

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

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "MemberId" }, "IX_Records_MemberId");

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

                    b.HasIndex("TreatmentId");

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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "This is Administrator Description",
                            Name = "Administrator"
                        },
                        new
                        {
                            Id = 2,
                            Description = "This is Uposlenik Description",
                            Name = "Uposlenik"
                        },
                        new
                        {
                            Id = 3,
                            Description = "This is Korisnik Description",
                            Name = "Korisnik"
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.ToTable("Users");
                });

            modelBuilder.Entity("wellness.Service.Database.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "RoleId" }, "IX_UserRoles_RoleId");

                    b.HasIndex(new[] { "UserId" }, "IX_UserRoles_UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("wellness.Service.Database.Member", b =>
                {
                    b.HasOne("wellness.Service.Database.User", "User")
                        .WithOne("Member")
                        .HasForeignKey("wellness.Service.Database.Member", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("wellness.Service.Database.Membership", b =>
                {
                    b.HasOne("wellness.Service.Database.Member", "Member")
                        .WithMany("Memberships")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wellness.Service.Database.MembershipType", "MemberShipType")
                        .WithMany("Memberships")
                        .HasForeignKey("MemberShipTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("MemberShipType");
                });

            modelBuilder.Entity("wellness.Service.Database.Rating", b =>
                {
                    b.HasOne("wellness.Service.Database.Member", "Member")
                        .WithMany("Ratings")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wellness.Service.Database.Treatment", "Treatment")
                        .WithMany("Ratings")
                        .HasForeignKey("TreatmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Treatment");
                });

            modelBuilder.Entity("wellness.Service.Database.Record", b =>
                {
                    b.HasOne("wellness.Service.Database.Member", "Member")
                        .WithMany("Records")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("wellness.Service.Database.Reservation", b =>
                {
                    b.HasOne("wellness.Service.Database.Treatment", "Treatment")
                        .WithMany()
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

            modelBuilder.Entity("wellness.Service.Database.UserRole", b =>
                {
                    b.HasOne("wellness.Service.Database.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wellness.Service.Database.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("wellness.Service.Database.Category", b =>
                {
                    b.Navigation("Treatments");
                });

            modelBuilder.Entity("wellness.Service.Database.Member", b =>
                {
                    b.Navigation("Memberships");

                    b.Navigation("Ratings");

                    b.Navigation("Records");
                });

            modelBuilder.Entity("wellness.Service.Database.MembershipType", b =>
                {
                    b.Navigation("Memberships");
                });

            modelBuilder.Entity("wellness.Service.Database.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("wellness.Service.Database.Treatment", b =>
                {
                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("wellness.Service.Database.TreatmentType", b =>
                {
                    b.Navigation("Treatments");
                });

            modelBuilder.Entity("wellness.Service.Database.User", b =>
                {
                    b.Navigation("Member");

                    b.Navigation("Reservations");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
