namespace Taxes.Calculator.Discount
{
    public abstract class Discount
    {
        protected Discount? Next { get; private set; }

        protected Discount(Discount? next)
        {
            Next = next;
        }

        public abstract decimal CalculateDiscount(Budget budget);
    }
}