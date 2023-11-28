using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Entities
{
    public class Visitor
    {
        public int Id { get; set; }

        public  required string Name { get; set; }

        public  required string Surname { get; set; }

        public required string Email { get; set; }

        public IList<Reservation>? Reservations { get; set; }
    }

    public class VisitorEntityConfiguration : IEntityTypeConfiguration<Visitor>
    {
        public void Configure(EntityTypeBuilder<Visitor> builder)
        {
            builder
                .HasKey(x => x.Id)
                .IsClustered();

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(x => x.Surname)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
