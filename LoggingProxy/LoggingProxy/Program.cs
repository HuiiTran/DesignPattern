// Define the interface that the real object will implement
using static System.Net.Mime.MediaTypeNames;

public interface IRealObject
{
    void DoSomething();
}

// Define the class that implements the real object
public class RealObject : IRealObject
{
    public void DoSomething()
    {
        Console.WriteLine("RealObject: DoSomething() called.");
    }
}

// Define the logging proxy class that will log method calls on the real object
public class LoggingProxy : IRealObject
{
    private readonly RealObject _realObject;

    public LoggingProxy()
    {
        _realObject = new RealObject();
    }

    public void DoSomething()
    {
        Console.WriteLine("LoggingProxy: DoSomething() called.");
        _realObject.DoSomething();
        Console.WriteLine("LoggingProxy: DoSomething() finished.");
    }
}


class Program
{
    static void Main(string[] args)
    {
        // Example usage
        var loggingProxy = new LoggingProxy();
        loggingProxy.DoSomething();
    }
}

