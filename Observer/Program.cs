using Observer;

var messageObserver = new MessageObserver();
var notificationObserver = new NotificationObserver();

var messagePublisher = new MessagePublisher();

messagePublisher.Attach(messageObserver);
messagePublisher.Attach(notificationObserver);
messagePublisher.NotifyUpdate();

/* Summery
* Observer Pattern is a behavioral design pattern that defines a one-to-many
* dependency between objects. When the state of a subject changes, all its
* observers are notified and updated automatically. This pattern promotes
* loose coupling and is commonly used for implementing distributed event
* handling systems.
*
* - Subject: The object being observed.
* - Observer: An interface/abstract class defining the update method.
* - Concrete Subject: Implements the subject with state and notifies observers.
* - Concrete Observer: Implements observer and reacts to subject updates.
*
* Example use cases include UI elements reacting to data changes in graphical
* user interfaces and event-driven systems.
*/