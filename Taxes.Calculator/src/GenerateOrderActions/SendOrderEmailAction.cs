namespace Taxes.Calculator.GenerateOrderActions
{
    public class SendOrderEmailAction : IOrderActions
    {
        public void Execute(Order order)
        {
            Console.WriteLine("Sending email...");  
        }
    }
}