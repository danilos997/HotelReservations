using Application.DTO.Visitor;
using Infrastructure.Services.Visitor;
using Microsoft.AspNetCore.Mvc;

namespace Interface.Controllers
{
    [ApiController]
    [Route("visitor")]
    public class VisitorController : ControllerBase
    {
        private readonly IVisitorService _visitorService;

        public VisitorController(IVisitorService visitorService)
        {
            _visitorService = visitorService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<VisitorDTO> CreateVisitorAsync([FromBody] VisitorDTO visitor)
        {
            return await _visitorService.CreateVisitorAsync(visitor);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<VisitorDTO>> GetVisitorsAsync()
        {
            return await _visitorService.GetVisitorsAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<VisitorDTO?> GetVisitorAsync(string id)
        {
            return await _visitorService.GetVisitorAsync(id);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<VisitorDTO> UpdateVisitorAsync([FromBody] VisitorDTO visitor)
        {
            return await _visitorService.UpdateVisitorAsync(visitor);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteVisitor([FromRoute] string id)
        {
            await _visitorService.DeleteVisitorAsync(id);
        }
    }
}
