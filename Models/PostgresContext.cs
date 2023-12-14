using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace KursachTravel.Models;

public partial class PostgresContext : DbContext
{
    public DbSet<Client> clientsSet { get; set; }
    public DbSet<Partner> partnerSet { get; set; }
    public DbSet<Regist> registSet { get; set; }
    public DbSet<Service> serviceSet { get; set; }
    public DbSet<Tur> turSet { get; set; }
    
    
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<Regist> Regists { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Tur> Turs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=Zhjckfd2100");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("client_pkey");

            entity.ToTable("client");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Patronymic).HasColumnName("patronymic");
            entity.Property(e => e.Preferences).HasColumnName("preferences");
            entity.Property(e => e.Surname).HasColumnName("surname");
            entity.Property(e => e.Telephone).HasColumnName("telephone");
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("partners_pkey");

            entity.ToTable("partners");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Telephone).HasColumnName("telephone");
            entity.Property(e => e.Title).HasColumnName("title");
        });

        modelBuilder.Entity<Regist>(entity =>
        {
            entity.HasKey(e => e.id).HasName("regist_pkey");

            entity.ToTable("regist");

            entity.Property(e => e.id).HasColumnName("id");
            entity.Property(e => e.login)
                .HasMaxLength(25)
                .HasColumnName("login");
            entity.Property(e => e.password)
                .HasMaxLength(25)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("services_pkey");

            entity.ToTable("services");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Title).HasColumnName("title");
        });

        modelBuilder.Entity<Tur>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tur_pkey");

            entity.ToTable("tur");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.TitleTur).HasColumnName("title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
