using AirTech.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AirTech.Server.Service
{
    public class DatabaseService : DbContext
    {
        private IConfiguration _configuration;

        public DatabaseService(DbContextOptions<DatabaseService> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public virtual DbSet<Travel> Travel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Sql_coString"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Travel>(entity =>
            {
                entity.Property(e => e.ID).HasColumnName("id");

                entity.Property(e => e.From)
                    .IsRequired()
                    .HasColumnName("From")
                    .IsUnicode(false);

                entity.Property(e => e.To)
                    .IsRequired()
                    .HasColumnName("To")
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasColumnName("Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasColumnName("Price")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.ID).HasColumnName("id");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("LastName")
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("FirstName")
                    .IsUnicode(false);
            });
        }
    }
}