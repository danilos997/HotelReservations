using Application.DTO.Reservation;

namespace Application.DTO.Visitor
{
    public class VisitorDTO
    {
        public string? Id { get; set; }

        public required string Name { get; set; }

        public required string Surname { get; set; }

        public required string Email { get; set; }

        public IEnumerable<ReservationDTO>? Reservations { get; set; }
    }
}
