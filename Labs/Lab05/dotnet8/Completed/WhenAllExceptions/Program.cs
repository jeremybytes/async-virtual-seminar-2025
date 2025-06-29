﻿using ExceptionLibrary;
using System.Threading.Tasks;

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
        catch (Exception)
        {
            Console.WriteLine("You shouldn't be here.");
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
                try
                {
                    Console.WriteLine($"Processing item: {i}");
                    await Task.Delay(10); // simulate async task
                    MightThrow.Throw(frequency, $"Error in RunProcess loop: #{i}");
                    Interlocked.Increment(ref TotalProcessed);
                }
                catch (Exception ex)
                {
                    Interlocked.Increment(ref TotalExceptions);
                    ExceptionReporter.ShowException(ex);
                }
            });
            allTasks.Add(currentTask);
        }

        await Task.WhenAll(allTasks);
    }
}
