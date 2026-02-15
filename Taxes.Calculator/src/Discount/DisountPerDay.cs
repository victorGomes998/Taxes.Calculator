namespace  Taxes.Calculator.Discount
{
    public class DiscountPerDay : Discount
    {
        public override void SetNext(Discount discount)
        {
            Next = discount;
        }

        public override decimal CalculateDiscount(Budget budget)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
                return budget.Value * 0.3m;

            if (Next != null)
                return Next.CalculateDiscount(budget);

            return 0;
        }
    }
}