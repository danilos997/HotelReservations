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

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<Hotel>> GetHotelsAsync()
        {
            return await _hotelRepository.GetHotelsAsync();
        }

        [HttpPost]
        [Route("create")]
        public async Task<int> CreateHotelAsync([FromBody] Hotel hotel)
        {
            return await _hotelRepository.CreateHotelAsync(hotel);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Hotel?> GetHotelAsync(int id)
        {
            return await _hotelRepository.GetHotelAsync(id);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task DeleteHotelAsync([FromBody]Hotel hotel)
        {
            await _hotelRepository.DeleteHotelAsync(hotel);
        }
        
    }
}