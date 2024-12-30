namespace yatirimtakip_backend.Models
{
    public class Stock
    {
        public int StockID { get; set; }
        public string SName { get; set; } = null!; // Matches investments.Type
        public DateTime Date { get; set; }
        public string Symbol { get; set; } = null!;
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public double Volume { get; set; }
    }
}