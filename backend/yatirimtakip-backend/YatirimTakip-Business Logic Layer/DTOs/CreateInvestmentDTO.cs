namespace yatirimtakip_backend.DTOs
{
    public class CreateInvestmentDto
    {
        public int UserID { get; set; } = 1; // Default UserID
        public int StockID { get; set; } = 1; // Default StockID
        public float UnitPrice { get; set; } = 0.0f; // Default UnitPrice
        public int UnitAmount { get; set; } // UnitAmount must be provided
        public string Type { get; set; } = "DefaultType"; // Default Type
    }
}