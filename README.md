# Objective
This repository was created to study some behavioral design patterns, such as:

- [Strategy](#strategy)
- Chain of Responsability
- Template Method
- State
- Command
- Observer

Reference used: https://refactoring.guru/

## Strategy
<p align="justify" >
  The Strategy Pattern was created to use a generic interface implementing the desired strategies. Instead of relying on multiple <code>if</code> statements or conditionals in a method, 
  this pattern delegates the behavior to separate classes that implement a common interface. The caller is responsible for selecting and providing
  the desired strategy at runtime.
  <br><br>In this project, the pattern is used to calculate different taxes through implementations of the <code>ITaxes</code> interface:
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
