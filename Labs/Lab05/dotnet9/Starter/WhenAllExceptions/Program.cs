using ExceptionLibrary;

namespace WhenAllExceptions;

internal class Program
{
    private static int TotalProcessed;
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

        Console.WriteLine($"Total Processed: {TotalProcessed}");
        Console.WriteLine($"Total Exceptions: {TotalExceptions}");
        Console.WriteLine("Done");
    }

    private static async Task RunProcess(int numberOfItems)
    {
        List<Task> allTasks = new();

        foreach (var i in Enumerable.Range(1, numberOfItems))
        {
            Task currentTask = Task.Run(async () =>
            {
                Console.WriteLine($"Processing item: {i}");
                await Task.Delay(10); // simulate async task
                MightThrow.Throw(frequency, $"Error in RunProcess loop: #{i}");
                TotalProcessed++;
            });
            allTasks.Add(currentTask);
        }

        await Task.WhenAll(allTasks);
    }
}
