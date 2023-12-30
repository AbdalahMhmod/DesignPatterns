namespace Flyweight
{
    public enum CalculatorType
    {
        Day,
        Item,
    }

    public class DiscountCalculatorFactory
    {
        public IDiscountCalculator GetDiscountCalculator(CalculatorType calculatorType)
        {
            IDiscountCalculator discountCalculator = null;
            Dictionary<CalculatorType, IDiscountCalculator> discountCalculatorList = new Dictionary<CalculatorType, IDiscountCalculator>();

            if(discountCalculatorList.ContainsKey(calculatorType))
            {
                return discountCalculatorList[calculatorType];
            }

            discountCalculator = calculatorType switch
            {
                CalculatorType.Day => new DateDiscountCalculator(),
                CalculatorType.Item => new ItemDiscountCalculator(),
            };

            if(discountCalculator == null)
            {
                return null;
            }

            discountCalculatorList.Add(calculatorType, discountCalculator);
            return discountCalculator;
        }
    }

    public interface IDiscountCalculator
    {
        double GetDiscountValue(DateTime currentDate, string itemId = null);
    }

    public class DateDiscountCalculator : IDiscountCalculator
    {
        public double GetDiscountValue(DateTime currentDate, string itemId = null)
        {
            return 0.15;
        }
    }

    public class ItemDiscountCalculator : IDiscountCalculator
    {
        public double GetDiscountValue(DateTime currentDate, string itemId = null)
        {
            return 0.2;
        }
    }
}
