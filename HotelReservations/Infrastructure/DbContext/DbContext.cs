using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.AppContext
{
    public class HotelDbContext : DbContext
    {
        public DbSet<Hotel> Hotel { get; set; }

        public DbSet<Visitor> Visitor { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Hotel).Assembly);
        }
    }
}
