namespace Taxes.Calculator.Discount
{
    public abstract class Discount
    {
        protected Discount? Next { get; set; }

        public abstract void SetNext(Discount discount);

        public abstract decimal CalculateDiscount(Budget budget);
    }
}