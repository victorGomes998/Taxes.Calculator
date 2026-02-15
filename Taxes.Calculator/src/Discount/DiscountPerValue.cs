namespace Taxes.Calculator.Discount
{
    public class DiscountPerValue : Discount
    {
        public override Discount SetNext(Discount discount)
        {
            Next = discount;
            return discount;
        }

        public override decimal CalculateDiscount(Budget budget)
        {
            if (budget.Value > 500)
                return budget.Value * 0.05m;

            if (Next != null)
                return Next.CalculateDiscount(budget);

            return 0;
        }
    }
}