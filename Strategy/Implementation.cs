namespace Strategy
{
    internal class ShoppingCart
    {
        private readonly List<string> _items;

        internal ShoppingCart()
        {
            _items = new List<string>();
        }

        internal void Add(string item)
        {
            _items.Add(item);
        }

        internal bool Remove(string item)
        {
            return _items.Remove(item);
        }

        internal double CalculateTotalAmount()
        {
            return 1000;
        }

        internal void Pay(IPaymentStrategy paymentStrategy)
        {
            var totalAmount = CalculateTotalAmount();
            paymentStrategy.Pay(totalAmount);
        }
    }

    internal interface IPaymentStrategy
    {
        void Pay(double amount);
    }

    internal class PayPalStrategy : IPaymentStrategy
    {
        private readonly string _name;
        private readonly string _email;

        public PayPalStrategy(string name, string email)
        {
            _name = name;
            _email = email;
        }

        public void Pay(double amount)
        {
            Console.WriteLine($"{amount} paid with paypal");
        }
    }

    internal class CreditCardStrategy : IPaymentStrategy
    {
        private readonly string _name;
        private readonly string _cardNumber;
        private readonly string _cvv;
        private readonly string _dateOfExpiry;

        public CreditCardStrategy(string name, string cardNumber, string cvv, string dateOfExpiry)
        {
            _name = name;
            _cardNumber = cardNumber;
            _cvv = cvv;
            _dateOfExpiry = dateOfExpiry;
        }

        public void Pay(double amount)
        {
            Console.WriteLine($"{amount} paid with credit card");
        }
    }
}
