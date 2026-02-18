namespace Taxes.Calculator.Command
{
    public class GenerateOrderCommand
    {
        public void GenerateOrder(string clientName, decimal budgetValue, int qtditens)
        {
            Budget budget = new Budget
            {
                Value = budgetValue,
                Qtditens = qtditens
            };

            Order order = new Order
            {
                ClientName = clientName,
                EndDate = DateTime.Now.AddDays(7),
                Budget = budget
            };

            Console.WriteLine("Saving in database...");
            Console.WriteLine("Sending email...");  
        }
    }
}