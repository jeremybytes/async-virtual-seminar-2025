using System.Collections;

namespace EnumerableLibrary;

public class FibonacciSequence : IEnumerable<int>
{
    public IEnumerator<int> GetEnumerator()
    {
        var value = (current: 0, next: 1);

        while (true)
        {
            value = NextFibonacci(value);
            yield return value.current;
        }
    }

    private static (int, int) NextFibonacci((int current, int next) value)
    {
        checked
        {
            return (value.next, value.current + value.next);
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class AsyncFibonacciSequence : IAsyncEnumerable<int>
{
    public async IAsyncEnumerator<int> GetAsyncEnumerator(
        CancellationToken cancellationToken = default)
    {
        var value = (current: 0, next: 1);

        while (true)
        {
            value = await NextFibonacci(value);
            yield return value.current;
        }
    }

    private static Task<(int, int)> NextFibonacci((int current, int next) value)
    {
        checked
        {
            return Task.FromResult(
                (value.next, value.current + value.next));
        }
    }
}