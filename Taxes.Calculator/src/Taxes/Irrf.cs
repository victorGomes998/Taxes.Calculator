using Taxes.Calculator.Taxes;

namespace Taxes.Calculator.Irrf
{
    public class Irrf : ITaxes
    {
        public decimal Calculate(Budget budget)
        {
            return budget.Value * 0.15m;
        }
    }
}