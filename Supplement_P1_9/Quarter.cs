using System;
namespace Supplement_P1_9;


public class Quarter
{
    public double Value { get; }

    public Quarter(double value)
    {
        if (value < 0.0 || value >= 1.0)
            throw new ArgumentOutOfRangeException(nameof(value), "Value must be in range [0.0, 1.0).");

        Value = value;
    }

    public static bool operator ==(Quarter q1, Quarter q2)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(Quarter q1, Quarter q2)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(Quarter q1, Quarter q2)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(Quarter q1, Quarter q2)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(Quarter q1, Quarter q2)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(Quarter q1, Quarter q2)
    {
        throw new NotImplementedException();
    }
}
