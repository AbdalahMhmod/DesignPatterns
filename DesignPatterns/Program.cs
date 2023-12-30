using Singleton;

Console.Title = "Singleton";

var logger1 = Logger.Instance;
var logger2 = Logger.Instance;

if(logger1 == logger2 && logger2 == Logger.Instance)
{
    Console.WriteLine("All instances are the same");
}

logger1.Log($"Message from {nameof(logger1)}");
logger1.Log($"Message from {nameof(logger2)}");

Logger.Instance.Log($"Message from {nameof(Logger.Instance)}");