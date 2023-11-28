using Application.DTO.Visitor;
namespace Infrastructure.Services.Visitor

{
    public interface IVisitorService
    {
        Task<VisitorDTO> CreateVisitorAsync(VisitorDTO visitor);

        Task<IEnumerable<VisitorDTO>> GetVisitorsAsync();

        Task<VisitorDTO?> GetVisitorAsync(string id);

        Task<VisitorDTO> UpdateVisitorAsync(VisitorDTO visitor);

        Task DeleteVisitorAsync(string id);
    }
}
