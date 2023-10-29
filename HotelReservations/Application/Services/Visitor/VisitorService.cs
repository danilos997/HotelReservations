using Application.Repositories.Visitor;
using Infrastructure.Entities;
using Entities = Infrastructure.Entities;
namespace Application.Services.Visitor
{
    public class VisitorService : IVisitorService
    {
        private readonly IVisitorRepository _visitorRepository;

        public VisitorService(IVisitorRepository visitorRepository)
        {
            _visitorRepository = visitorRepository;
        }

        public async Task<Entities.Visitor> CreateVisitorAsync(Entities.Visitor visitor)
        {
            var visitorId = await _visitorRepository.CreateVisitorAsync(visitor);
            return (await _visitorRepository.GetVisitorAsync(visitorId))!;
        }

        public Task DeleteVisitorAsync(Entities.Visitor visitor)
        {
            throw new NotImplementedException();
        }

        public async Task<Entities.Visitor?> GetVisitorAsync(int id)
        {
            return await _visitorRepository.GetVisitorAsync(id);
        }

        public async Task<IEnumerable<Entities.Visitor>> GetVisitorsAsync()
        {
            return await _visitorRepository.GetVisitorsAsync();
        }

        public Task<Entities.Visitor> UpdateVisitorAsync(Entities.Visitor visitor)
        {
            throw new NotImplementedException();
        }
    }
}
