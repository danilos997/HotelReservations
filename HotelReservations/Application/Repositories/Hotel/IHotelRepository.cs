using Entities = Infrastructure.Entities;

namespace Application.Repositories.Hotel
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Entities.Hotel>> GetHotelsAsync();

        Task<int> CreateHotelAsync(Entities.Hotel hotel);

        Task<Entities.Hotel?> GetHotelAsync(int id);

        Task DeleteHotelAsync(Entities.Hotel hotel);
    }
}
