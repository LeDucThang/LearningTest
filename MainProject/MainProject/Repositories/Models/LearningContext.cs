using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MainProject.Repositories.Models
{
    public partial class LearningContext : DbContext
    {
        public virtual DbSet<OrganizationDAO> Organization { get; set; }
        public virtual DbSet<PositionDAO> Position { get; set; }
        public virtual DbSet<Position_UserDAO> Position_User { get; set; }
        public virtual DbSet<UserDAO> User { get; set; }
        public virtual DbSet<__MigrationLogDAO> __MigrationLog { get; set; }
        // Unable to generate entity type for table 'dbo.__SchemaSnapshot'. Please see the warning messages.


        public LearningContext(DbContextOptions<LearningContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=.;initial catalog=Learning;persist security info=True;user id=sa;password=123456a@;multipleactiveresultsets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<OrganizationDAO>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PositionDAO>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.Positions)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Position_Organization");
            });

            modelBuilder.Entity<Position_UserDAO>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Position_Users)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Position_User_Position");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Position_Users)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Position_User_User");
            });

            modelBuilder.Entity<UserDAO>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<__MigrationLogDAO>(entity =>
            {
                entity.HasKey(e => new { e.migration_id, e.complete_dt, e.script_checksum });

                entity.HasIndex(e => e.complete_dt)
                    .HasName("IX___MigrationLog_CompleteDt");

                entity.HasIndex(e => e.sequence_no)
                    .HasName("UX___MigrationLog_SequenceNo")
                    .IsUnique();

                entity.HasIndex(e => e.version)
                    .HasName("IX___MigrationLog_Version");

                entity.Property(e => e.script_checksum).HasMaxLength(64);

                entity.Property(e => e.applied_by)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.deployed).HasDefaultValueSql("((1))");

                entity.Property(e => e.package_version)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.release_version)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.script_filename)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.sequence_no).ValueGeneratedOnAdd();

                entity.Property(e => e.version)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingExt(modelBuilder);
        }

        partial void OnModelCreatingExt(ModelBuilder modelBuilder);
    }
}
