using Mediator;

IChatMediator chatMediator = new ConcreteChatMediator();
User ali = new ConcreteUser(chatMediator, "ALi");
User hassan = new ConcreteUser(chatMediator, "Hassan");
User mohamed = new ConcreteUser(chatMediator, "Mohamed");

chatMediator.AddUser(ali);
chatMediator.AddUser(hassan);
chatMediator.AddUser(mohamed);

ali.Send("Hi, i'm  Ali!");
hassan.Send("Hi, i'm Hassan !");
mohamed.Send("Hi, i'm Mohamed!");

/* Summery
 * The Mediator Pattern is a behavioral design pattern that promotes loose coupling between objects
 * by centralizing their communication through a mediator object.
 * It is used to define an object that encapsulates how a set of objects interact, thus allowing them
 * to communicate without having explicit references to each other.
 *
 * Key Participants:
 * - Mediator: Defines the communication interface between Colleague objects.
 * - ConcreteMediator: Implements the Mediator interface and acts as a central hub for communication
 *   between Colleague objects.
 * - Colleague: Represents individual objects that need to communicate with each other through the Mediator.
 * - ConcreteColleague: Implements the Colleague interface and communicates via the Mediator.
 *
 * Benefits:
 * - Reduces dependencies between objects, making the system easier to maintain and extend.
 * - Simplifies the understanding of how objects collaborate.
 */
