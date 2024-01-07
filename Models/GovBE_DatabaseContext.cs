﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GovBE.Models;

public partial class GovBE_DatabaseContext : DbContext
{
    public GovBE_DatabaseContext(DbContextOptions<GovBE_DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adslocation> Adslocations { get; set; }

    public virtual DbSet<Adslocationimage> Adslocationimages { get; set; }

    public virtual DbSet<Adslocationupdate> Adslocationupdates { get; set; }

    public virtual DbSet<Adsnew> Adsnews { get; set; }

    public virtual DbSet<Adsnewimage> Adsnewimages { get; set; }

    public virtual DbSet<Adsnewupdate> Adsnewupdates { get; set; }

    public virtual DbSet<Adsprocessing> Adsprocessings { get; set; }

    public virtual DbSet<Adsstatus> Adsstatuses { get; set; }

    public virtual DbSet<Adstype> Adstypes { get; set; }

    public virtual DbSet<Aspnetrole> Aspnetroles { get; set; }

    public virtual DbSet<Aspnetroleclaim> Aspnetroleclaims { get; set; }

    public virtual DbSet<Aspnetuser> Aspnetusers { get; set; }

    public virtual DbSet<Aspnetuserclaim> Aspnetuserclaims { get; set; }

    public virtual DbSet<Aspnetuserlogin> Aspnetuserlogins { get; set; }

    public virtual DbSet<Aspnetuserrole> Aspnetuserroles { get; set; }

    public virtual DbSet<Aspnetusertoken> Aspnetusertokens { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Reportwarning> Reportwarnings { get; set; }

    public virtual DbSet<Reportwarningurl> Reportwarningurls { get; set; }

    public virtual DbSet<Ward> Wards { get; set; }

    public virtual DbSet<Warningtype> Warningtypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Adslocation>(entity =>
        {
            entity.HasKey(e => e.AdsLocationId).HasName("PRIMARY");

            entity.ToTable("adslocation");

            entity.Property(e => e.AdsAddress)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.AdsStatus)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.CreateOnUtc).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)");
            entity.Property(e => e.LastUpdateOnUtc).HasColumnType("datetime");
            entity.Property(e => e.Latitude).HasPrecision(18, 15);
            entity.Property(e => e.Longtitude).HasPrecision(18, 15);
            entity.Property(e => e.SizeUnit)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.TypeId).HasColumnName("TypeID");
        });

        modelBuilder.Entity<Adslocationimage>(entity =>
        {
            entity.HasKey(e => e.AdsLocationImageId).HasName("PRIMARY");

            entity.ToTable("adslocationimage");

            entity.Property(e => e.CreateOnUtc).HasColumnType("datetime");
            entity.Property(e => e.Image).HasColumnType("mediumblob");
        });

        modelBuilder.Entity<Adslocationupdate>(entity =>
        {
            entity.HasKey(e => e.AdsLocationUpdateId).HasName("PRIMARY");

            entity.ToTable("adslocationupdate");

            entity.Property(e => e.Comment)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.CreateOnUtc).HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)");
            entity.Property(e => e.LastUpdateOnUtc).HasColumnType("datetime");
            entity.Property(e => e.StatusEdit)
                .HasMaxLength(30)
                .IsFixedLength();
        });

        modelBuilder.Entity<Adsnew>(entity =>
        {
            entity.HasKey(e => e.AdsNewId).HasName("PRIMARY");

            entity.ToTable("adsnew");

            entity.Property(e => e.AdsAddress)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Comment)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.CompanyAddress)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.CompanyInfo)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.CreateOnUtc).HasColumnType("datetime");
            entity.Property(e => e.District)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Email)
                .HasMaxLength(60)
                .IsFixedLength();
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)");
            entity.Property(e => e.LastUpdateOnUtc).HasColumnType("datetime");
            entity.Property(e => e.Latitude).HasPrecision(18, 15);
            entity.Property(e => e.Longtitude).HasPrecision(18, 15);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.ProcessingStatus)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.SizeUnit)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Ward)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        modelBuilder.Entity<Adsnewimage>(entity =>
        {
            entity.HasKey(e => e.AdsNewImageId).HasName("PRIMARY");

            entity.ToTable("adsnewimage");

            entity.Property(e => e.AdsNewId).HasColumnName("AdsNewID");
            entity.Property(e => e.CreateOnUtc).HasColumnType("datetime");
            entity.Property(e => e.Image).HasColumnType("mediumblob");
        });

        modelBuilder.Entity<Adsnewupdate>(entity =>
        {
            entity.HasKey(e => e.AdsNewUpdateId).HasName("PRIMARY");

            entity.ToTable("adsnewupdate");

            entity.Property(e => e.Comment)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.CreateOnUtc).HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)");
            entity.Property(e => e.LastUpdateOnUtc).HasColumnType("datetime");
            entity.Property(e => e.StatusEdit)
                .HasMaxLength(30)
                .IsFixedLength();
        });

        modelBuilder.Entity<Adsprocessing>(entity =>
        {
            entity.HasKey(e => e.AdsProcessingId).HasName("PRIMARY");

            entity.ToTable("adsprocessing");

            entity.Property(e => e.Comment)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.CreateOnUtc).HasColumnType("datetime");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)");
            entity.Property(e => e.LastUpdateOnUtc).HasColumnType("datetime");
            entity.Property(e => e.ProcessingStatus)
                .HasMaxLength(30)
                .IsFixedLength();
        });

        modelBuilder.Entity<Adsstatus>(entity =>
        {
            entity.HasKey(e => e.AdsStatusId).HasName("PRIMARY");

            entity.ToTable("adsstatus");

            entity.Property(e => e.CreateOnUtc).HasColumnType("datetime");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)");
            entity.Property(e => e.LastUpdateOnUtc).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsFixedLength();
        });

        modelBuilder.Entity<Adstype>(entity =>
        {
            entity.HasKey(e => e.AdsTypeId).HasName("PRIMARY");

            entity.ToTable("adstype");

            entity.Property(e => e.CreateOnUtc).HasColumnType("datetime");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)");
            entity.Property(e => e.LastUpdateOnUtc).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsFixedLength();
        });

        modelBuilder.Entity<Aspnetrole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("aspnetroles");

            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<Aspnetroleclaim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("aspnetroleclaims");

            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.Property(e => e.RoleId).IsRequired();

            entity.HasOne(d => d.Role).WithMany(p => p.Aspnetroleclaims)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
        });

        modelBuilder.Entity<Aspnetuser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("aspnetusers");

            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex").IsUnique();

            entity.Property(e => e.District).IsRequired();
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FirstName).IsRequired();
            entity.Property(e => e.LastName).IsRequired();
            entity.Property(e => e.LockoutEnd).HasMaxLength(6);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);
            entity.Property(e => e.Ward).IsRequired();
        });

        modelBuilder.Entity<Aspnetuserclaim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("aspnetuserclaims");

            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.Property(e => e.UserId).IsRequired();

            entity.HasOne(d => d.User).WithMany(p => p.Aspnetuserclaims)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId");
        });

        modelBuilder.Entity<Aspnetuserlogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("aspnetuserlogins");

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.UserId).IsRequired();

            entity.HasOne(d => d.User).WithMany(p => p.Aspnetuserlogins)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
        });

        modelBuilder.Entity<Aspnetuserrole>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.RoleId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("aspnetuserroles");

            entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.Aspnetuserroles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId");

            entity.HasOne(d => d.User).WithMany(p => p.Aspnetuserroles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId");
        });

        modelBuilder.Entity<Aspnetusertoken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("aspnetusertokens");

            entity.HasOne(d => d.User).WithMany(p => p.Aspnetusertokens)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId");
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.HasKey(e => e.DistrictId).HasName("PRIMARY");

            entity.ToTable("district");

            entity.Property(e => e.CreateOnUtc).HasColumnType("datetime");
            entity.Property(e => e.FullName)
                .HasMaxLength(30)
                .IsFixedLength();
        });

        modelBuilder.Entity<Efmigrationshistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__efmigrationshistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion)
                .IsRequired()
                .HasMaxLength(32);
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("logs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Exception).HasColumnType("text");
            entity.Property(e => e.Level).HasMaxLength(15);
            entity.Property(e => e.Message).HasColumnType("text");
            entity.Property(e => e.Properties).HasColumnType("text");
            entity.Property(e => e.Template).HasColumnType("text");
            entity.Property(e => e.Timestamp).HasMaxLength(100);
            entity.Property(e => e.Ts)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("_ts");
        });

        modelBuilder.Entity<Reportwarning>(entity =>
        {
            entity.HasKey(e => e.ReportWarningId).HasName("PRIMARY");

            entity.ToTable("reportwarning");

            entity.Property(e => e.Comment)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.CreateOnUtc).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)");
            entity.Property(e => e.LastUpdateOnUtc).HasColumnType("datetime");
            entity.Property(e => e.Latitude).HasPrecision(18, 15);
            entity.Property(e => e.Longtitude).HasPrecision(18, 15);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.ReportWarningStatus)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.WarningType)
                .HasMaxLength(30)
                .IsFixedLength();
        });

        modelBuilder.Entity<Reportwarningurl>(entity =>
        {
            entity.HasKey(e => e.ReportWarningImageId).HasName("PRIMARY");

            entity.ToTable("reportwarningurl");

            entity.Property(e => e.CreateOnUtc).HasColumnType("datetime");
            entity.Property(e => e.Url)
                .HasMaxLength(200)
                .IsFixedLength();
        });

        modelBuilder.Entity<Ward>(entity =>
        {
            entity.HasKey(e => e.WardId).HasName("PRIMARY");

            entity.ToTable("ward");

            entity.Property(e => e.CreateOnUtc).HasColumnType("datetime");
            entity.Property(e => e.FullName)
                .HasMaxLength(30)
                .IsFixedLength();
        });

        modelBuilder.Entity<Warningtype>(entity =>
        {
            entity.HasKey(e => e.WarningTypeId).HasName("PRIMARY");

            entity.ToTable("warningtype");

            entity.Property(e => e.CreateOnUtc).HasColumnType("datetime");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)");
            entity.Property(e => e.LastUpdateOnUtc).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}