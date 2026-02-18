namespace Taxes.Calculator.GenerateOrderActions
{
    public class SaveOrderInDbAction : IOrderActions
    {
        public void Execute(Order order)
        {
            Console.WriteLine("Saving in database...");
        }
    }
}