using Taxes.Calculator.Taxes;

namespace Taxes.Calculator
{
    public class TaxesCalculator
    {
        public decimal CalculateTax(Budget budget, ITaxes tax)
        {
            return tax.Calculate(budget);
        }
    }
}