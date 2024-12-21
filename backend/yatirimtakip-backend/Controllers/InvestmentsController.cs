using Microsoft.AspNetCore.Mvc;
using yatirimtakip_backend.Models;
using yatirimtakip_backend.Repositories;

namespace yatirimtakip_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentsController : ControllerBase
    {
        private readonly IGenericRepository<Investment> _repository;

        public InvestmentsController(IGenericRepository<Investment> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInvestments()
        {
            var investments = await _repository.GetAllAsync();
            return Ok(investments);
        }
    }
}
