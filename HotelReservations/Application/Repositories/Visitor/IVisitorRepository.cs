using Entities = Infrastructure.Entities;

namespace Application.Repositories.Visitor
{
    public interface IVisitorRepository
    {
        Task<int> CreateVisitorAsync(Entities.Visitor visitor);

        Task<IEnumerable<Entities.Visitor>> GetVisitorsAsync();

        Task<Entities.Visitor?> GetVisitorAsync(int id);

        Task<Entities.Visitor> UpdateVisitorAsync(Entities.Visitor visitor);

        Task DeleteVisitorAsync(Entities.Visitor visitor);
    }
}
