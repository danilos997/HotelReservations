using Application.DTO.Hotel;
using Application.DTO.Reservation;
using Application.DTO.Visitor;
using Infrastructure.Repositories.Reservation;
using System.Security.Cryptography.X509Certificates;
using Entities = Infrastructure.Entities;

namespace Application.Services.Reservations
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationsRepository;

        public ReservationService(IReservationRepository reservationsRepository)
        {
            _reservationsRepository = reservationsRepository;
        }

        public async Task<ReservationDTO> CreateReservationAsync(ReservationDTO reservation)
        {
            var reservationToCreate = new Entities.Reservation()
            {
                HotelId = int.Parse(reservation.HotelId),
                VisitorId = int.Parse(reservation.VisitorId),
                StartDate = DateTime.Parse(reservation.StartDate),
                EndDate = DateTime.Parse(reservation.EndDate),
            };

            reservation.Id = (await _reservationsRepository.CreateReservationAsync(reservationToCreate)).ToString();
            return reservation;
        }

        public async Task<IEnumerable<ReservationDTO>> GetReservationsAsync()
        {
            var reservations = await _reservationsRepository.GetReservationsAsync();
            if(reservations?.Any() != true)
            {
                return Enumerable.Empty<ReservationDTO>();
            }
            return reservations.Select(x => new ReservationDTO
            {
                Id = x.Id.ToString(),
                HotelId = x.HotelId.ToString(),
                VisitorId = x.VisitorId.ToString(),
                StartDate = x.StartDate.ToString(),
                EndDate = x.EndDate.ToString(),
            });
        }

        public async Task<ReservationDTO?> GetReservationAsync(string id)
        {
            if (!int.TryParse(id, out var intId))
            {
                throw new ArgumentException($"{nameof(id)} cannot be parsed, not a valid integer format");
            }

            var reservation = await _reservationsRepository.GetReservationAsync(intId);
            if (reservation is null)
            {
                throw new ArgumentNullException($"{nameof(reservation)} cannot be null, reservation does not exist");
            }

            var hotel = new HotelDTO()
            {
                Id = reservation.HotelId.ToString(),
                Name = reservation.Hotel.Name
            };

            var visitor = new VisitorDTO()
            {
                Id = reservation.VisitorId.ToString(),
                Name = reservation.Visitor.Name,
                Surname = reservation.Visitor.Surname,
                Email = reservation.Visitor.Email,
            };

            return new ReservationDTO()
            {
                Id = reservation.Id.ToString(),
                HotelId = reservation.HotelId.ToString(),
                VisitorId = reservation.VisitorId.ToString(),
                StartDate = reservation.StartDate.ToString(),
                EndDate = reservation.EndDate.ToString(),
                Hotel = hotel,
                Visitor = visitor
            };
        }

        public async Task<ReservationDTO> UpdateReservationAsync(ReservationDTO reservation)
        {
            if (reservation is null && reservation?.Id is null)
            {
                throw new ArgumentNullException($"{nameof(reservation)} cannot be null, provide an existing reservation");
            }

            if (int.TryParse(reservation.Id, out var id))
            {
                var reservationToUpdate = new Entities.Reservation()
                {
                    Id = id,
                    HotelId = int.Parse(reservation.HotelId),
                    VisitorId = int.Parse(reservation.VisitorId),
                    StartDate = DateTime.Parse(reservation.StartDate),
                    EndDate = DateTime.Parse(reservation.EndDate),
                };
                await _reservationsRepository.UpdateReservationAsync(reservationToUpdate);
            }
            else
            {
                throw new ArgumentException($"{nameof(reservation)} {nameof(reservation.Id)} is not a valid identifier, provider an valid int id");
            }

            return reservation;
        }

        public async Task DeleteReservationAsync(string id)
        {
            if (!int.TryParse(id, out var intId))
            {
                throw new ArgumentException($"{nameof(id)} cannot be parsed");
            }

            var reservation = await _reservationsRepository.GetReservationAsync(intId);
            if (reservation is not null)
            {
                await _reservationsRepository.DeleteReservationAsync(reservation);
                return;
            }
        }
    }
}
