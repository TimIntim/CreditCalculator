using CreditCalculator.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditCalculator.Data
{
    public class CreditCalculatorContext: DbContext
    {
        public CreditCalculatorContext(DbContextOptions options) : base(options)
        { }

        public DbSet<CreditCalculation>CreditCalculations { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
