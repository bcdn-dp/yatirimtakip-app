namespace yatirimtakip_backend.Models
{
    public class Investment
    {
        public int InvestID { get; set; }
        public int UserID { get; set; } // Foreign key
        public string Type { get; set; } = null!; // Matches stock.SName
        public float UnitPrice { get; set; }
        public int UnitAmount { get; set; }

        public User User { get; set; } = null!; // Navigation property
        public Stock Stock { get; set; } = null!; // Navigation property
    }
}
