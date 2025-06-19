using Microsoft.EntityFrameworkCore;
using TravelAgency.Models;

namespace TravelAgency.Data
{
    public class TravelAgencyContext : DbContext
    {
        public class Main{}
        public TravelAgencyContext(DbContextOptions<TravelAgencyContext> options)
            : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<TourPackage> TourPackages { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TourPackage>()
                .HasMany(tp => tp.Destinations)
                .WithMany(d => d.TourPackages)
                .UsingEntity(j => j.ToTable("TourPackageDestinations"));

            modelBuilder.Entity<Reservation>()
                .HasIndex(r => new { r.ClientId, r.TourPackageId, r.ReservationDate })
                .IsUnique();
        }
    }
}
