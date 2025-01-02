using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace yatirimtakip_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddSymbolToStocks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investments_Stocks_Type",
                table: "Investments");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Stocks_SName",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Investments_Type",
                table: "Investments");

            migrationBuilder.DropColumn(
                name: "CloseLast",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "DailyHigh",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "DailyLow",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "Difference",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Investments");

            migrationBuilder.RenameColumn(
                name: "Vol",
                table: "Stocks",
                newName: "Volume");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Stocks",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "SName",
                table: "Stocks",
                newName: "Symbol");

            migrationBuilder.RenameColumn(
                name: "PriceLast",
                table: "Stocks",
                newName: "AdjClose");

            migrationBuilder.RenameColumn(
                name: "StockID",
                table: "Stocks",
                newName: "Id");

            migrationBuilder.AddColumn<float>(
                name: "Close",
                table: "Stocks",
                type: "real",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "High",
                table: "Stocks",
                type: "real",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Low",
                table: "Stocks",
                type: "real",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Open",
                table: "Stocks",
                type: "real",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "StockId",
                table: "Investments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Investments_StockId",
                table: "Investments",
                column: "StockId");

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_Stocks_StockId",
                table: "Investments",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investments_Stocks_StockId",
                table: "Investments");

            migrationBuilder.DropIndex(
                name: "IX_Investments_StockId",
                table: "Investments");

            migrationBuilder.DropColumn(
                name: "Close",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "High",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "Low",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "Open",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "StockId",
                table: "Investments");

            migrationBuilder.RenameColumn(
                name: "Volume",
                table: "Stocks",
                newName: "Vol");

            migrationBuilder.RenameColumn(
                name: "Symbol",
                table: "Stocks",
                newName: "SName");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Stocks",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "AdjClose",
                table: "Stocks",
                newName: "PriceLast");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Stocks",
                newName: "StockID");

            migrationBuilder.AddColumn<float>(
                name: "CloseLast",
                table: "Stocks",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "DailyHigh",
                table: "Stocks",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "DailyLow",
                table: "Stocks",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Difference",
                table: "Stocks",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Investments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Stocks_SName",
                table: "Stocks",
                column: "SName");

            migrationBuilder.CreateIndex(
                name: "IX_Investments_Type",
                table: "Investments",
                column: "Type");

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_Stocks_Type",
                table: "Investments",
                column: "Type",
                principalTable: "Stocks",
                principalColumn: "SName",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
