using Microsoft.EntityFrameworkCore;
using MaritimeWebApp.Server.Models;

namespace MaritimeWebApp.Server.Data
{
    public class MaritimeDbContext : DbContext
    {
        public MaritimeDbContext(DbContextOptions<MaritimeDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ship> Ships { get; set; }
        public DbSet<Port> Ports { get; set; }
        public DbSet<Voyage> Voyages { get; set; }
        public DbSet<VisitedCountry> VisitedCountries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Voyage>()
                .HasOne(v => v.DeparturePort)
                .WithMany()
                .HasForeignKey(v => v.DeparturePortId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Voyage>()
                .HasOne(v => v.ArrivalPort)
                .WithMany()
                .HasForeignKey(v => v.ArrivalPortId)
                .OnDelete(DeleteBehavior.Restrict);

            //Ships
            modelBuilder.Entity<Ship>().HasData(
                new Ship { Id = 1, Name = "Titanic", MaxSpeed = 24 },
                new Ship { Id = 2, Name = "Aurora", MaxSpeed = 30 }
            );

            //Ports
            modelBuilder.Entity<Port>().HasData(
                new Port { Id = 1, Name = "Constanta", Country = "Romania" },
                new Port { Id = 2, Name = "Rotterdam", Country = "Netherlands" },
                new Port { Id = 3, Name = "Hamburg", Country = "Germany" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
