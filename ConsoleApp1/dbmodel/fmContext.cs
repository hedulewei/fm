using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConsoleApp1.dbmodel
{
    public partial class fmContext : DbContext
    {
        public virtual DbSet<Foreigner> Foreigner { get; set; }
        public virtual DbSet<Inspectlog> Inspectlog { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<Police> Police { get; set; }
        public virtual DbSet<Residence> Residence { get; set; }
        public virtual DbSet<Task> Task { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;port=5678;User Id=blah;Password=ycl1mail@A;Database=fm");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Foreigner>(entity =>
            {
                entity.ToTable("foreigner");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Organization)
                    .HasName("foreignerorganization_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Hisorg).HasColumnName("hisorg");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45);

                entity.Property(e => e.Organization)
                    .HasColumnName("organization")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.OrganizationNavigation)
                    .WithMany(p => p.Foreigner)
                    .HasForeignKey(d => d.Organization)
                    .HasConstraintName("foreignerorganization");
            });

            modelBuilder.Entity<Inspectlog>(entity =>
            {
                entity.ToTable("inspectlog");

                entity.HasIndex(e => e.Foreigner)
                    .HasName("personlog_idx");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Foreigner)
                    .HasColumnName("foreigner")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.ForeignerNavigation)
                    .WithMany(p => p.Inspectlog)
                    .HasForeignKey(d => d.Foreigner)
                    .HasConstraintName("logperson");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.ToTable("organization");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Police>(entity =>
            {
                entity.ToTable("police");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("smallint(2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(45);

                entity.Property(e => e.Online)
                    .HasColumnName("online")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(45);

                entity.Property(e => e.Token)
                    .HasColumnName("token")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Residence>(entity =>
            {
                entity.ToTable("residence");

                entity.HasIndex(e => e.Foreigner)
                    .HasName("foresidence_idx");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(200);

                entity.Property(e => e.Foreigner)
                    .HasColumnName("foreigner")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.ForeignerNavigation)
                    .WithMany(p => p.Residence)
                    .HasForeignKey(d => d.Foreigner)
                    .HasConstraintName("foresidence");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("task");

                entity.HasIndex(e => e.Foreigner)
                    .HasName("taskperson_idx");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Police)
                    .HasName("taskpolice_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Foreigner)
                    .HasColumnName("foreigner")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Police)
                    .HasColumnName("police")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.ForeignerNavigation)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.Foreigner)
                    .HasConstraintName("taskperson");

                entity.HasOne(d => d.PoliceNavigation)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.Police)
                    .HasConstraintName("taskpolice");
            });
        }
    }
}
