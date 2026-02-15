namespace Taxes.Calculator.Aux.Budget
{
    public abstract class BudgetState
    {
        public abstract decimal CalculateExtraDiscount(Calculator.Budget budget);

        public virtual void Approve(Calculator.Budget  budget)
        {
            throw new Exception("Budget cannot be approved");
        }

        public virtual void Reprove(Calculator.Budget  budget)
        {
            throw new Exception("Budget cannot be reproved");
        }

        public virtual void Finish(Calculator.Budget  budget)
        {
            throw new Exception("Budget cannot be finished");
        }
    }
}