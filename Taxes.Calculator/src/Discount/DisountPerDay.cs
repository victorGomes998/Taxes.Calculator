namespace  Taxes.Calculator.Discount
{
    public class DiscountPerDay : Discount
    {
        public override Discount SetNext(Discount discount)
        {
            Next = discount;
            return discount;
        }

        public override decimal CalculateDiscount(Budget budget)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
                return budget.Value * 0.15m;

            if (Next != null)
                return Next.CalculateDiscount(budget);

            return 0;
        }
    }
}