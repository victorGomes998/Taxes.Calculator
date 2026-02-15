namespace Taxes.Calculator.Discount
{
    public abstract class Discount
    {
        protected Discount? Next { get; set; }

        public abstract Discount SetNext(Discount discount);

        public abstract decimal CalculateDiscount(Budget budget);
    }
}