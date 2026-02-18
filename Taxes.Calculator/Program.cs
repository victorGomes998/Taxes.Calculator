using Taxes.Calculator;
using Taxes.Calculator.Command;
using Taxes.Calculator.GenerateOrderActions;
using Taxes.Calculator.Icms;
using Taxes.Calculator.Irrf;

// var budget = new Budget
// {
//    Value = 200m,
//    Qtditens = 3
// };


// var tax = new TaxesCalculator();
// var result = tax.CalculateTax(budget, new Icms());

// Console.WriteLine($"Calculated tax: {result}");

// var result2 = tax.CalculateTax(budget, new Irrf());
// Console.WriteLine($"Calculated tax 2: {result2}");

// var result3 = DiscountCalculator.CalculateDiscount(budget);
// Console.WriteLine($"Calculated discount: {result3}");

string clientName = "John Doe";
decimal budgetValue = 500m;
int qtditens = 5;

var command = new GenerateOrderCommand();
command.AddPostGenerationAction(new SaveOrderInDbAction());
command.AddPostGenerationAction(new SendOrderEmailAction());
command.AddPostGenerationAction(new SaveOrderLogsAction());
command.GenerateOrder(clientName, budgetValue, qtditens);
