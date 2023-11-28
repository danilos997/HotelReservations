using Application.DTO.Hotel;
using Infrastructure.Services.Hotel;
using Microsoft.AspNetCore.Mvc;

namespace Interface.Controllers
{
    [ApiController]
    [Route("hotel")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<HotelDTO> CreateHotelAsync([FromBody] HotelDTO hotel)
        {
            return await _hotelService.CreateHotelAsync(hotel);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<HotelDTO>> GetHotelsAsync()
        {
            return await _hotelService.GetHotelsAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<HotelDTO?> GetHotelAsync(string id)
        {
            return await _hotelService.GetHotelAsync(id);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<HotelDTO> UpdateHotelAsync([FromBody] HotelDTO hotel)
        {
            return await _hotelService.UpdateHotelAsync(hotel);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteHotelAsync([FromRoute] string id)
        {
            await _hotelService.DeleteHotelAsync(id);
        }

    }
}