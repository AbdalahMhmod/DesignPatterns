namespace Singleton
{
    //You might ask why we cannot set this class as an abstract or static? because we need to create an instance from it at the end.
    public class Logger
    {
        private static Logger? _logger;

        // Note that it doesn't have a set part so it has a private access modifier by default.
        public static Logger Instance
        {
            get
            {
                _logger ??= new Logger(); // Setting new instance one time only and use it every time you need it.
                return _logger;
            }
        }

        // Here is the constructer is private to prevent others from creating a new instance of the class.
        private Logger()
        {

        }

        // This is called a singleton operation.
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }


    // Another implementation using Lazy<T> to be a thread-safe,
    // which prevents many threads to create new instance of this class concurrently.
    public class LazyLogger
    {
        private static readonly Lazy<LazyLogger> _lazyLogger
            = new Lazy<LazyLogger>(() => new LazyLogger());

        // Note that it doesn't have a set part so it has a private access modifier by default.
        public static LazyLogger Instance
        {
            get
            {
                return _lazyLogger.Value;
            }
        }

        // Here is the constructer is private to prevent others from creating a new instance of the class.
        private LazyLogger()
        {

        }

        // This is called a singleton operation.
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
