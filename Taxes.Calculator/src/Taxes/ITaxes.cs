namespace Taxes.Calculator.Taxes
{
    public interface ITaxes
    {
        decimal Calculate(Budget budget);
    }
}