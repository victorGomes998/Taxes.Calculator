using Taxes.Calculator.Discount;

namespace Taxes.Calculator
{
    public class DiscountCalculator
    {
        public static decimal CalculateDiscount(Budget budget)
        {
            var discount = new DiscountPerValue(
                new DiscountPerQtdItens(
                    new NoDiscount()
                )
            );
            
            return discount.CalculateDiscount(budget);
        }
    }
}