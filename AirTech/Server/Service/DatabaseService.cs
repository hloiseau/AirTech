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
        public virtual DbSet<Shared.Client> Client { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Travel> Travel { get; set; }
        public virtual DbSet<Voyager> Voyager { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration["SqlCoString"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airport>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.Property(e => e.Name)
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Billet>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.UnitPrice).HasColumnName("unitPrice");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.Billet)
                    .HasForeignKey(d => d.IdOrder)
                    .HasConstraintName("FK_Billet_Order");

                entity.HasOne(d => d.IdTravelNavigation)
                    .WithMany(p => p.Billet)
                    .HasForeignKey(d => d.IdTravel)
                    .HasConstraintName("FK_Billet_Travel");

                entity.HasOne(d => d.Voyager)
                    .WithMany(p => p.Billet)
                    .HasForeignKey(d => d.VoyagerId)
                    .HasConstraintName("FK_Billet_Voyager");
            });


            modelBuilder.Entity<Shared.Client>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.TotalAmount).HasColumnName("totalAmount");

                entity.HasOne(d => d.Cilent)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CilentId)
                    .HasConstraintName("FK_Order_Client");
            });

            modelBuilder.Entity<Travel>(entity =>
            {
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

            modelBuilder.Entity<Voyager>(entity =>
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
