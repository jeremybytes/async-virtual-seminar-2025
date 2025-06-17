using EnumerableLibrary;
using System.Threading.Tasks;

namespace ShowEnumerables;

internal class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            Console.WriteLine("IEnumerable<int>");
            FibonacciSequence fibs = new();
            foreach (long fib in fibs)
            {
                Console.WriteLine(fib);
            }
            Console.WriteLine("IEnumerable<int> Done");
        }
        catch (OverflowException)
        {
            Console.WriteLine("IEnumerable<int> Done with Overflow");
        }

        try
        {
            Console.WriteLine("IAsyncEnumerable<int>");
            AsyncFibonacciSequence asyncFibs = new();
            await foreach (int fib in asyncFibs)
            {
                Console.WriteLine(fib);
            }
            Console.WriteLine("IAsyncEnumerable<int> Done");
        }
        catch (OverflowException)
        {
            Console.WriteLine("IAsyncEnumerable<int> Done with Overflow");
        }
    }
}
