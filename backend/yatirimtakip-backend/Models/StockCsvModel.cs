using CsvHelper.Configuration.Attributes;

namespace yatirimtakip_backend.Models
{
    public class StockCsvModel
    {
        public DateTime Date { get; set; }
        public float Open { get; set; }
        public float High { get; set; }
        public float Low { get; set; }
        public float Close { get; set; }
        
        [Name("Adj Close")]
        public float AdjClose { get; set; }
        
        public float Volume { get; set; }
    }
}