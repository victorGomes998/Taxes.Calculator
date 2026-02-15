namespace Taxes.Calculator.Aux.Budget
{
    public class BudgetInApprovalState : BudgetState
    {
        public override decimal CalculateExtraDiscount(Calculator.Budget budget)
        {
            return budget.Value * 0.05m;
        }

        public override void Approve(Calculator.Budget budget)
        {
            budget.State = new BudgetApprovedState();
        }

        public override void Reprove(Calculator.Budget budget)
        {
            budget.State = new BudgetReprovedState();
        }
    }
}