# Objective
This repository was created to study some behavioral design patterns, such as:

- [Strategy](#strategy)
- [Chain of Responsability](#chain-of-responsability)
- [Template Method](#template-method)
- [State](#state)
- [Command](#command)
- [Observer](#observer)

Reference used: https://refactoring.guru/

_Note: the values, taxes and dicounts used are fictional and used only for demonstration purposes._

## Strategy
<p align="justify" >
  The Strategy pattern was created to use a generic interface implementing the desired strategies. Instead of relying on multiple <code>if</code> statements or conditionals in a method, 
  this pattern delegates the behavior to separate classes that implement a common interface. The caller is responsible for selecting and providing
  the desired strategy at runtime.
    
  In this project, the pattern is used to calculate different taxes through implementations of the <code>ITaxes</code> interface:
</p>

```c#
public interface ITaxes
{
    decimal Calculate(Budget budget);
}
```

Each Tax implements this interface, each with its own specific rules:
```c#
public class Irrf : ITaxes
{
    public decimal Calculate(Budget budget)
    {
        return budget.Value * 0.15m;
    }
}
```

```c#
public class Icms : ITaxes
{
  public decimal Calculate(Budget budget)
  {
      return budget.Value * 0.1m;
  }
}
```

## Chain of Responsability
<p align="justify">
  The Chain of Responsibility pattern is useful when multiple rules or behaviors must be executed in sequence without tightly coupling them into a single class. 
  Instead of having several <code>if</code> statements inside one method, this pattern allows us to create independent handlers that process a request and optionally pass it to the next handler in the chain.
  For example, we might validate a user by checking their role, then their IP address, then their age, and so on. 
  Each rule is implemented as a separate class that decides whether to handle the request or delegate it to the next handler.

  In this repository, the pattern is used in a discount calculator.
  Each discount follows the same structure (it receives a budget and calculates a discount), so an abstract class <code>Discount</code> was created, and each specific Discount inherits from it:
</p>

```c#
public abstract class Discount
{
    protected Discount? Next { get; set; }

    public abstract void SetNext(Discount discount);

    public abstract decimal CalculateDiscount(Budget budget);
}
```

```c#
public class DiscountPerValue : Discount
{
    public override void SetNext(Discount discount)
    {
        Next = discount;
    }

    public override decimal CalculateDiscount(Budget budget)
    {
        if (budget.Value > 500)
            return budget.Value * 0.05m;

        if (Next != null)
            return Next.CalculateDiscount(budget);

        return 0;
    }
}
```

<p align="justify">
  The calculator then initializes the discount chain and evaluates it sequentially, linking each <b>Discount</b> to the next handler in the chain:
</p>

```c#
public class DiscountCalculator
{
    public static decimal CalculateDiscount(Budget budget)
    {
        var discount = new DiscountPerValue();
        
        var discountPerQtdItens = new DiscountPerQtdItens();   
        discount.SetNext(discountPerQtdItens);

        var discountPerDay = new DiscountPerDay();
        discountPerQtdItens.SetNext(discountPerDay);

        return discount.CalculateDiscount(budget);
    }
}
```

## Template Method
<p align="justify">
  The Template Method pattern is useful when multiple classes share the same overall algorithm but differ in specific implementation details. 
  A common analogy is building a house: it will always have walls, doors, and windows, but the layout, proportions, and materials may vary.
  The idea is to extract the common steps into a base class that defines the algorithm structure, while allowing subclasses to customize specific parts of the process.
  
  In this repository, the pattern is demonstrated using a tax type with two possible rates (maximum and minimum). 
  The algorithm first determines which rate should be applied and then performs the tax calculation itself. 
  
  For this purpose, an abstract class <code>TaxWithTwoRates</code> was created, and the concrete tax classes inherit from it:
</p>

```c#
public abstract class TaxWithTwoRates : ITaxes
{
    
    public decimal Calculate(Budget budget)
    {
        if (ShouldUseMaxTax(budget))
            return MaxTax(budget);

        return MinTax(budget);
    }

    protected abstract bool ShouldUseMaxTax(Budget budget);
    protected abstract decimal MaxTax(Budget budget);
    protected abstract decimal MinTax(Budget budget);
}
```

```c#
public class Ikcv : TaxWithTwoRates
{
    protected override decimal MaxTax(Budget budget)
    {
        return budget.Value * 0.02m;
    }

    protected override decimal MinTax(Budget budget)
    {
        return budget.Value * 0.01m;
    }

    protected override bool ShouldUseMaxTax(Budget budget)
    {
        return budget.Value > 500 && budget.Qtditens > 3;
    }
}
```

## State
<p align="justify">
  The State pattern is useful when an object can have a limited set of possible states and its behavior changes depending on the current state. 
  Instead of relying on multiple <code>if</code> or <code>switch</code> statements, this pattern models each state as a separate class, encapsulating the behavior and transitions associated with it.

  For example, if a document can only be published by admin users, that rule can be implemented inside a specific state class (such as a Draft state), which controls whether the transition is allowed.

  In this repository, the pattern is applied to the <code>Budget</code> entity. 
  It has four possible states: <code>InApproval</code>, <code>Approved</code>, <code>Reproved</code>, and <code>Finished</code>. Depending on the current state, an additional discount may be applied to the budget.

  To support this behavior, an abstract class <code>BudgetState</code> was created to define the common operations and default transition rules:
</p>

```c#
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
```
<p align="justify">
  And each State inherits and apply its own set of rules:
</p>

```c#
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
```

```c#
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
```

## Command
<p align="justify">
  The Command pattern encapsulates a request as an object, allowing us to parameterize clients with different operations and decouple the sender from the receiver. 
  Instead of embedding business logic directly into the interface layer, each action is represented by a command class.
  For example, in a text editor application, UI elements like buttons simply trigger specific commands for each operation, rather than implementing the logic themselves. 
  This makes the interface independent from the underlying business rules.

  If the same editor later needs to be integrated with an API, the core logic does not need to be rewritten, since it is already encapsulated within the command classes.

  In this repository, a command was implemented to generate a new <code>Order</code> based on a <code>Budget</code>:
</p>

```c#
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

        foreach (var action in _actions)
        {
            action.Execute(order);
        }
    }
}
```

## Observer
