using Application.Repositories.Visitor;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Interface.Controllers
{
    [ApiController]
    [Route("visitor")]
    public class VisitorController : ControllerBase
    {
        private readonly IVisitorRepository _visitorRepository;

        public VisitorController(IVisitorRepository visitorRepository)
        {
            _visitorRepository = visitorRepository;
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<int> CreateVisitorAsync([FromBody] Visitor visitor)
        {
            return await _visitorRepository.CreateVisitorAsync(visitor);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<Visitor>> GetVisitorsAsync()
        {
            return await _visitorRepository.GetVisitorsAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Visitor?> GetVisitorAsync(int id)
        {
            return await _visitorRepository.GetVisitorAsync(id);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<Visitor> UpdateVisitorAsync([FromBody] Visitor visitor)
        {
            return await _visitorRepository.UpdateVisitorAsync(visitor);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteVisitor([FromBody] Visitor visitor)
        {
            await _visitorRepository.DeleteVisitorAsync(visitor);
        }
    }
}
