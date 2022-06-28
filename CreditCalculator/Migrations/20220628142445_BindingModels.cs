using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditCalculator.Migrations
{
    public partial class BindingModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BodySum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MarginSum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BodyDebt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreditCalculationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_CreditCalculations_CreditCalculationId",
                        column: x => x.CreditCalculationId,
                        principalTable: "CreditCalculations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CreditCalculationId",
                table: "Payment",
                column: "CreditCalculationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment");
        }
    }
}
