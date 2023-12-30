namespace Facade
{
    public class ShoppingBasket
    {
        private readonly List<BasketItem> _basketItems = new List<BasketItem>();

        public void AddItem(BasketItem item)
        {
            _basketItems.Add(item);
        }

        public void RemoveItem(string itemId)
        {
            var item = _basketItems.FirstOrDefault(b => b.ItemId == itemId);
            if(item != null && item.Quantity <= 1)
            {
                _basketItems.Remove(item);
            }
            else if(item != null)
            {
                item.Quantity -= 1;
            }
        }

        public BasketItem GetBasketItem(string itemId)
        {
            return _basketItems.FirstOrDefault(item => item.ItemId == itemId);
        }

        public List<BasketItem> GetBasketItems() => _basketItems;
    }

    public class BasketItem
    {
        public string ItemId { get; set; }
        public double ItemPrice { get; set; }
        public int Quantity { get; set; }
    }

    public class Inventory
    {
        public bool IsValidQuantity(string itemId, double quantity)
        {
            return quantity < 100;
        }
    }

    public class InventoryOrder
    {
        public string CreateOrder(ShoppingBasket shoppingBasket)
        {
            shoppingBasket.GetBasketItems();
            return $"Order number is : {Guid.NewGuid()}";
        }
    }

    public class PurchaseInvoice
    {
        public double Discount { get; private set; }

        public double TotalAmount { get; private set; }

        public double NetTotal { get; private set; }

        public PurchaseInvoice CreateInvoice(ShoppingBasket shoppingBasket, string customerInfo)
        {
            var basketItems = shoppingBasket.GetBasketItems();

            ApplyDiscount(basketItems);
            CalculateTotalAmount(basketItems);
            CalculateNetTotal();

            return this;
        }

        private void CalculateNetTotal()
        {
            NetTotal = TotalAmount - Discount;
        }

        private void CalculateTotalAmount(List<BasketItem> basketItems)
        {
            basketItems.ForEach(item =>
            {
                TotalAmount += item.ItemPrice * item.Quantity;
            });
        }

        private void ApplyDiscount(List<BasketItem> basketItems)
        {
            if(basketItems.Count > 5)
            {
                Discount = 20;
            }
        }
    }

    public class PurchaseOrder
    {
        public bool CreateOrder(ShoppingBasket shoppingBasket, string custInfo)
        {
            var isAllItemAvailavle = true;
            var inventory = new Inventory();

            shoppingBasket.GetBasketItems().ForEach(item =>
            {
                var isValidQuantity = inventory.IsValidQuantity(item.ItemId, item.Quantity);
                if(!isValidQuantity)
                {
                    isAllItemAvailavle = false;
                }
            });

            if(!isAllItemAvailavle)
            {
                return false;
            }

            var inventoryOrder = new InventoryOrder();
            inventoryOrder.CreateOrder(shoppingBasket);

            var purchaseInvoice = new PurchaseInvoice();
            purchaseInvoice.CreateInvoice(shoppingBasket, custInfo);

            var paymentProcessor = new PaymentProcessor();
            paymentProcessor.CanHandlePayment(purchaseInvoice.NetTotal, custInfo);

            var smsNotification = new SmsNotification();
            smsNotification.SendSms("customerId:123", "msg");

            return true;
        }
    }

    public class PaymentProcessor
    {
        public bool CanHandlePayment(double amount, string bankInfo)
        {
            return true;
        }
    }

    public class SmsNotification
    {
        public void SendSms(string to, string message)
        {
            // Send.
        }
    }
}
