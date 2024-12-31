using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace yatirimtakip_backend.Migrations
{
    public partial class RemoveUniqueConstraintOnType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Investments_Type",
                table: "Investments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Investments_Type",
                table: "Investments",
                column: "Type");
        }
    }
}