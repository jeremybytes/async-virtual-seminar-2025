namespace digits;

public abstract class Classifier
{
    public string Name { get; set; }
    public DigitImage[] TrainingData { get; set; }

    public Classifier(string name, DigitImage[] trainingData)
    {
        Name = name;
        TrainingData = trainingData;
    }

    public abstract Task<Prediction> Predict(DigitImage input);
}

