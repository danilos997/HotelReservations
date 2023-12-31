﻿using Infrastructure.AppContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Hotel
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

        public async Task<IEnumerable<Entities.Hotel>> GetHotelsAsync()
        {
            return await _dbContext.Hotel.ToListAsync();
        }

        public async Task<Entities.Hotel?> GetHotelAsync(int id)
        {
            return await _dbContext.Hotel
                .Where(x => x.Id == id)
                .Include(x => x.Reservations)
                .FirstOrDefaultAsync();
        }

        public async Task<Entities.Hotel> UpdateHotelAsync(Entities.Hotel hotel)
        {
            _dbContext.Hotel.Update(hotel);
            await _dbContext.SaveChangesAsync();
            return hotel;
        }

        public async Task DeleteHotelAsync(Entities.Hotel hotel)
        {
            _dbContext.Hotel.Remove(hotel);
            await _dbContext.SaveChangesAsync();
        }
    }
}
