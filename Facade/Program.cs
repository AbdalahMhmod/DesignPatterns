using Facade;

var shoppingBasket = new ShoppingBasket();
shoppingBasket.AddItem(new BasketItem { ItemId = "123", Quantity = 2, ItemPrice = 1000 });
shoppingBasket.AddItem(new BasketItem { ItemId = "456", Quantity = 4, ItemPrice = 4000 });

var purchaseOrder = new PurchaseOrder();
purchaseOrder.CreateOrder(shoppingBasket, "Address:123, Id: 456, Email: 789@gmail.com");

