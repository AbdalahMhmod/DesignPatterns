using State;

#region FirstExample
var products = new ProductDataReader().GetProducts();

while(true)
{
    Console.WriteLine("Item list:");
    foreach(var product in products)
        Console.WriteLine($"\t{product.Id}. {product.Name} ({product.UnitPrice:0.00})");
    Console.WriteLine();

    Order order = new();
    Console.WriteLine($"Order State: {order.State}");

    while(true)
    {
        Console.WriteLine("Enter product ID (0 for completing the order).");
        int productId;
        int.TryParse(Console.ReadLine(), out productId);

        if(productId == 0)
            break;

        Console.WriteLine("Enter product Quantity: ");
        double quantity;
        double.TryParse(Console.ReadLine(), out quantity);
        var product = products.FirstOrDefault(x => x.Id == productId);

        order.Lines.Add(new OrderLine { ProductId = productId, Quantity = quantity, UnitPrice = product.UnitPrice });
    }

    while(true)
    {
        Console.WriteLine("Select Action:");
        Console.WriteLine("\t1. Confirm");
        Console.WriteLine("\t2. Cancel");
        Console.WriteLine("\t3. Process");
        Console.WriteLine("\t4. Ship");
        Console.WriteLine("\t5. Deliver");
        Console.WriteLine("\t6. Return");
        Console.WriteLine("\t0. Exit");
        try
        {
            var action = int.Parse(Console.ReadLine());
            if(action == 0)
                break;

            var orderState = (OrderState)action;
            switch(orderState)
            {
                case OrderState.Confirmed:
                    order.Confirm();
                    break;
                case OrderState.Canceled:
                    order.Cancel();
                    break;
                case OrderState.UnderProcessing:
                    order.Process();
                    break;
                case OrderState.Shipped:
                    order.Ship();
                    break;
                case OrderState.Delivered:
                    order.Deliver();
                    break;
                case OrderState.Returned:
                    order.Return();
                    break;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Order state changed to {order.State}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        catch(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ForegroundColor = ConsoleColor.White;
        }


    }
}
#endregion

#region SecondExample
var context = new Context();
context.InsertData();
context.UpdateData();

context.GoDevelopment();
context.InsertData();
context.UpdateData();

context.GoProduction();
context.InsertData();
context.UpdateData();
#endregion

/** Summery
 * The State Pattern is a behavioral design pattern that allows an object to alter its behavior when its internal state changes.
 * The object will appear to change its class. This pattern is a way to represent state machines and transitions between states
 * in a more organized and maintainable manner.
 *
 * Key components:
 * - Context: Class that maintains a reference to the current state object. It delegates state-specific behavior to the current state.
 * - State: Interface or abstract class that defines state-specific methods to be implemented by concrete state classes.
 * - Concrete State: Classes that implement the State interface, representing specific states and their behaviors.
 * - Context Interface (Optional): An interface that defines methods for the context to interact with states dynamically.
 *
 * The State Pattern promotes loose coupling between the context and its states, making it suitable for scenarios where
 * an object's behavior depends on its internal state.
 *
 * Example usage is provided in the code above.
 */
