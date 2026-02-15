namespace Taxes.Calculator.Taxes
{
    public abstract class TaxWithTwoRated : ITaxes
    {
        
        public decimal Calculate(Budget budget)
        {
            if (ShouldUseMaxTax(budget))
                return MaxTax(budget);

            return MinTax(budget);
        }

        protected abstract bool ShouldUseMaxTax(Budget budget);
        protected abstract decimal MaxTax(Budget budget);
        protected abstract decimal MinTax(Budget budget);
    }
}