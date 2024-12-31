namespace yatirimtakip_backend.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }   // Date of the stock record
        public float Open { get; set; }     // Opening price
        public float High { get; set; }     // Highest price of the day
        public float Low { get; set; }      // Lowest price of the day
        public float Close { get; set; }    // Closing price
        public float Volume { get; set; }   // Volume traded
        public string Symbol { get; set; } = null!; // Symbol of the stock

        public ICollection<Investment> Investments { get; set; } = new List<Investment>(); // Navigation property
    }
}