using Microsoft.AspNetCore.Mvc;
using yatirimtakip_backend.Models;
using yatirimtakip_backend.Repositories;

namespace yatirimtakip_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IGenericRepository<Stock> _repository;

        public StocksController(IGenericRepository<Stock> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStocks()
        {
            var stocks = await _repository.GetAllAsync();
            return Ok(stocks);
        }
    }
}
