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

            //Voyages
            modelBuilder.Entity<Voyage>().HasData(
                new Voyage
                {
                    Id = 1,
                    ShipId = 1,
                    DeparturePortId = 1,
                    ArrivalPortId = 2,
                    VoyageDate = new DateTime(2023, 5, 10),
                    StartDate = new DateTime(2023, 5, 10),
                    EndDate = new DateTime(2023, 5, 20)
                },
                new Voyage
                {
                    Id = 2,
                    ShipId = 2,
                    DeparturePortId = 2,
                    ArrivalPortId = 3,
                    VoyageDate = new DateTime(2023, 6, 1),
                    StartDate = new DateTime(2023, 6, 1),
                    EndDate = new DateTime(2023, 6, 12)
                }
            );

            //VisitedCountries
            modelBuilder.Entity<VisitedCountry>().HasData(
                new VisitedCountry
                {
                    Id = 1,
                    CountryName = "Bulgaria",
                    VisitDate = new DateTime(2023, 5, 12),
                    VoyageId = 1
                },
                new VisitedCountry
                {
                    Id = 2,
                    CountryName = "Germany",
                    VisitDate = new DateTime(2023, 6, 5),
                    VoyageId = 2
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
