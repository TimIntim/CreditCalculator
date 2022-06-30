using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CreditCalculator.Models
{
    public class CreditCalculation
    {
        public int Id { get; set; }
        [DataType(DataType.Currency)]
        public decimal LoanAmount { get; set; }
        public int MonthlyTerm { get; set; }
        public decimal AnnualInterestRate { get; set; }
        [ValidateNever]
        public ICollection<Payment> Payments { get; set; }

        public void CreateSchedule()
        {
            decimal monthlyRate = AnnualInterestRate / 12;
            decimal intermediateSum = (decimal)Math.Pow((double)(1 + monthlyRate), MonthlyTerm);
            decimal koef = monthlyRate * intermediateSum / (intermediateSum - 1);
            decimal monthlyPaymentSum = Math.Round(koef * LoanAmount, 2, MidpointRounding.ToPositiveInfinity);

            decimal debtBalance = LoanAmount;
            decimal bodySum, marginSum;
            DateTime paymentDate = DateTime.Now.Date.AddMonths(1);
            var payments = new List<Payment>();
            for (int i = 0; i < MonthlyTerm; i++)
            {
                marginSum = debtBalance * AnnualInterestRate / 12;
                bodySum = monthlyPaymentSum - marginSum;

                Payment payment = new Payment
                {
                    PaymentDate = paymentDate,
                    BodySum = bodySum,
                    MarginSum = marginSum,
                    DebtBalance = debtBalance,
                    CreditCalculation = this
                };
                payments.Add(payment);

                paymentDate = paymentDate.AddMonths(1);
                debtBalance -= bodySum;
            }

            Payments = payments;
        }
    }
}
