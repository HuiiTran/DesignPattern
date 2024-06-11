// Define the interface that the real object will implement
using static System.Net.Mime.MediaTypeNames;

public interface IExpensiveObject
{
    string GetResult();
}

// Define the class that implements the real object
public class ExpensiveObject : IExpensiveObject
{
    public string GetResult()
    {
        // Simulate an expensive operation
        Thread.Sleep(500);
        return "Result from ExpensiveObject";
    }
}

// Define the caching proxy class that will cache the results of calls to the real object
public class CachingProxy : IExpensiveObject
{
    private readonly IExpensiveObject _realObject;
    private string _cachedResult;

    public CachingProxy(IExpensiveObject realObject)
    {
        _realObject = realObject;
    }

    public string GetResult()
    {
        if (_cachedResult == null)
        {
            _cachedResult = _realObject.GetResult();
        }

        return _cachedResult;
    }
}

// Example usage
class Program
{
    static void Main(string[] args)
    {

        var expensiveObject = new ExpensiveObject();
        var cachingProxy = new CachingProxy(expensiveObject);



        var watch = System.Diagnostics.Stopwatch.StartNew();
        // First call will be slow, as the result is not cached
        Console.WriteLine(cachingProxy.GetResult());
        watch.Stop();
        var elapsedMs = watch.ElapsedMilliseconds;
        Console.WriteLine("Time 1st excuted: " + elapsedMs);

        watch = System.Diagnostics.Stopwatch.StartNew();
        // Subsequent calls will be fast, as the result is cached
        Console.WriteLine(cachingProxy.GetResult());
        watch.Stop();
        elapsedMs = watch.ElapsedMilliseconds;
        Console.WriteLine("Time 2nd excuted: " + elapsedMs);
    }
}

