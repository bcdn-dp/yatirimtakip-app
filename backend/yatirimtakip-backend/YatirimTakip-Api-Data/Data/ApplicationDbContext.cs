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
                .HasOne(i => i.User)
                .WithMany(u => u.Investments)
                .HasForeignKey(i => i.UserID);

            // Stocks Table
            modelBuilder.Entity<Stock>()
                .HasKey(s => s.StockID);
            modelBuilder.Entity<Stock>()
                .Property(s => s.Open)
                .HasColumnType("money");
            modelBuilder.Entity<Stock>()
                .Property(s => s.High)
                .HasColumnType("money");
            modelBuilder.Entity<Stock>()
                .Property(s => s.Low)
                .HasColumnType("money");
            modelBuilder.Entity<Stock>()
                .Property(s => s.Close)
                .HasColumnType("money");
            modelBuilder.Entity<Stock>()
                .HasOne<Investment>()
                .WithMany()
                .HasForeignKey(s => s.SName)
                .HasPrincipalKey(i => i.Type);
        }
    }
}