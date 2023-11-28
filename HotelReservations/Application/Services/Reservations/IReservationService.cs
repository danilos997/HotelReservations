using Application.DTO.Reservation;

namespace Application.Services.Reservations
{
    public interface IReservationService
    {
        Task<ReservationDTO> CreateReservationAsync(ReservationDTO reservation);

        Task<IEnumerable<ReservationDTO>> GetReservationsAsync();

        Task<ReservationDTO?> GetReservationAsync(string id);

        Task<ReservationDTO> UpdateReservationAsync(ReservationDTO hotel);

        Task DeleteReservationAsync(string id);
    }
}
