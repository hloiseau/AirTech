using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using AirTech.Shared;

namespace AirTech.Server.Service
{
    public partial class DatabaseService : DbContext
    {
        public DatabaseService()
        {
        }

        public DatabaseService(DbContextOptions<DatabaseService> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        private IConfiguration _configuration;
        public virtual DbSet<Airport> Airport { get; set; }
        public virtual DbSet<Billet> Billet { get; set; }
        public virtual DbSet<BilletCount> BilletCount { get; set; }
        public virtual DbSet<Travel> Travel { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Sql_coString"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airport>(entity =>
            {
                entity.HasKey(e => e.Nom);

                entity.Property(e => e.Nom)
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Billet>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.IdBilletNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdBillet)
                    .HasConstraintName("FK_Billet_Travel");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Billet_User");
            });

            modelBuilder.Entity<BilletCount>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.IdBilletNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdBillet)
                    .HasConstraintName("FK_BilletCount_Travel");
            });

            modelBuilder.Entity<Travel>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.From)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.To)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.FromNavigation)
                    .WithMany(p => p.TravelFromNavigation)
                    .HasForeignKey(d => d.From)
                    .HasConstraintName("FK_Travel_Airport1");

                entity.HasOne(d => d.ToNavigation)
                    .WithMany(p => p.TravelToNavigation)
                    .HasForeignKey(d => d.To)
                    .HasConstraintName("FK_Travel_Airport");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
