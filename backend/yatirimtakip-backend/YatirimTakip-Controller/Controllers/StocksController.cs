using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yatirimtakip_backend.Models;
using yatirimtakip_backend.Repositories;
using yatirimtakip_backend.Services;
using yatirimtakip_backend.Data;
using Dapper;
using Npgsql;
using Microsoft.Extensions.Logging;

namespace yatirimtakip_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IGenericRepository<Stock> _repository;
        private readonly ICsvStockService _csvStockService;
        private readonly ApplicationDbContext _context;
        private readonly string _connectionString;
        private readonly ILogger<StocksController> _logger;

        public StocksController(IGenericRepository<Stock> repository, ICsvStockService csvStockService, ApplicationDbContext context, ILogger<StocksController> logger)
        {
            _repository = repository;
            _csvStockService = csvStockService;
            _context = context;
            _connectionString = context.Database.GetDbConnection().ConnectionString;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStocks()
        {
            var stocks = await _repository.GetAllAsync();
            return Ok(stocks);
        }

        [HttpGet("by-symbol")]
        public async Task<IActionResult> GetStocksBySymbol(string symbol)
        {
            var stocks = await _context.Stocks.Where(s => s.Symbol == symbol).ToListAsync();
            return Ok(stocks);
        }

        [HttpPost("import-csv")]
        public async Task<IActionResult> ImportCsv()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "stock-file", "IBM.csv");

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("CSV file not found.");
            }

            await _csvStockService.ImportCsvAsync(filePath);

            return Ok("CSV data imported successfully.");
        }

        [HttpDelete("delete-all")]
        public async Task<IActionResult> DeleteAllStocks()
        {
            var stocks = await _repository.GetAllAsync();
            _repository.DeleteRange(stocks);
            await _repository.SaveAsync();

            // Reset the sequence for the Id column using Dapper
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var sequenceName = await connection.QuerySingleOrDefaultAsync<string>("SELECT pg_get_serial_sequence('\"Stocks\"', 'Id')");
                    if (!string.IsNullOrEmpty(sequenceName))
                    {
                        _logger.LogInformation($"Resetting sequence: {sequenceName}");
                        await connection.ExecuteAsync($"ALTER SEQUENCE {sequenceName} RESTART WITH 1");
                    }
                    else
                    {
                        _logger.LogWarning("Sequence name for Stocks.Id not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error resetting sequence for Stocks.Id");
                return StatusCode(500, "Internal server error while resetting sequence.");
            }

            return Ok("All stocks deleted and sequence reset successfully.");
        }
    }
}