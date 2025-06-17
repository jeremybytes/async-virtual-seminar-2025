using ExceptionLibrary;
using System.Threading.Channels;

namespace ChannelExceptions;

internal class Program
{
    private static int TotalProduced;
    private static int TotalConsumed;
    private static int TotalExceptions;
    private static int frequency = 5;

    static async Task Main(string[] args)
    {
        try
        {
            await RunProcess(100);
        }
        catch (Exception ex)
        {
            TotalExceptions++;
            ExceptionReporter.ShowException(ex);
        }

        Console.WriteLine($"Total Produced: {TotalProduced}");
        Console.WriteLine($"Total Consumed: {TotalConsumed}");
        Console.WriteLine($"Total Exceptions: {TotalExceptions}");
        Console.WriteLine("Done");
    }

    private static async Task RunProcess(int numberOfItems)
    {
        var channel = Channel.CreateUnbounded<int>();
        Task consumer = Consumer(channel.Reader);
        Task producer = Producer(numberOfItems, channel.Writer);

        await producer;
        await consumer;
    }

    private static async Task Producer(int numberOfItems,
        ChannelWriter<int> writer)
    {
        try
        {
            await Parallel.ForEachAsync(
                Enumerable.Range(1, numberOfItems),
                new ParallelOptions() { MaxDegreeOfParallelism = 10 },
                async (i, _) =>
                {
                    Console.WriteLine($"Processing item: {i}");
                    await Task.Delay(10); // simulate async task
                    MightThrow.Throw(frequency, $"Error in Producer: #{i}");
                    TotalProduced++;
                    await writer.WriteAsync(i);
                });
        }
        finally
        {
            writer.Complete();
        }
    }

    private static async Task Consumer(ChannelReader<int> reader)
    {
        await foreach (int i in reader.ReadAllAsync())
        {
            Console.WriteLine($"Consuming item: {i}");
            TotalConsumed++;
        }
    }
}
