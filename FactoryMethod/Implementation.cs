namespace FactoryMethod
{
    #region First Example
    public abstract class DiscountService
    {
        public abstract int DiscountPercentage { get; }

        public override string ToString()
        {
            return GetType().Name;
        }
    }

    public class CountryDiscountService : DiscountService
    {
        private readonly string _countryCode;

        public override int DiscountPercentage
        {
            get
            {
                if(_countryCode == "EG")
                {
                    return 20;
                }

                return 10;
            }
        }

        public CountryDiscountService(string countryCode)
        {
            _countryCode = countryCode;
        }
    }

    public class CodeDiscountService : DiscountService
    {
        private readonly Guid _code;

        public override int DiscountPercentage
        {
            get
            {
                return 15;
            }
        }

        public CodeDiscountService(Guid code)
        {
            _code = code;
        }
    }

    public abstract class DiscountFactory
    {
        public abstract DiscountService CreateDiscountService();
    }

    public class CodeDiscountFactory : DiscountFactory
    {
        private readonly Guid _code;

        public CodeDiscountFactory(Guid code)
        {
            _code = code;
        }

        public override DiscountService CreateDiscountService()
        {
            return new CodeDiscountService(_code);
        }
    }

    public class CountryDiscountFactory : DiscountFactory
    {
        private readonly string _country;

        public CountryDiscountFactory(string country)
        {
            _country = country;
        }

        public override DiscountService CreateDiscountService()
        {
            return new CountryDiscountService(_country);
        }
    }
    #endregion

    #region Second Example
    public interface IBankFactory
    {
        IBank CreateBank();
    }

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
    }

    public interface IBank
    {
        string Withdraw();
    }

    public class BankA : IBank
    {
        public string Withdraw()
        {
            return "Your transaction is handled by BankA";
        }
    }

    public class BankB : IBank
    {
        public string Withdraw()
        {
            return "Your transaction is handled by BankB";
        }
    }
    #endregion
}
