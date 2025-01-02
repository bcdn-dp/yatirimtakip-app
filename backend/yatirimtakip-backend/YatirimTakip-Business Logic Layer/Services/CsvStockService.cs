using System.Globalization;
using yatirimtakip_backend.Data;
using yatirimtakip_backend.Models;
using CsvHelper;
using Microsoft.EntityFrameworkCore;

namespace yatirimtakip_backend.Services
{
    public class CsvStockService : ICsvStockService
    {
        private readonly ApplicationDbContext _context;

        public CsvStockService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task ImportCsvAsync(string filePath)
        {
            try
            {
                using var reader = new StreamReader(filePath);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

                // Parse CSV file into a list of StockCsvModel objects
                var stockCsvModels = csv.GetRecords<StockCsvModel>().ToList();

                // Extract the symbol from the file name
                var symbol = Path.GetFileNameWithoutExtension(filePath);

                // Filter records for the year 2024 and remove duplicates
                var filteredStocks = stockCsvModels
                    .Where(s => s.Date.Year == 2024)
                    .GroupBy(s => new { s.Date, s.Open, s.High, s.Low, s.Close, s.Volume })
                    .Select(g => g.First())
                    .ToList();

                // Map StockCsvModel to Stock
                var stocks = filteredStocks.Select(s => new Stock
                {
                    Date = DateTime.SpecifyKind(s.Date, DateTimeKind.Utc),
                    Open = s.Open,
                    High = s.High,
                    Low = s.Low,
                    Close = s.Close,
                    Volume = s.Volume,
                    Symbol = symbol
                }).ToList();

                // Check for existing records in the database
                var existingStocks = await _context.Stocks
                    .Where(s => s.Date.Year == 2024)
                    .ToListAsync();

                // Add only new records to the database
                var newStocks = stocks
                    .Where(s => !existingStocks.Any(e => 
                        e.Date == s.Date &&
                        e.Open == s.Open &&
                        e.High == s.High &&
                        e.Low == s.Low &&
                        e.Close == s.Close &&
                        e.Volume == s.Volume &&
                        e.Symbol == s.Symbol))
                    .ToList();

                // Add new records to the database
                _context.Stocks.AddRange(newStocks);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                
                throw new Exception("Error importing CSV data", ex);
            }
        }
    }
}