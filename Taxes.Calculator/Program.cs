using Taxes.Calculator;
using Taxes.Calculator.Icms;
using Taxes.Calculator.Irrf;

var budget = new Budget();
budget.Value = 100m;

var tax = new TaxesCalculator();
var result = tax.CalculateTax(budget, new Icms());

Console.WriteLine($"Calculated tax: {result}");

var result2 = tax.CalculateTax(budget, new Irrf());
Console.WriteLine($"Calculated tax 2: {result2}");
