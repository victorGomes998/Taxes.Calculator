namespace Taxes.Calculator.GenerateOrderActions
{
    public class SaveOrderLogsAction : IOrderActions
    {
        public void Execute(Order order)
        {
            Console.WriteLine("Saving order logs...");  
        }
    }
}