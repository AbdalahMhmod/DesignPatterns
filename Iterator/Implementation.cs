namespace Iterator
{
    public class User
    {
        public string Name { get; set; }

        public string Email { get; set; }
    }

    public interface IIterator<T>
    {
        void Reset();

        T Next();

        T Current();

        bool HasNext();
    }

    public class UserIterator : IIterator<User>
    {
        private readonly List<User> _users;

        public UserIterator(List<User> users)
        {
            _users = users;
        }

        private int index;
        public User Current()
        {
            return _users[index];
        }

        public bool HasNext()
        {
            return index < _users.Count;
        }

        public User Next()
        {
            return _users[index++];
        }

        public void Reset()
        {
            index = 0;
        }
    }

    public interface IUserList
    {
        IIterator<User> Iterator();
    }

    public class UserList : IUserList
    {
        private readonly List<User> _users;

        public UserList(List<User> users)
        {
            _users = users;
        }

        public IIterator<User> Iterator()
        {
            return new UserIterator(_users);
        }
    }
}
