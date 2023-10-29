using Entities = Infrastructure.Entities;

namespace Application.Services.Hotel
{
    public interface IHotelService
    {
        Task<Entities.Hotel> CreateHotelAsync(Entities.Hotel hotel);

        Task<IEnumerable<Entities.Hotel>> GetHotelsAsync();

        Task<Entities.Hotel?> GetHotelAsync(int id);

        Task<Entities.Hotel> UpdateHotelAsync(Entities.Hotel hotel);

        Task DeleteHotelAsync(int id);
    }
}
