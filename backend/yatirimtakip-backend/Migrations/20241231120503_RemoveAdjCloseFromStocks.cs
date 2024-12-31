using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace yatirimtakip_backend.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAdjCloseFromStocks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdjClose",
                table: "Stocks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "AdjClose",
                table: "Stocks",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
