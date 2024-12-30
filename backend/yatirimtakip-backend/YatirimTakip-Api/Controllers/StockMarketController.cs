using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using yatirimtakip_backend.Services;
using yatirimtakip_backend.Data;
using Microsoft.EntityFrameworkCore;

namespace yatirimtakip_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockMarketController : ControllerBase
    {
        private readonly StockService _stockService;
        private readonly ApplicationDbContext _context;

        public StockMarketController(StockService stockService, ApplicationDbContext context)
        {
            _stockService = stockService;
            _context = context;
        }

        [HttpGet("daily")]
        public async Task<IActionResult> GetDailyStockData([FromQuery] string symbol = "IBM")
        {
            var data = await _stockService.GetStockDataAsync(symbol);
            return Ok(data);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllStockData()
        {
            var stocks = await _context.Stocks.ToListAsync();
            return Ok(stocks);
        }
    }
}