namespace ExceptionLibrary;

public static class MightThrow
{
    private static Random Randomizer { get; } = new();

    public static void Throw(int frequency, string message)
    {
        if (Randomizer.Next() % frequency == 0)
        {
            throw new Exception(message);
        }
    }
}
