using Application.Repositories.Hotel;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Interface.Controllers
{
    [ApiController]
    [Route("hotel")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<int> CreateHotelAsync([FromBody] Hotel hotel)
        {
            return await _hotelRepository.CreateHotelAsync(hotel);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<Hotel>> GetHotelsAsync()
        {
            return await _hotelRepository.GetHotelsAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Hotel?> GetHotelAsync(int id)
        {
            return await _hotelRepository.GetHotelAsync(id);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<Hotel> UpdateHotelAsync([FromBody] Hotel hotel)
        {
            return await _hotelRepository.UpdateHotelAsync(hotel);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteHotelAsync([FromBody] Hotel hotel)
        {
            await _hotelRepository.DeleteHotelAsync(hotel);
        }

    }
}