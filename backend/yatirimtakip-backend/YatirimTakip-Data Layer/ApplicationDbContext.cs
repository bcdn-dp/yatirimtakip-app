using Microsoft.EntityFrameworkCore;
using yatirimtakip_backend.Models;

namespace yatirimtakip_backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Investment> Investments { get; set; } = null!;
        public DbSet<Stock> Stocks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Users Table
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserID);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Investments)
                .WithOne(i => i.User)
                .HasForeignKey(i => i.UserID);

            // Investments Table
            modelBuilder.Entity<Investment>()
                .HasKey(i => i.InvestID);
            modelBuilder.Entity<Investment>()
                .Property(i => i.InvestID)
                .ValueGeneratedOnAdd(); // Ensure InvestID is auto-incremented
            modelBuilder.Entity<Investment>()
                .HasOne(i => i.Stock)
                .WithMany(s => s.Investments)
                .HasForeignKey(i => i.StockID);

            // Stocks Table
            modelBuilder.Entity<Stock>()
                .HasKey(s => s.Id); // Primary Key
            modelBuilder.Entity<Stock>()
                .Property(s => s.Date)
                .IsRequired(); // Ensure Date is not null
            modelBuilder.Entity<Stock>()
                .Property(s => s.Open)
                .HasPrecision(18, 2); // Floating-point precision for Open
            modelBuilder.Entity<Stock>()
                .Property(s => s.High)
                .HasPrecision(18, 2); // Floating-point precision for High
            modelBuilder.Entity<Stock>()
                .Property(s => s.Low)
                .HasPrecision(18, 2); // Floating-point precision for Low
        }
    }
}