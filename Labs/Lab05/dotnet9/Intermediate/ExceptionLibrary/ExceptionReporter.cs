using System.Text;

namespace ExceptionLibrary;

public static class ExceptionReporter
{
    public static void ShowException(Exception ex)
    {
        if (ex is AggregateException)
        {
            ShowAggregate((AggregateException)ex);
            return;
        }

        StringBuilder builder = new();
        builder.AppendLine("======================");
        builder.AppendLine($"Exception: {ex.Message}");
        builder.Append("======================");

        Console.WriteLine(builder);
    }

    public static void ShowAggregate(AggregateException ex)
    {
        StringBuilder builder = new();

        var innerExceptions = ex.Flatten().InnerExceptions;
        builder.AppendLine("======================");
        builder.AppendLine($"Aggregate Exception: Count {innerExceptions.Count}");

        foreach (var inner in innerExceptions)
            builder.AppendLine($"Inner Exception: {inner!.Message}");
        builder.Append("======================");

        Console.WriteLine(builder);
    }
}
