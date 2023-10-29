using Infrastructure.AppContext;
using Microsoft.EntityFrameworkCore;
using Entities = Infrastructure.Entities;

namespace Application.Repositories.Hotel
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelDbContext _dbContext;

        public HotelRepository(HotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateHotelAsync(Entities.Hotel hotel)
        {
            await _dbContext.Hotel.AddAsync(hotel);
            await _dbContext.SaveChangesAsync();
            return hotel.Id;
        }

        public async Task<Entities.Hotel?> GetHotelAsync(int id)
        {
            return await _dbContext.Hotel.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task DeleteHotelAsync(Entities.Hotel hotel)
        {
            _dbContext.Hotel.Remove(hotel);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Entities.Hotel>> GetHotelsAsync()
        {
            return await _dbContext.Hotel.ToListAsync();
        }
    }
}
