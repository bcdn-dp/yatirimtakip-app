using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Logging;
using yatirimtakip_backend.Data;
using yatirimtakip_backend.Models;

namespace yatirimtakip_backend.Services
{
    public class StockService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "F3LXI4QAWBXMTCWW";
        private readonly ILogger<StockService> _logger;
        private readonly ApplicationDbContext _context;

        public StockService(HttpClient httpClient, ILogger<StockService> logger, ApplicationDbContext context)
        {
            _httpClient = httpClient;
            _logger = logger;
            _context = context;
        }

        public async Task<JObject> GetStockDataAsync(string symbol)
        {
            var response = await _httpClient.GetAsync($"https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={symbol}&apikey={_apiKey}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            _logger.LogInformation("API Response: {content}", content);

            var json = JObject.Parse(content);
            _logger.LogInformation("Parsed JSON: {json}", json);

            var timeSeries = json["Time Series (Daily)"];
            if (timeSeries != null)
            {
                await SaveStockDataAsync(symbol, timeSeries);
            }
            else
            {
                _logger.LogWarning("Time Series (Daily) data is null for symbol: {symbol}", symbol);
            }

            return json;
        }

        private async Task SaveStockDataAsync(string symbol, JToken timeSeries)
        {
            foreach (var item in timeSeries)
            {
                var date = item.Path;
                var data = item.First;

                if (data != null)
                {
                    var stock = new Stock
                    {
                        SName = symbol,
                        Date = DateTime.Parse(date),
                        Symbol = symbol,
                        Open = data["1. open"]?.Value<decimal>() ?? 0,
                        High = data["2. high"]?.Value<decimal>() ?? 0,
                        Low = data["3. low"]?.Value<decimal>() ?? 0,
                        Close = data["4. close"]?.Value<decimal>() ?? 0,
                        Volume = data["5. volume"]?.Value<double>() ?? 0
                    };

                    _context.Stocks.Add(stock);
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}