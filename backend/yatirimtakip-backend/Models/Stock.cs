namespace yatirimtakip_backend.Models
{
    public class Stock
    {
        public int StockID { get; set; }
        public string SName { get; set; } = null!; // Matches investments.Type
        public float PriceLast { get; set; }
        public float Difference { get; set; }
        public float CloseLast { get; set; }
        public float DailyLow { get; set; }
        public float DailyHigh { get; set; }
        public float Vol { get; set; }
        public DateTime Time { get; set; }

        public ICollection<Investment> Investments { get; set; } = new List<Investment>();
    }
}
