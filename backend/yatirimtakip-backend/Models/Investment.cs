namespace yatirimtakip_backend.Models
{
    public class Investment
    {
        public int InvestID { get; set; }
        public int UserID { get; set; } = 1; // Default UserID
        public int StockID { get; set; } = 1; // Default StockID
        public float UnitPrice { get; set; } = 0.0f; // Default UnitPrice
        public int UnitAmount { get; set; }
        public string Type { get; set; } = "DefaultType"; // Default Type

        public User User { get; set; } = null!; // Navigation property
        public Stock Stock { get; set; } = null!; // Navigation property
    }
}