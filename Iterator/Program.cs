using Iterator;

var users = new List<User>
{
    new User { Email = "mohamed@gmail.com", Name = "mohamed" },
    new User { Email = "mohamed1@gmail.com", Name = "mohamed1" },
    new User { Email = "mohamed2@gmail.com", Name = "mohamed2" },
    new User { Email = "mohamed3@gmail.com", Name = "mohamed3" },
    new User { Email = "mohamed4@gmail.com", Name = "mohamed4" }
};

IUserList userList = new UserList(users);
IIterator<User> userIterator = userList.Iterator();

while(userIterator.HasNext())
{
    Console.WriteLine(userIterator.Next().Name);
}

/* summary
   The Iterator Pattern allows you to iterate over the elements of a collection without exposing its internal structure,
   supports multiple iterators for the same collection with individual traversal states, and promotes a consistent
   way to traverse different types of collections. It enhances code maintainability and flexibility by encapsulating
   collection details and providing a uniform interface for iteration.
*/
