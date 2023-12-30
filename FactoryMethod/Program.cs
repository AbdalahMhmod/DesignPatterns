using FactoryMethod;

#region First Example
var factories = new List<DiscountFactory> { new CountryDiscountFactory("EG"), new CodeDiscountFactory(Guid.NewGuid()) };

foreach(var factory in factories)
{
    var discountService = factory.CreateDiscountService();
    Console.WriteLine($"Percentage is {discountService.DiscountPercentage} and it comers from {discountService}");
}

#endregion

#region Second Example
Console.WriteLine("Please enter your bank number");
var bankNumber = Console.ReadLine();
var bankCode = bankNumber.Substring(0, 6);

var bankFactory = new BankFactory(bankCode);
var bank = bankFactory.CreateBank();

Console.WriteLine(bank.Withdraw());
#endregion

/* Summery
The intent of the factory method is to define an interface for
creating an object, but to let subclasses to decide which class to create.
The Factory Method Pattern is a creational design pattern in software engineering that provides an interface for creating objects
but allows subclasses to alter the type of objects that will be created.
This pattern addresses several problems related to object creation and design flexibility:

1- Decoupling of Object Creation: The Factory Method Pattern promotes the decoupling of the client code 
from the actual classes of objects being created. Clients depend on an abstract factory interface or class,
reducing the direct dependency on specific concrete classes.

2- Flexibility and Extensibility: With the Factory Method Pattern, you can introduce new types of objects(subclasses)
without altering the existing client code. This makes it easier to extend the system with new features 
or variations of objects without affecting the overall design.

3- Subclass Customization: Subclasses of the factory can customize the creation process to produce objects with different behaviors 
or attributes. This enables the creation of specialized instances of objects while adhering to a common interface.

4- Encapsulation of Object Creation: The details of object creation are encapsulated within the factory classes. 
This helps in maintaining a clear separation of concerns between object creation and the rest of the application logic.

5- Code Reusability: By centralizing the object creation logic in factory classes,
you avoid duplicating object creation code across multiple places in your codebase. This leads to more reusable and maintainable code.

6- Dynamic Object Creation: Factory methods allow for runtime determination of the concrete class to instantiate.
This can be useful in scenarios where the exact class to be instantiated is determined by configuration, user input,
or other runtime factors.

7- Testing and Mocking: Factory methods simplify unit testing by providing a clear boundary for creating objects. 
This makes it easier to substitute mock objects for testing purposes, enhancing testability and reducing dependencies.

8- Dependency Inversion: The Factory Method Pattern contributes to the Dependency Inversion Principle, 
where high-level modules (client code) are not dependent on low-level modules (concrete classes). 
Instead, both depend on abstractions (interfaces or abstract classes).

9- Consistent Object Creation: The Factory Method Pattern ensures that objects are created in a consistent manner, 
adhering to the guidelines and logic defined in the factory class. This can help avoid inconsistencies in object initialization.

Overall, the Factory Method Pattern provides a structured way to handle object creation that promotes design principles like encapsulation,
abstraction, and separation of concerns. It's particularly useful when you anticipate changes 
or variations in the types of objects your system needs to create and when you want to minimize the impact of these changes on your existing codebase.
*/