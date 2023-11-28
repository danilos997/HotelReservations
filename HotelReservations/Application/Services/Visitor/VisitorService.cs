using Application.DTO.Reservation;
using Application.DTO.Visitor;
using Infrastructure.Repositories.Visitor;

namespace Infrastructure.Services.Visitor
{
    public class VisitorService : IVisitorService
    {
        private readonly IVisitorRepository _visitorRepository;

        public VisitorService(IVisitorRepository visitorRepository)
        {
            _visitorRepository = visitorRepository;
        }

        public async Task<VisitorDTO> CreateVisitorAsync(VisitorDTO visitor)
        {
            var visitorToCreate = new Entities.Visitor()
            {
                Name = visitor.Name,
                Surname = visitor.Surname,
                Email = visitor.Email
            };

            visitor.Id = (await _visitorRepository.CreateVisitorAsync(visitorToCreate)).ToString();

            return visitor;
        }

        public async Task<IEnumerable<VisitorDTO>> GetVisitorsAsync()
        {
            var visitors = await _visitorRepository.GetVisitorsAsync();
            if (visitors?.Any() != true)
            {
                return Enumerable.Empty<VisitorDTO>();
            }
            return visitors.Select(x => new VisitorDTO()
            {
                Id = x.Id.ToString(),
                Name = x.Name,
                Surname = x.Surname,
                Email = x.Email
            });
        }

        public async Task<VisitorDTO?> GetVisitorAsync(string id)
        {
            if (!int.TryParse(id, out var intId))
            {
                throw new ArgumentException($"{nameof(id)} cannot be parsed, not a valid integer format");
            }

            var visitor = await _visitorRepository.GetVisitorAsync(intId);
            if (visitor is null)
            {
                throw new ArgumentNullException($"{nameof(visitor)} cannot be null, visitor does not exist");
            }

            var reservationsDto = visitor.Reservations?
                .Select(x => new ReservationDTO
                {
                    Id = x.Id.ToString(),
                    HotelId = x.HotelId.ToString(),
                    VisitorId = x.VisitorId.ToString(),
                    StartDate = x.StartDate.ToString(),
                    EndDate = x.EndDate.ToString()
                });

            return new VisitorDTO()
            {
                Id = visitor.Id.ToString(),
                Name = visitor.Name,
                Surname = visitor.Surname,
                Email = visitor.Email,
                Reservations = reservationsDto
            };
        }

        public async Task<VisitorDTO> UpdateVisitorAsync(VisitorDTO visitor)
        {
            if (visitor is null && visitor?.Id is null)
            {
                throw new ArgumentNullException($"{nameof(visitor)} cannot be null, provide an existing visitor");
            }

            if (int.TryParse(visitor.Id, out var id))
            {
                var hotelToUpdate = new Entities.Visitor()
                {
                    Id = id,
                    Name = visitor.Name,
                    Surname = visitor.Surname,
                    Email = visitor.Email
                };
                await _visitorRepository.UpdateVisitorAsync(hotelToUpdate);
            }
            else
            {
                throw new ArgumentException($"{nameof(visitor)} {nameof(visitor.Id)} is not a valid identifier, provider an valid int id");
            }
            return visitor;
        }

        public async Task DeleteVisitorAsync(string id)
        {
            if (!int.TryParse(id, out var intId))
            {
                throw new ArgumentException($"{nameof(id)} cannot be parsed, not a valid integer format");
            }

            var visitor = await _visitorRepository.GetVisitorAsync(intId);
            if (visitor is not null)
            {
                await _visitorRepository.DeleteVisitorAsync(visitor);
                return;
            }
            throw new ArgumentNullException($"{nameof(visitor)} cannot be null, cannot delete non-existing visitor");
        }
    }
}
