using Taxes.Calculator.Discount;

namespace Taxes.Calculator
{
    public class DiscountCalculator
    {
        public static decimal CalculateDiscount(Budget budget)
        {
            var discount = new DiscountPerValue();
            
            var discountPerQtdItens = new DiscountPerQtdItens();   
            discount.SetNext(discountPerQtdItens);

            var discountPerDay = new DiscountPerDay();
            discountPerQtdItens.SetNext(discountPerDay);

            return discount.CalculateDiscount(budget);
        }
    }
}