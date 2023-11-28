using Infrastructure.AppContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Visitor
{
    public class VisitorRepository : IVisitorRepository
    {
        private readonly HotelDbContext _dbContext;

        public VisitorRepository(HotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateVisitorAsync(Entities.Visitor visitor)
        {
            await _dbContext.Visitor.AddAsync(visitor);
            await _dbContext.SaveChangesAsync();
            return visitor.Id;
        }

        public async Task<IEnumerable<Entities.Visitor>> GetVisitorsAsync()
        {
            return await _dbContext.Visitor.ToListAsync();
        }

        public async Task<Entities.Visitor?> GetVisitorAsync(int id)
        {
            return await _dbContext.Visitor.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Entities.Visitor> UpdateVisitorAsync(Entities.Visitor visitor)
        {
            _dbContext.Visitor.Update(visitor);
            await _dbContext.SaveChangesAsync();
            return visitor;
        }

        public async Task DeleteVisitorAsync(Entities.Visitor visitor)
        {
            _dbContext.Visitor.Remove(visitor);
            await _dbContext.SaveChangesAsync();
        }
    }
}
