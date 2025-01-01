namespace yatirimtakip_backend.Models
{
    public class InvestmentDto
    {
        public int InvestID { get; set; }
        public int UserID { get; set; }
        public int StockID { get; set; }
        public float UnitPrice { get; set; }
        public int UnitAmount { get; set; }
    }
}