using System.Threading.Tasks;

namespace yatirimtakip_backend.Services
{
    public interface ICsvStockService
    {
        Task ImportCsvAsync(string filePath);
    }
}
