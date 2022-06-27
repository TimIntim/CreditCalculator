using System.ComponentModel.DataAnnotations;

namespace CreditCalculator.Models
{
    public class CreditCalculation
    {
        public int Id { get; set; }
        [DataType(DataType.Currency)]
        public decimal LoanAmount { get; set; }
        public int MonthlyTerm { get; set; }
        public decimal AnnualInterestRate { get; set; }
    }
}
