namespace yatirimtakip_backend.Models
{
    public class Investment
    {
        public int InvestID { get; set; }
        public int UserID { get; set; } = 1;
        public int StockID { get; set; } = 1;
        public float UnitPrice { get; set; } = 0.0f;
        public int UnitAmount { get; set; }
        public string Type { get; set; } = "DefaultType";

        public User User { get; set; } = null!;
        public Stock Stock { get; set; } = null!;
    }
}