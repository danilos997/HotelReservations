using Application.DTO.Hotel;
using Application.DTO.Visitor;

namespace Application.DTO.Reservation
{
    public class ReservationDTO
    {
        public string? Id { get; set; }

        public required string HotelId { get; set; }

        public required string VisitorId { get; set; }

        public required string StartDate { get; set; }

        public required string EndDate { get; set; }

        public HotelDTO? Hotel { get; set; }

        public VisitorDTO? Visitor { get; set; }
    }
}
