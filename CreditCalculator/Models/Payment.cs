using System.ComponentModel.DataAnnotations;

namespace CreditCalculator.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }
        public decimal BodySum { get; set; }
        public decimal MarginSum { get; set; }
        public decimal DebtBalance { get; set; }

        public CreditCalculation CreditCalculation { get; set; }

        public Payment()
        {

        }
        public Payment(DateTime paymentDate, decimal bodySum, decimal marginSum, decimal bodyDebt)
        {
            PaymentDate = paymentDate;
            BodySum = bodySum;
            MarginSum = marginSum;
            DebtBalance = bodyDebt;
        }
    }
}
