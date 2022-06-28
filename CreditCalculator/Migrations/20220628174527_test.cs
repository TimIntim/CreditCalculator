using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditCalculator.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BodyDebt",
                table: "Payment",
                newName: "DebtBalance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DebtBalance",
                table: "Payment",
                newName: "BodyDebt");
        }
    }
}
