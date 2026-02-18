using Taxes.Calculator.GenerateOrderActions;

namespace Taxes.Calculator.Command
{
    public class GenerateOrderCommand
    {
        private List<IOrderActions> _actions = [];

        public void AddPostGenerationAction(IOrderActions action)
        {
            _actions.Add(action);
        }

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

            foreach (var action in _actions)
            {
                action.Execute(order);
            }
        }
    }
}