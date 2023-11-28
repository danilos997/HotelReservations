using Application.DTO.Hotel;

namespace Infrastructure.Services.Hotel
{
    public interface IHotelService
    {
        Task<HotelDTO> CreateHotelAsync(HotelDTO hotel);

        Task<IEnumerable<HotelDTO>> GetHotelsAsync();

        Task<HotelDTO?> GetHotelAsync(string id);

        Task<HotelDTO> UpdateHotelAsync(HotelDTO hotel);

        Task DeleteHotelAsync(string id);
    }
}
