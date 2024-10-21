using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.DataAccesLayer.Migrations
{
    public partial class migg_add_money_case : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "moneyCases",
                columns: table => new
                {
                    MoneyCaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moneyCases", x => x.MoneyCaseId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "moneyCases");
        }
    }
}
