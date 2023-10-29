using Entities = Infrastructure.Entities;

namespace Application.Repositories.Visitor
{
    public interface IVisitorRepository
    {
        Task<IEnumerable<Entities.Visitor>> GetVisitorsAsync();

        Task<int> CreateVisitorAsync(Entities.Visitor visitor);

        Task<Entities.Visitor?> GetVisitorAsync(int id);

        Task DeleteVisitorAsync(Entities.Visitor visitor);
    }
}
