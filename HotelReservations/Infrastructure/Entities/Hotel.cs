using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Entities
{
    public class Hotel
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public IList<Reservations>? Reservations { get; set; }
    }

    public class HotelEntityConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder
                .HasKey(x => x.Id)
                .IsClustered();

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}
