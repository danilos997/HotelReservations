using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Entities
{
    public class Reservation
    {
        public int Id { get; set; }

        public int HotelId { get; set; }

        public int VisitorId { get; set; }

        public required DateTime StartDate { get; set; }

        public required DateTime EndDate { get; set; }

        public Hotel? Hotel { get; set; }

        public Visitor? Visitor { get; set; }
    }

    internal class ReservationsEntityConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder
                .HasKey(x => x.Id)
                .IsClustered();

            builder
                .Property(x => x.StartDate)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasPrecision(0);

            builder
                .Property(x => x.EndDate)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasPrecision(0);

            builder
                .HasOne(x => x.Hotel)
                .WithMany(x => x.Reservations)
                .HasForeignKey(x => x.HotelId);

            builder
                .HasOne(x => x.Visitor)
                .WithMany(x => x.Reservations)
                .HasForeignKey(x => x.VisitorId);
        }
    }
}
