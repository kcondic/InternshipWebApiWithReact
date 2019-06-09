using InternshipWebApiWithReact.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InternshipWebApiWithReact.Data.Models
{
    public class InternshipWebApiWithReactContext : DbContext
    {
        public InternshipWebApiWithReactContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Airport> Airports { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<PassengerFlight> PassengerFlights { get; set; }
        public DbSet<Plane> Planes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PassengerFlight>()
                .HasKey(pf => new { pf.PassengerId, pf.FlightId });
            modelBuilder.Entity<PassengerFlight>()
                .HasOne(pf => pf.Passenger)
                .WithMany(p => p.PassengerFlights)
                .HasForeignKey(pf => pf.PassengerId);
            modelBuilder.Entity<PassengerFlight>()
                .HasOne(pf => pf.Flight)
                .WithMany(f => f.PassengerFlights)
                .HasForeignKey(pf => pf.FlightId);

            modelBuilder.Entity<Flight>()
                .HasOne(f => f.SourceAirport)
                .WithMany(sa => sa.FromFlights);
            modelBuilder.Entity<Flight>()
                .HasOne(f => f.DestinationAirport)
                .WithMany(da => da.ToFlights);
        }
    }
}
