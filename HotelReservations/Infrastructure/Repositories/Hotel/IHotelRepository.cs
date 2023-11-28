namespace Infrastructure.Repositories.Hotel
{
    public interface IHotelRepository
    {
        Task<int> CreateHotelAsync(Entities.Hotel hotel);

        Task<IEnumerable<Entities.Hotel>> GetHotelsAsync();

        Task<Entities.Hotel?> GetHotelAsync(int id);

        Task<Entities.Hotel> UpdateHotelAsync(Entities.Hotel hotel);

        Task DeleteHotelAsync(Entities.Hotel hotel);
    }
}
