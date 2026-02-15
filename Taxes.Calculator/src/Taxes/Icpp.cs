namespace Taxes.Calculator.Taxes
{
    public class Icpp : TaxWithTwoRated
    {
        protected override bool ShouldUseMaxTax(Budget budget)
        {
            return budget.Value > 500;
        }

        protected override decimal MaxTax(Budget budget)
        {
            return budget.Value * 0.03m;
        }

        protected override decimal MinTax(Budget budget)
        {
            return budget.Value * 0.025m;
        }
    }
}