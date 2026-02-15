using Taxes.Calculator.Discount;

namespace Taxes.Calculator
{
    public class DiscountCalculator
    {
        public static decimal CalculateDiscount(Budget budget)
        {
            var discount = new DiscountPerValue()
                .SetNext(new DiscountPerQtdItens())
                .SetNext(new DiscountPerDay());
            
            return discount.CalculateDiscount(budget);
        }
    }
}