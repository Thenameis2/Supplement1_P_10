namespace Supplement_P1_9;

public class InvalidSequenceException : Exception
{
    public InvalidSequenceException() : base("Invalid sequence detected: Three consecutive values ≤ 0.5") { }
}