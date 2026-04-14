namespace Taxes.Calculator.Helpers.Budget
{
    public class BudgetReprovedState : BudgetState
    {
        public override decimal CalculateExtraDiscount(Calculator.Budget budget)
        {
            throw new Exception("Budget in reproved state does not receive extra discount");
        }

        public override void Finish(Calculator.Budget budget)
        {
            budget.State = new BudgetFinishedState();
        }
    }
}