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

    private int GetQuarter()
    {
        if (Value < 0.25) return 1;
        if (Value < 0.5) return 2;
        if (Value < 0.75) return 3;
        return 4;
    }

    public static bool operator ==(Quarter? q1, Quarter? q2)
    {
        if (ReferenceEquals(q1, q2)) return true;
        if (q1 is null || q2 is null) return false;
        return q1.GetQuarter() == q2.GetQuarter();
    }

    public static bool operator !=(Quarter? q1, Quarter? q2) => !(q1 == q2);
   

    public static bool operator >(Quarter q1, Quarter q2) => q1.Value > q2.Value;

    public static bool operator <(Quarter q1, Quarter q2) => q1.Value < q2.Value;

    public static bool operator >=(Quarter q1, Quarter q2) => q1.Value >= q2.Value;

    public static bool operator <=(Quarter q1, Quarter q2) => q1.Value <= q2.Value;

    public override bool Equals(object? obj)
        {
            return obj is Quarter q && this == q;
        }

        public override int GetHashCode()
        {
            return GetQuarter().GetHashCode();
        }
}

