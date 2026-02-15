using Taxes.Calculator.Aux.Budget;

namespace Taxes.Calculator
{
    public class Budget
    {
        public Budget()
        {
            State = new BudgetInApprovalState();
        }

        public int Qtditens { get; set; }
        public decimal Value { get; set; }
        public BudgetState State { get; set; }

        public decimal ApplyExtraDiscount()
        {
            var discount = State.CalculateExtraDiscount(this);
            Value -= discount;
            return discount;
        }

        public void Approve()
        {
            State.Approve(this);
        }

        public void Reprove()
        {
            State.Reprove(this);
        }

        public void Finish()
        {
            State.Finish(this);
        }
    }
}