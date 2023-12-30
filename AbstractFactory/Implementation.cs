namespace AbstractFactory
{
    #region First Example
    /// <summary>
    /// Client
    /// </summary>
    public class ShoppingCart
    {
        private readonly IDiscountService _discountService;
        private readonly IShippingCostsService _shippingCostsService;
        private readonly decimal _totalCosts;
        public ShoppingCart(IShoppingCartPurchaseFactory shoppingCartPurchaseFactory, decimal totalCosts)
        {
            _discountService = shoppingCartPurchaseFactory.CreateDiscountService();
            _shippingCostsService = shoppingCartPurchaseFactory.CreateShippingCostsService();
            _totalCosts = totalCosts;
        }

        public void CalculateCosts()
        {
            Console.WriteLine($"Total costs = {_totalCosts - (_totalCosts / 100 * _discountService.DiscountPercentage) + _shippingCostsService.ShippingCosts}");
        }
    }

    /// <summary>
    /// Abstract Factory
    /// </summary>
    public interface IShoppingCartPurchaseFactory
    {
        IDiscountService CreateDiscountService();
        IShippingCostsService CreateShippingCostsService();
    }

    /// <summary>
    /// Concrete Factory A
    /// </summary>
    class BelgiumShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new BelgiumDiscountService();
        }

        public IShippingCostsService CreateShippingCostsService()
        {
            return new BelgiumShippingCostsService();
        }
    }


    /// <summary>
    /// Concrete Factory B
    /// </summary>
    class FranceShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new FranceDiscountService();
        }

        public IShippingCostsService CreateShippingCostsService()
        {
            return new FranceShippingCostsService();
        }
    }

    /// <summary>
    /// Abstract Product
    /// </summary>
    public interface IDiscountService
    {
        public abstract int DiscountPercentage { get; }
    }

    /// <summary>
    /// Abstract Product
    /// </summary>
    public interface IShippingCostsService
    {
        decimal ShippingCosts { get; }
    }


    /// <summary>
    /// Concrete Product
    /// </summary>
    public class BelgiumDiscountService : IDiscountService
    {
        public int DiscountPercentage => 20;
    }


    /// <summary>
    /// Concrete Product
    /// </summary>
    public class FranceDiscountService : IDiscountService
    {
        public int DiscountPercentage => 25;
    }


    /// <summary>
    /// Concrete Product
    /// </summary>
    public class BelgiumShippingCostsService : IShippingCostsService
    {
        public decimal ShippingCosts => 20;
    }


    /// <summary>
    /// Concrete Product
    /// </summary>
    public class FranceShippingCostsService : IShippingCostsService
    {
        public decimal ShippingCosts => 25;
    }
    #endregion

    #region Second Example
    /// <summary>
    /// Abstract Factory
    /// </summary>
    public interface IBankFactory
    {
        IBank CreateBank();
        IPaymentCard CreatePaymentCard(string paymentCode);
    }

    /// <summary>
    /// Concrete Factory
    /// </summary>
    public class BankFactory : IBankFactory
    {
        private readonly string _bankCode;

        public BankFactory(string bankCode)
        {
            _bankCode = bankCode;
        }

        public IBank CreateBank()
        {
            return _bankCode switch
            {
                "111111" => new BankA(),
                "123456" => new BankB(),
                _ => throw new NotImplementedException("There is no bank configuaration for your bank yet")
            };
        }

        public IPaymentCard CreatePaymentCard(string paymentCode)
        {
            return paymentCode switch
            {
                "12" => new VisaCard(),
                "11" => new MasterCard(),
                _ => throw new NotImplementedException("There is no configuaration for this card yet")
            };
        }
    }

    /// <summary>
    /// Abstract Product
    /// </summary>
    public interface IBank
    {
        string Withdraw();
    }

    /// <summary>
    /// Concrete Product
    /// </summary>
    public class BankA : IBank
    {
        public string Withdraw()
        {
            return "Your transaction is handled by BankA";
        }
    }


    /// <summary>
    /// Concrete Product
    /// </summary>
    public class BankB : IBank
    {
        public string Withdraw()
        {
            return "Your transaction is handled by BankB";
        }
    }

    /// <summary>
    /// Abstract Product
    /// </summary>
    public interface IPaymentCard
    {
        string GetName();
    }


    /// <summary>
    /// Concrete Product
    /// </summary>
    public class MasterCard : IPaymentCard
    {
        public string GetName()
        {
            return "Master Card";
        }
    }


    /// <summary>
    /// Concrete Product
    /// </summary>
    public class VisaCard : IPaymentCard
    {
        public string GetName()
        {
            return "Visa Card";
        }
    }
    #endregion
}
