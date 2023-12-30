namespace Mediator
{
    /// <summary>
    /// Abstract Colleague.
    /// </summary>
    public abstract class User
    {
        protected readonly IChatMediator _chatMediator;
        protected readonly string _name;
        protected User(IChatMediator chatMediator, string name)
        {
            _chatMediator = chatMediator;
            this._name = name;
        }

        public abstract void Send(string message);
        public abstract void Recieve(string message);
    }

    /// <summary>
    /// Concrete Colleague.
    /// </summary>
    public class ConcreteUser : User
    {
        public ConcreteUser(IChatMediator chatMediator, string name)
            : base(chatMediator, name)
        {
        }

        public override void Recieve(string message)
        {
            Console.WriteLine($"{message}: Recieved successfully");
        }

        public override void Send(string message)
        {
            _chatMediator.SendMessage(this, message);
        }
    }

    /// <summary>
    /// Abstract Mediator.
    /// </summary>
    public interface IChatMediator
    {
        void SendMessage(User user, string message);
        void AddUser(User user);
    }

    /// <summary>
    /// Concrete Mediator.
    /// </summary>
    public class ConcreteChatMediator : IChatMediator
    {
        private readonly List<User> _users = new List<User>();
        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public void SendMessage(User user, string message)
        {
            foreach(var userInList in _users)
            {
                if(userInList != user)
                    user.Recieve(message);
            }
        }
    }
}
