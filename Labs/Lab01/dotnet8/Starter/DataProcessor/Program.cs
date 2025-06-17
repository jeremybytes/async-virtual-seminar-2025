using DataProcessor.Library;

namespace DataProcessor;

internal class Program
{
    static void Main(string[] args)
    {
        var records = ProcessData();

        Console.WriteLine($"Successfully processed {records.Count()} records");
        foreach (var person in records)
        {
            Console.WriteLine(person);
        }
        Console.WriteLine("Press [Enter] to continue...");
        Console.ReadLine();
    }

    static IReadOnlyCollection<Person> ProcessData()
    {
        DataLoader loader = new();
        IReadOnlyCollection<string> data = loader.LoadData();

        FileLogger logger = new();
        DataParser parser = new(logger);
        IReadOnlyCollection<Person> records = parser.ParseData(data);
        return records;
    }
}
