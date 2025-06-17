namespace digits
{
    public record DigitImage (int Value, int[] Image);
    public record Prediction (DigitImage Actual, DigitImage Predicted);
}