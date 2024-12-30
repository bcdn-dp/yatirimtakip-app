namespace yatirimtakip_backend.Models
{
    public class User
    {
        public int UserID { get; set; } // Matches with investments.UserID
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public ICollection<Investment> Investments { get; set; } = new List<Investment>();
    }
}
