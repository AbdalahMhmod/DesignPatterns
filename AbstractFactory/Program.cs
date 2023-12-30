using AbstractFactory;

#region First Example
var shoppingCart = new ShoppingCart(new BelgiumShoppingCartPurchaseFactory(), 200);
shoppingCart.CalculateCosts();
#endregion

#region Second Example
Console.WriteLine("Please enter your bank number");
var bankNumber = Console.ReadLine();
var bankCode = bankNumber.Substring(0, 6);
var paymentCode = bankNumber.Substring(0, 2);

var bankFactory = new BankFactory(bankCode);
var bank = bankFactory.CreateBank();
var paymentCard = bankFactory.CreatePaymentCard(paymentCode);

Console.WriteLine(bank.Withdraw());
Console.WriteLine(paymentCard.GetName());
#endregion