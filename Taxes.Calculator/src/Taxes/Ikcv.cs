namespace Taxes.Calculator.Taxes
{
    public class Ikcv : TaxWithTwoRates
    {
        protected override decimal MaxTax(Budget budget)
        {
            return budget.Value * 0.02m;
        }

        protected override decimal MinTax(Budget budget)
        {
            return budget.Value * 0.01m;
        }

        protected override bool ShouldUseMaxTax(Budget budget)
        {
            return budget.Value > 500 && budget.Qtditens > 3;
        }
    }
}