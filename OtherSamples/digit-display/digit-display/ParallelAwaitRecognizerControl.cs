﻿using digits;

namespace DigitDisplay;

public class ParallelAwaitRecognizerControl : RecognizerControl
{
    public ParallelAwaitRecognizerControl(string controlTitle, double displayMultiplier) :
        base($"{controlTitle} (Parallel await)", displayMultiplier) { }

    protected override async Task Run(DigitImage[] rawData, Classifier classifier)
    {
        var allTasks = new List<Task>();

        foreach (var imageData in rawData)
        {
            allTasks.Add(ProcessRecord(imageData, classifier));
        }
        await Task.WhenAll(allTasks);
    }

    private async Task ProcessRecord(DigitImage imageData, Classifier classifier)
    {
        var result = await classifier.Predict(imageData);
        CreateUIElements(result, DigitsBox);
    }
}
