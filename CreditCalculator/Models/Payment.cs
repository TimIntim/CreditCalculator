using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditCalculator.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Дата оплаты")]
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }
        [Display(Name = "Размер платежа по телу")]
        public decimal BodySum { get; set; }
        [Display(Name = "Размер платежа по процентам")]
        public decimal MarginSum { get; set; }
        [Display(Name = "Остаток основного долга")]
        public decimal DebtBalance { get; set; }

        //public int CreditCalculationId { get; set; }
        public CreditCalculation CreditCalculation { get; set; }
    }
}
