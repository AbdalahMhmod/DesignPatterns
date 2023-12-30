using BusinessDelegate;

var appGetway = new AppGetway();
appGetway.Login("mohamed", "123");
appGetway.BuyOnline();

/* Summary
   Summary: The Business Delegate Pattern is a design pattern used in software development
   to separate the presentation tier and the business tier of an application. It promotes
   decoupling between the client code and business services, improving modularity and
   maintainability. Key components include the Business Delegate, Client, Business Service,
   and Lookup Service. This pattern abstracts service access and provides flexibility,
   load balancing, and centralized control. It's valuable for developing scalable
   enterprise-level applications.
*/
