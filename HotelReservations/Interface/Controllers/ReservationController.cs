using Application.DTO.Hotel;
using Application.DTO.Reservation;
using Application.Services.Reservations;
using Microsoft.AspNetCore.Mvc;

namespace Interface.Controllers
{
    [ApiController]
    [Route("reservation")]
    public class ReservationController : ControllerBase
    {

        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ReservationDTO> CreateReservationAsync([FromBody] ReservationDTO reservation)
        {
            return await _reservationService.CreateReservationAsync(reservation);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<ReservationDTO>> GetReservationsAsync()
        {
            return await _reservationService.GetReservationsAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ReservationDTO?> GetReservationAsync(string id)
        {
            return await _reservationService.GetReservationAsync(id);
        }
        [HttpPut]

        [Route("{id}")]
        public async Task<ReservationDTO> UpdateReservationAsync([FromBody] ReservationDTO reservation)
        {
            return await _reservationService.UpdateReservationAsync(reservation);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteReservationAsync([FromRoute] string id)
        {
            await _reservationService.DeleteReservationAsync(id);
        }
    }
}
