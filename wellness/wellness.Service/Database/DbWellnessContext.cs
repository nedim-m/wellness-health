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

    public virtual DbSet<Membership> Memberships { get; set; }

    public virtual DbSet<MembershipType> MembershipTypes { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Record> Records { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Treatment> Treatments { get; set; }

    public virtual DbSet<TreatmentType> TreatmentTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Transaction>Transactions  { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Membership>(entity =>
        {
            entity.HasIndex(e => e.MemberShipTypeId, "IX_Memberships_MemberShipTypeId");

            entity.HasIndex(e => e.UserId, "IX_Memberships_UserId");

            entity.HasOne(d => d.MemberShipType).WithMany(p => p.Memberships).HasForeignKey(d => d.MemberShipTypeId);

            entity.HasOne(d => d.User).WithMany(p => p.Memberships).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasIndex(e => e.TreatmentId, "IX_Ratings_TreatmentId");

            entity.HasIndex(e => e.UserId, "IX_Ratings_UserId");

            entity.HasOne(d => d.Treatment).WithMany(p => p.Ratings).HasForeignKey(d => d.TreatmentId);

            entity.HasOne(d => d.User).WithMany(p => p.Ratings).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Record>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_Records_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.Records).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasIndex(e => e.TreatmentId, "IX_Reservations_TreatmentId");

            entity.HasIndex(e => e.UserId, "IX_Reservations_UserId");

            entity.HasOne(d => d.Treatment).WithMany(p => p.Reservations).HasForeignKey(d => d.TreatmentId);

            entity.HasOne(d => d.User).WithMany(p => p.Reservations).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Treatment>(entity =>
        {
            entity.HasIndex(e => e.CategoryId, "IX_Treatments_CategoryId");

            entity.HasIndex(e => e.TreatmentTypeId, "IX_Treatments_TreatmentTypeId");

            entity.HasOne(d => d.Category).WithMany(p => p.Treatments).HasForeignKey(d => d.CategoryId);

            entity.HasOne(d => d.TreatmentType).WithMany(p => p.Treatments).HasForeignKey(d => d.TreatmentTypeId);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_Users_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.Users).HasForeignKey(d => d.RoleId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
