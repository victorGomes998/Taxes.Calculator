# Objective
This repository was created to study some behavioral design patterns, such as:

- [Strategy](#strategy)
- [Chain of Responsability](#chain-of-responsability)
- [Template Method](#template-method)
- State
- Command
- Observer

Reference used: https://refactoring.guru/

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
_Note: the values are fictional and used only for demonstration purposes._

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
