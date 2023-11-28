using Application.DTO.Reservation;

namespace Application.DTO.Hotel
{
    public class HotelDTO
    {
        public string? Id { get; set; }
        public required string Name { get; set; }
        public IEnumerable<ReservationDTO>? Reservations { get; set; }
    }
}
