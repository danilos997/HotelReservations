using Application.DTO.Hotel;
using Application.DTO.Reservation;
using Infrastructure.Repositories.Hotel;

namespace Infrastructure.Services.Hotel
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<HotelDTO> CreateHotelAsync(HotelDTO hotel)
        {
            var hotelEntitiyToCreate = new Entities.Hotel()
            {
                Name = hotel.Name
            };
            hotel.Id = (await _hotelRepository.CreateHotelAsync(hotelEntitiyToCreate)).ToString();
            return hotel;
        }
        public async Task<IEnumerable<HotelDTO>> GetHotelsAsync()
        {
            var hotels = await _hotelRepository.GetHotelsAsync();
            if (hotels?.Any() != true)
            {
                return Enumerable.Empty<HotelDTO>();
            }

            return hotels.Select(x => new HotelDTO
            {
                Id = x.Id.ToString(),
                Name = x.Name
            });
        }

        public async Task<HotelDTO?> GetHotelAsync(string id)
        {
            if (!int.TryParse(id, out var intId))
            {
                throw new ArgumentException($"{nameof(id)} cannot be parsed, not a valid integer format");
            }

            var hotel = await _hotelRepository.GetHotelAsync(intId);
            if (hotel is null)
            {
                throw new ArgumentNullException($"{nameof(hotel)} cannot be null, hotel does not exist");
            }

            var reservationsDto = hotel.Reservations?
                .Select(x => new ReservationDTO
                {
                    Id = x.Id.ToString(),
                    HotelId = x.HotelId.ToString(),
                    VisitorId = x.VisitorId.ToString(),
                    StartDate = x.StartDate.ToString(),
                    EndDate = x.EndDate.ToString()
                });

            return new HotelDTO()
            {
                Id = hotel.Id.ToString(),
                Name = hotel.Name,
                Reservations = reservationsDto
            };
        }

        public async Task<HotelDTO> UpdateHotelAsync(HotelDTO hotel)
        {
            if (hotel is null && hotel?.Id is null)
            {
                throw new ArgumentNullException($"{nameof(hotel)} cannot be null, provide an existing hotel");
            }

            if (int.TryParse(hotel.Id, out var id))
            {
                var hotelToUpdate = new Entities.Hotel()
                {
                    Id = id,
                    Name = hotel.Name,
                };
                await _hotelRepository.UpdateHotelAsync(hotelToUpdate);
            }
            else
            {
                throw new ArgumentException($"{nameof(hotel)} {nameof(hotel.Id)} is not a valid identifier, provider an valid int id");
            }

            return hotel;
        }
        public async Task DeleteHotelAsync(string id)
        {
            if (!int.TryParse(id, out var intId))
            {
                throw new ArgumentException($"{nameof(id)} cannot be parsed, not a valid integer format");
            }

            var hotel = await _hotelRepository.GetHotelAsync(intId);
            if (hotel is not null)
            {
                await _hotelRepository.DeleteHotelAsync(hotel);
                return;
            }
            throw new ArgumentNullException($"{nameof(hotel)} cannot be null, cannot delete non-existing hotel");
        }
    }
}
