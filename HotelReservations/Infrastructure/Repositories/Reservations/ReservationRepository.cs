using Infrastructure.AppContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Reservation
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly HotelDbContext _dbContext;

        public ReservationRepository(HotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateReservationAsync(Entities.Reservation reservation)
        {
            _dbContext.Reservations.Add(reservation);
            await _dbContext.SaveChangesAsync();
            return reservation.Id;
        }

        public async Task<Entities.Reservation?> GetReservationAsync(int id)
        {
            return await _dbContext.Reservations
                .Where(x => x.Id == id)
                .Include(x => x.Hotel)
                .Include(x => x.Visitor)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Entities.Reservation>> GetReservationsAsync()
        {
            return await _dbContext.Reservations.ToListAsync();
        }

        public async Task<Entities.Reservation> UpdateReservationAsync(Entities.Reservation reservation)
        {
            _dbContext.Reservations.Update(reservation);
            await _dbContext.SaveChangesAsync();
            return reservation;
        }
        public async Task DeleteReservationAsync(Entities.Reservation reservation)
        {
            _dbContext.Remove(reservation);
            await _dbContext.SaveChangesAsync();
        }
    }
}
