namespace yatirimtakip_backend.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float Open { get; set; }
        public float High { get; set; }
        public float Low { get; set; }
        public float Close { get; set; }
        public float Volume { get; set; }
        public string Symbol { get; set; } = null!;

        public ICollection<Investment> Investments { get; set; } = new List<Investment>();
    }
}