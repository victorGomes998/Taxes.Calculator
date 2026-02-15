namespace Taxes.Calculator.Aux.Budget
{
    public class BudgetFinishedState : BudgetState
    {
        public override decimal CalculateExtraDiscount(Calculator.Budget budget)
        {
            throw new Exception("Budget in finished state does not receive extra discount");
        }
    }
}