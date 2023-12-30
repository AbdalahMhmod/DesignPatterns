namespace Observer
{
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void NotifyUpdate();
    }

    public class MessagePublisher : ISubject
    {
        private readonly List<IObserver> _observers = new List<IObserver>();
        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyUpdate()
        {
            _observers.ForEach(o => o.Update());
        }
    }

    public interface IObserver
    {
        /// <summary>
        /// Used by subject.
        /// </summary>
        void Update();
    }

    public class MessageObserver : IObserver
    {
        public void Update()
        {
            Console.WriteLine("Message updated");
        }
    }

    public class NotificationObserver : IObserver
    {
        public void Update()
        {
            Console.WriteLine("Notification updated");
        }
    }
}
