using Taxes.Calculator.Taxes;

namespace Taxes.Calculator.Icms
{
    public class Icms : ITaxes
    {
        public decimal Calculate(Budget budget)
        {
            return budget.Value * 0.1m;
        }
    }
}