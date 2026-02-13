namespace Taxes.Calculator.Discount
{
    public class DiscountPerQtdItens : Discount
    {
        public DiscountPerQtdItens(Discount next) : base(next)
        {
        }

        public override decimal CalculateDiscount(Budget budget)
        {
            if (budget.Qtditens > 5)
            {
                return budget.Value * 0.1m;
            }
            
            return Next!.CalculateDiscount(budget);
        }
    }
}