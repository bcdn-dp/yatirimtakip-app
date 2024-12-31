namespace yatirimtakip_backend.DTOs
{
    public class CreateInvestmentDto
    {
        public int UserID { get; set; }
        public string Type { get; set; } = null!;
        public float UnitPrice { get; set; }
        public int UnitAmount { get; set; }
        public int StockID { get; set; }
    }
}