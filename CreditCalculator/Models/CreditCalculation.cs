using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CreditCalculator.Models
{
    public class CreditCalculation
    {
        public int Id { get; set; }
        [DataType(DataType.Currency, ErrorMessage = "Значением поля {0} должно быть число")]
        [Range(0.01, int.MaxValue, ErrorMessage = "Значение поля {0} должно быть между {1} и {2}")]
        [DisplayName("Сумма займа")]
        public decimal LoanAmount { get; set; }
        [Range(1,12000, ErrorMessage = "Значение поля {0} должно быть между {1} и {2}")]
        [DisplayName("Срок займа (в месяцах)")]
        public int MonthlyTerm { get; set; }
        [Range(0.01, 365, ErrorMessage = "Значение поля {0} должно быть между {1} и {2}")]
        [DisplayName("Процентная ставка (в год)")]
        public decimal AnnualInterestRate { get; set; }
        [ValidateNever]
        public List<Payment> Payments { get; set; }

        public void CreateSchedule()
        {
            decimal monthlyRate = AnnualInterestRate / 12 / 100;
            decimal intermediateSum = (decimal)Math.Pow((double)(1 + monthlyRate), MonthlyTerm);
            decimal koef = monthlyRate * intermediateSum / (intermediateSum - 1);
            decimal monthlyPaymentSum = Math.Round(koef * LoanAmount, 2);

            decimal debtBalance = LoanAmount;
            var paymentDate = DateTime.Now.Date.AddMonths(1);
            var payments = new List<Payment>();
            for (var i = 0; i < MonthlyTerm; i++)
            {
                decimal marginSum = Math.Round(debtBalance * monthlyRate, 2);
                
                // Из-за округлений в расчетах размер последнего платежа другой. Поэтому просто берем bodySum из debtBalance
                decimal bodySum = monthlyPaymentSum < debtBalance 
                    ? monthlyPaymentSum - marginSum
                    : debtBalance;
                debtBalance -= bodySum;

                var payment = new Payment
                {
                    PaymentDate = paymentDate,
                    BodySum = bodySum,
                    MarginSum = marginSum,
                    DebtBalance = debtBalance,
                    CreditCalculation = this
                };
                payments.Add(payment);

                paymentDate = paymentDate.AddMonths(1);
            }

            Payments = payments;
        }
    }
}
