using Application.Repositories.Visitor;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

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
        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<Visitor>> GetVisitorsAsync()
        {
            return await _visitorRepository.GetVisitorsAsync();
        }

        [HttpPost]
        [Route("create")]
        public async Task<int> CreateVisitorAsync([FromBody] Visitor visitor)
        {
            return await _visitorRepository.CreateVisitorAsync(visitor);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<Visitor?> GetVisitorAsync(int id)
        {
            return await _visitorRepository.GetVisitorAsync(id);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task DeleteVisitor([FromBody] Visitor visitor)
        {
            await _visitorRepository.DeleteVisitorAsync(visitor);
        }
    }
}
