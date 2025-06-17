using digits;

namespace DigitDisplay;

public class ParallelTaskConstrainedRecognizerControl : RecognizerControl
{
    public ParallelTaskConstrainedRecognizerControl(string controlTitle, double displayMultiplier) :
        base($"{controlTitle} (Parallel Constrained Task)", displayMultiplier)
    { }

    protected override async Task Run(DigitImage[] rawData, Classifier classifier)
    {
        using SemaphoreSlim semaphore = new(10);
        var allTasks = new List<Task>();
        foreach (var imageData in rawData)
        {
            await semaphore.WaitAsync();
            var task = classifier.Predict(imageData);
            var continuation = task.ContinueWith(t =>
                {
                    var result = t.Result;
                    CreateUIElements(result, DigitsBox);
                    semaphore.Release();
                },
                TaskScheduler.FromCurrentSynchronizationContext()
            );
            allTasks.Add(continuation);
        }
        await Task.WhenAll(allTasks);
    }
}
