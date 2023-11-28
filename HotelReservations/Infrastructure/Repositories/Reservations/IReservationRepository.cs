namespace Infrastructure.Repositories.Reservation
{
    public interface IReservationRepository
    {
        Task<int> CreateReservationAsync(Entities.Reservation reservation);

        Task<IEnumerable<Entities.Reservation>> GetReservationsAsync();

        Task<Entities.Reservation?> GetReservationAsync(int id);

        Task<Entities.Reservation> UpdateReservationAsync(Entities.Reservation reservation);

        Task DeleteReservationAsync(Entities.Reservation reservation);
    }
}
