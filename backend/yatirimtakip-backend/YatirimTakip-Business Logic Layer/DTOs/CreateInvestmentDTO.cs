namespace yatirimtakip_backend.DTOs
{
    public class CreateInvestmentDto
    {
        public int UserID { get; set; } = 1;
        public int StockID { get; set; } = 1;
        public float UnitPrice { get; set; } = 0.0f;
        public int UnitAmount { get; set; }
        public string Type { get; set; } = "DefaultType";
    }
}