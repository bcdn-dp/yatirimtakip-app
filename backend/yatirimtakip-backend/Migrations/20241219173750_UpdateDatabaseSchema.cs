using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace yatirimtakip_backend.Migrations
{
    public partial class UpdateDatabaseSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Remove the creation of the Stocks table if it already exists
            // migrationBuilder.CreateTable(
            //     name: "Stocks",
            //     columns: table => new
            //     {
            //         StockID = table.Column<int>(type: "integer", nullable: false)
            //             .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //         SName = table.Column<string>(type: "text", nullable: false),
            //         PriceLast = table.Column<float>(type: "real", nullable: false),
            //         Difference = table.Column<float>(type: "real", nullable: false),
            //         CloseLast = table.Column<float>(type: "real", nullable: false),
            //         DailyLow = table.Column<float>(type: "real", nullable: false),
            //         DailyHigh = table.Column<float>(type: "real", nullable: false),
            //         Vol = table.Column<float>(type: "real", nullable: false),
            //         Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Stocks", x => x.StockID);
            //         table.UniqueConstraint("AK_Stocks_SName", x => x.SName);
            //     });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove the deletion of the Stocks table if it already exists
            // migrationBuilder.DropTable(
            //     name: "Stocks");
        }
    }
}