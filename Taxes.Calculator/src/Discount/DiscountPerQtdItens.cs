namespace Taxes.Calculator.Discount
{
    public class DiscountPerQtdItens : Discount
    {
        public override void SetNext(Discount discount)
        {
            Next = discount;
        }

        public override decimal CalculateDiscount(Budget budget)
        {
            if (budget.Qtditens > 5)
                return budget.Value * 0.1m;
            
             if (Next != null)
                return Next.CalculateDiscount(budget);

            return 0;
        }
    }
}