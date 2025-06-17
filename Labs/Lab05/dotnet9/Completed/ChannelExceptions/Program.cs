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
        catch (Exception)
        {
            Console.WriteLine("You shouldn't be here.");
        }

        Console.WriteLine($"Total Produced: {TotalProduced}");
        Console.WriteLine($"Total Consumed: {TotalConsumed}");
        Console.WriteLine($"Total Exceptions: {TotalExceptions}");
        Console.WriteLine("Done");
    }

    private static async Task RunProcess(int numberOfItems)
    {
        var channel = Channel.CreateUnbounded<int>();
        var errorChannel = Channel.CreateUnbounded<Exception>();

        Task consumer = Consumer(channel.Reader,
                                    errorChannel.Writer);
        Task producer = Producer(numberOfItems, channel.Writer,
                                    errorChannel.Writer);

        await producer;
        await consumer;
        errorChannel.Writer.Complete();

        await ProcessErrors(errorChannel.Reader);
    }

    private static async Task Producer(int numberOfItems,
        ChannelWriter<int> writer, ChannelWriter<Exception> errorWriter)
    {
        try
        {
            await Parallel.ForEachAsync(
                Enumerable.Range(1, numberOfItems),
                new ParallelOptions() { MaxDegreeOfParallelism = 10 },
                async (i, _) =>
                {
                    try
                    {
                        Console.WriteLine($"Processing item: {i}");
                        await Task.Delay(10); // simulate async task
                        MightThrow.Throw(frequency, $"Error in Producer: #{i}");
                        Interlocked.Increment(ref TotalProduced);
                        await writer.WriteAsync(i);
                    }
                    catch (Exception ex)
                    {
                        await errorWriter.WriteAsync(ex);
                    }
                });
        }
        finally
        {
            writer.Complete();
        }
    }

    private static async Task Consumer(ChannelReader<int> reader,
        ChannelWriter<Exception> errorWriter)
    {
        await foreach (int i in reader.ReadAllAsync())
        {
            try
            {
                Console.WriteLine($"Consuming item: {i}");
                MightThrow.Throw(frequency, $"Error Consuming #{i}");
                Interlocked.Increment(ref TotalConsumed);
            }
            catch (Exception ex)
            {
                await errorWriter.WriteAsync(ex);
            }
        }
    }

    private static async Task ProcessErrors(
        ChannelReader<Exception> errorReader)
    {
        await foreach (var ex in errorReader.ReadAllAsync())
        {
            Interlocked.Increment(ref TotalExceptions);
            ExceptionReporter.ShowException(ex);
        }
    }
}
