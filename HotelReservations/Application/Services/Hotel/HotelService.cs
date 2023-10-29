using Application.Repositories.Hotel;
using Entities = Infrastructure.Entities;

namespace Application.Services.Hotel
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<Entities.Hotel> CreateHotelAsync(Entities.Hotel hotel)
        {
            var hotelId = await _hotelRepository.CreateHotelAsync(hotel);
            return (await _hotelRepository.GetHotelAsync(hotelId))!;
        }

        public async Task DeleteHotelAsync(int id)//nadjes hotel - proveris da li postoji - ako ima brisemo - ako nema exception
        {
            throw new NotImplementedException();
        }

        public async Task<Entities.Hotel?> GetHotelAsync(int id)
        {
            return await _hotelRepository.GetHotelAsync(id);
        }

        public async Task<IEnumerable<Entities.Hotel>> GetHotelsAsync()
        {
            return await _hotelRepository.GetHotelsAsync();
        }

        public async Task<Entities.Hotel> UpdateHotelAsync(Entities.Hotel hotel)
        {
            throw new NotImplementedException();
        }
    }
}
