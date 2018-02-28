using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace foreignermanagement.dbmodel
{
    public partial class fmContext : DbContext
    {
        public virtual DbSet<Counties> Counties { get; set; }
        public virtual DbSet<Foreigner> Foreigner { get; set; }
        public virtual DbSet<Inspectlog> Inspectlog { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<Police> Police { get; set; }
        public virtual DbSet<Policelog> Policelog { get; set; }
        public virtual DbSet<Residence> Residence { get; set; }
        public virtual DbSet<Sourcelog> Sourcelog { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<Taskcounty> Taskcounty { get; set; }
        public virtual DbSet<Tasklog> Tasklog { get; set; }
        public virtual DbSet<Tasksbatch> Tasksbatch { get; set; }
        public virtual DbSet<Trail> Trail { get; set; }

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
            modelBuilder.Entity<Counties>(entity =>
            {
                entity.ToTable("counties");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(45);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(45);
            });

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

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(200);

                entity.Property(e => e.Arrivalreason)
                    .HasColumnName("arrivalreason")
                    .HasMaxLength(45);

                entity.Property(e => e.Arrivaltime)
                    .HasColumnName("arrivaltime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasMaxLength(45);

                entity.Property(e => e.County)
                    .HasColumnName("county")
                    .HasMaxLength(45);

                entity.Property(e => e.Departurereason)
                    .HasColumnName("departurereason")
                    .HasMaxLength(45);

                entity.Property(e => e.Departuretime)
                    .HasColumnName("departuretime")
                    .HasColumnType("blob");

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasColumnType("smallint(2)");

                entity.Property(e => e.Hisorg).HasColumnName("hisorg");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45);

                entity.Property(e => e.Nation)
                    .HasColumnName("nation")
                    .HasMaxLength(45);

                entity.Property(e => e.Organization)
                    .HasColumnName("organization")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Passport)
                    .HasColumnName("passport")
                    .HasMaxLength(45);

                entity.Property(e => e.Passportstatus)
                    .HasColumnName("passportstatus")
                    .HasColumnType("smallint(2)");

                entity.Property(e => e.Residence)
                    .HasColumnName("residence")
                    .HasMaxLength(45);

                entity.Property(e => e.Street)
                    .HasColumnName("street")
                    .HasMaxLength(45);

                entity.Property(e => e.Town)
                    .HasColumnName("town")
                    .HasMaxLength(45);

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

            modelBuilder.Entity<Messages>(entity =>
            {
                entity.ToTable("messages");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Assignees).HasColumnName("assignees");

                entity.Property(e => e.Assigner)
                    .HasColumnName("assigner")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500);

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("datetime");
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

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(200);

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

                entity.Property(e => e.Accesstoken)
                    .HasColumnName("accesstoken")
                    .HasMaxLength(45);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(45);

                entity.Property(e => e.County)
                    .HasColumnName("county")
                    .HasMaxLength(45);

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("smallint(2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(45);

                entity.Property(e => e.Online)
                    .HasColumnName("online")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Permission)
                    .HasColumnName("permission")
                    .HasColumnType("smallint(2)");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(45);

                entity.Property(e => e.Token)
                    .HasColumnName("token")
                    .HasMaxLength(45);

                entity.Property(e => e.Town)
                    .HasColumnName("town")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Policelog>(entity =>
            {
                entity.ToTable("policelog");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Police)
                    .HasName("logpolice_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Inlocation)
                    .HasColumnName("inlocation")
                    .HasMaxLength(45);

                entity.Property(e => e.Intime)
                    .HasColumnName("intime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Outlocation)
                    .HasColumnName("outlocation")
                    .HasMaxLength(45);

                entity.Property(e => e.Outtime)
                    .HasColumnName("outtime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Police)
                    .HasColumnName("police")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.PoliceNavigation)
                    .WithMany(p => p.Policelog)
                    .HasForeignKey(d => d.Police)
                    .HasConstraintName("logpolice");
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
                    .WithMany(p => p.ResidenceNavigation)
                    .HasForeignKey(d => d.Foreigner)
                    .HasConstraintName("foresidence");
            });

            modelBuilder.Entity<Sourcelog>(entity =>
            {
                entity.ToTable("sourcelog");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Begintime)
                    .HasColumnName("begintime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Endtime)
                    .HasColumnName("endtime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Source)
                    .HasColumnName("source")
                    .HasMaxLength(45);

                entity.Property(e => e.Success)
                    .HasColumnName("success")
                    .HasColumnType("tinyint(4)");
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

                entity.Property(e => e.Assigndate)
                    .HasColumnName("assigndate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.Finishdate)
                    .HasColumnName("finishdate")
                    .HasMaxLength(45);

                entity.Property(e => e.Foreigner)
                    .HasColumnName("foreigner")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pictures).HasColumnName("pictures");

                entity.Property(e => e.Police)
                    .HasColumnName("police")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Videos).HasColumnName("videos");

                entity.HasOne(d => d.ForeignerNavigation)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.Foreigner)
                    .HasConstraintName("taskperson");

                entity.HasOne(d => d.PoliceNavigation)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.Police)
                    .HasConstraintName("taskpolice");
            });

            modelBuilder.Entity<Taskcounty>(entity =>
            {
                entity.ToTable("taskcounty");

                entity.HasIndex(e => e.Batchid)
                    .HasName("batchcounty_idx");

                entity.HasIndex(e => e.County)
                    .HasName("fktaskcounty_idx");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Batchid)
                    .HasColumnName("batchid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.County)
                    .HasColumnName("county")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Finished)
                    .HasColumnName("finished")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Batch)
                    .WithMany(p => p.Taskcounty)
                    .HasForeignKey(d => d.Batchid)
                    .HasConstraintName("batchcounty");

                entity.HasOne(d => d.CountyNavigation)
                    .WithMany(p => p.Taskcounty)
                    .HasForeignKey(d => d.County)
                    .HasConstraintName("fktaskcounty");
            });

            modelBuilder.Entity<Tasklog>(entity =>
            {
                entity.ToTable("tasklog");

                entity.HasIndex(e => e.Foreigner)
                    .HasName("tasklogperson_idx");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Police)
                    .HasName("tasklogpolice_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Assigndate)
                    .HasColumnName("assigndate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.Finishdate)
                    .HasColumnName("finishdate")
                    .HasMaxLength(45);

                entity.Property(e => e.Foreigner)
                    .HasColumnName("foreigner")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pictures).HasColumnName("pictures");

                entity.Property(e => e.Police)
                    .HasColumnName("police")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Videos).HasColumnName("videos");

                entity.HasOne(d => d.ForeignerNavigation)
                    .WithMany(p => p.Tasklog)
                    .HasForeignKey(d => d.Foreigner)
                    .HasConstraintName("tasklogperson");

                entity.HasOne(d => d.PoliceNavigation)
                    .WithMany(p => p.Tasklog)
                    .HasForeignKey(d => d.Police)
                    .HasConstraintName("tasklogpolice");
            });

            modelBuilder.Entity<Tasksbatch>(entity =>
            {
                entity.ToTable("tasksbatch");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Finished)
                    .HasColumnName("finished")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Trail>(entity =>
            {
                entity.ToTable("trail");

                entity.HasIndex(e => e.Foreigner)
                    .HasName("trailforeigner_idx");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Associates).HasColumnName("associates");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500);

                entity.Property(e => e.Eventtime)
                    .HasColumnName("eventtime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Foreigner)
                    .HasColumnName("foreigner")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasMaxLength(45);

                entity.HasOne(d => d.ForeignerNavigation)
                    .WithMany(p => p.Trail)
                    .HasForeignKey(d => d.Foreigner)
                    .HasConstraintName("trailforeigner");
            });
        }
    }
}
