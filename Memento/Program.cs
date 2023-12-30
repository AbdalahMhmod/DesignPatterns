using Memento;

var order = new Order { Id = 1, Name = "Order name" };
var orderMemento = order.SaveStateToMemento();

var careTaker = new CareTaker();
Console.WriteLine(careTaker.AddMemento(orderMemento));
order = new Order { Id = 2, Name = "Order name1" };
orderMemento = order.SaveStateToMemento();
Console.WriteLine(careTaker.AddMemento(orderMemento));

order.RestoreStateFromMemento(careTaker.GetOrderMemento(0));
Console.WriteLine(order.Name);
order.RestoreStateFromMemento(careTaker.GetOrderMemento(1));
Console.WriteLine(order.Name);

/** Summery
 * The Memento Pattern allows objects to capture their internal state and
 * externalize it, making it possible to restore the object to that state later.
 * It is useful for implementing features like "undo" functionality.
 *
 * Components:
 * - Originator: The object whose state needs to be saved and restored.
 * - Memento: The object that stores the state of the Originator.
 * - Caretaker: Manages the Memento objects and decides when to save or
 *   restore the state of the Originator.
 *
 * Example:
 * In a text editor, the Originator can be the text document, the Memento
 * stores the document's state, and the Caretaker manages multiple states
 * for undo/redo functionality.
 */
