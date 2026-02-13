namespace Taxes.Calculator.Discount
{
    public class NoDiscount : Discount
    {
        public NoDiscount() : base(null)
        {
        }

        public override decimal CalculateDiscount(Budget budget)
        {
            return 0;
        }
    }
}