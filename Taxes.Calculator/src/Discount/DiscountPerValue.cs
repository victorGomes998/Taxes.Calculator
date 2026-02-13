namespace Taxes.Calculator.Discount
{
    public class DiscountPerValue : Discount
    {
        public DiscountPerValue(Discount? next) : base(next)
        {
        }

        public override decimal CalculateDiscount(Budget budget)
        {
            if (budget.Value > 500)
                return budget.Value * 0.05m;

            return Next!.CalculateDiscount(budget);
        }
    }
}