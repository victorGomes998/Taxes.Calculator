namespace Taxes.Calculator.Aux.Budget
{
    public class BudgetApprovedState : BudgetState
    {
        public override decimal CalculateExtraDiscount(Calculator.Budget budget)
        {
            return budget.Value * 0.02m;
        }

        public override void Finish(Calculator.Budget budget)
        {
            budget.State = new BudgetFinishedState();
        }
    }
}