using Strategy;

var shoppingCart = new ShoppingCart();
var paypal = new PayPalStrategy("mohamed", "mohamed@gmail.com");
var creditCard = new CreditCardStrategy("mohamed", "542126584122", "211", "02/05/2023");

shoppingCart.Pay(paypal);
shoppingCart.Pay(creditCard);

/* <summary>
* The Strategy Pattern is a behavioral design pattern that defines a family of interchangeable algorithms, encapsulates each one, and makes them interchangeable.
* It lets the algorithm vary independently from clients that use it.
* 
* Key components of the Strategy Pattern include:
* 1. Context: This is the class that contains a reference to the strategy object and is responsible for using the algorithm defined by the strategy. The context is usually configured with a concrete strategy object during runtime.
* 2. Strategy: This is an interface or an abstract class that defines a set of methods that represent the various algorithms or strategies. Concrete strategy classes implement these methods to provide specific implementations of the algorithms.
* 3. Concrete Strategies: These are the concrete implementations of the strategy interface. Each concrete strategy class implements the algorithm defined in the strategy interface. The context can switch between these concrete strategies at runtime.
* 
* The primary purpose of the Strategy Pattern is to enable the client (the context) to choose from a family of algorithms or strategies dynamically. This promotes flexibility and allows you to change the behavior of an object by switching the strategy it uses without altering its code.
*/