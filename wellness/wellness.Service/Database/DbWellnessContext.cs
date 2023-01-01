using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace wellness.Service.Database;

public partial class DbWellnessContext : DbContext
{
    public DbWellnessContext()
    {
    }

    public DbWellnessContext(DbContextOptions<DbWellnessContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Membership> Memberships { get; set; }

    public virtual DbSet<MembershipType> MembershipTypes { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Record> Records { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Treatment> Treatments { get; set; }

    public virtual DbSet<TreatmentType> TreatmentTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_Members_UserId").IsUnique();

            entity.HasOne(d => d.User).WithOne(p => p.Member).HasForeignKey<Member>(d => d.UserId);
        });

        modelBuilder.Entity<Membership>(entity =>
        {
            entity.HasIndex(e => e.MemberId, "IX_Memberships_MemberId");

            entity.HasIndex(e => e.MemberShipTypeId, "IX_Memberships_MemberShipTypeId");

            entity.HasOne(d => d.Member).WithMany(p => p.Memberships).HasForeignKey(d => d.MemberId);

            entity.HasOne(d => d.MemberShipType).WithMany(p => p.Memberships).HasForeignKey(d => d.MemberShipTypeId);
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasIndex(e => e.MemberId, "IX_Ratings_MemberId");

            entity.HasIndex(e => e.TreatmentId, "IX_Ratings_TreatmentId");

            entity.Property(e => e.Rating1).HasColumnName("Rating");

            entity.HasOne(d => d.Member).WithMany(p => p.Ratings).HasForeignKey(d => d.MemberId);

            entity.HasOne(d => d.Treatment).WithMany(p => p.Ratings).HasForeignKey(d => d.TreatmentId);
        });

        modelBuilder.Entity<Record>(entity =>
        {
            entity.HasIndex(e => e.MemberId, "IX_Records_MemberId");

            entity.HasOne(d => d.Member).WithMany(p => p.Records).HasForeignKey(d => d.MemberId);
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_Reservations_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.Reservations).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Treatment>(entity =>
        {
            entity.HasIndex(e => e.CategoryId, "IX_Treatments_CategoryId");

            entity.HasIndex(e => e.TreatmentTypeId, "IX_Treatments_TreatmentTypeId");

            entity.HasOne(d => d.Category).WithMany(p => p.Treatments).HasForeignKey(d => d.CategoryId);

            entity.HasOne(d => d.TreatmentType).WithMany(p => p.Treatments).HasForeignKey(d => d.TreatmentTypeId);
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_UserRoles_RoleId");

            entity.HasIndex(e => e.UserId, "IX_UserRoles_UserId");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles).HasForeignKey(d => d.RoleId);

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles).HasForeignKey(d => d.UserId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
