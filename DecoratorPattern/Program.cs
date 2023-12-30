using DecoratorPattern;

var smsService = new ConcreteSMSService();
var notificationEmailService = new NotificationEmailDecorator();
notificationEmailService.SetService(smsService);
Console.WriteLine(notificationEmailService.SendSMS("6521", "0123456252", "Message content"));


/*
 * The Decorator Pattern is a design pattern in software engineering that allows behavior to be added to individual objects,
 * either statically or dynamically, without affecting the behavior of other objects from the same class.
 * It is a structural pattern that provides an alternative to subclassing for extending functionality.
 */