using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditCalculator.Migrations
{
    public partial class test5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_CreditCalculations_CreditCalculationId",
                table: "Payment");

            migrationBuilder.AlterColumn<int>(
                name: "CreditCalculationId",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_CreditCalculations_CreditCalculationId",
                table: "Payment",
                column: "CreditCalculationId",
                principalTable: "CreditCalculations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_CreditCalculations_CreditCalculationId",
                table: "Payment");

            migrationBuilder.AlterColumn<int>(
                name: "CreditCalculationId",
                table: "Payment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_CreditCalculations_CreditCalculationId",
                table: "Payment",
                column: "CreditCalculationId",
                principalTable: "CreditCalculations",
                principalColumn: "Id");
        }
    }
}
