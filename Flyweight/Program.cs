using Flyweight;

var discountCalculatorFactory = new DiscountCalculatorFactory();
var discountCalculator = discountCalculatorFactory.GetDiscountCalculator(CalculatorType.Day);
var discount = discountCalculator.GetDiscountValue(DateTime.Now);

Console.WriteLine(discount);