using System;
namespace Supplement_P1_9;


public class Quarter
{
    /// <summary>
    /// The floating-point value associated with the quarter.
    /// </summary>
    public double Value { get; }

    /// <summary>
    /// Initializes a new instance of the Quarter class.
    /// </summary>
    /// <param name="value">A floating-point number between 0.0 and 1.0</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public Quarter(double value)
    {
        if (value < 0.0 || value >= 1.0)
            throw new ArgumentOutOfRangeException(nameof(value), "Value must be in range [0.0, 1.0).");

        Value = value;
    }

    /// <summary>
    /// Determines the quarter of the current value.
    /// </summary>
    /// <returns>An integer representing the quarter (1 to 4).</returns>
    public int GetQuarter()
    {
        if (Value < 0.25) return 1;
        if (Value < 0.5) return 2;
        if (Value < 0.75) return 3;
        return 4;
    }

    /// <summary>
    /// Checks if two Quarter objects are equal (same quarter).
    /// </summary>
    /// <param name="q1"></param>
    /// <param name="q2"></param>
    /// <returns></returns>
    public static bool operator ==(Quarter? q1, Quarter? q2)
    {
        if (ReferenceEquals(q1, q2)) return true;
        if (q1 is null || q2 is null) return false;
        return q1.GetQuarter() == q2.GetQuarter();
    }

    /// <summary>
    /// Checks if two Quarter objects are not equal (different quarters).
    /// </summary>
    /// <param name="q1"></param>
    /// <param name="q2"></param>
    /// <returns></returns>
    public static bool operator !=(Quarter? q1, Quarter? q2) => !(q1 == q2);
   

    /// <summary>
    /// Determines if one Quarter object is greater than another.
    /// </summary>
    /// <param name="q1">The first Quarter object.</param>
    /// <param name="q2">The second Quarter object.</param>
    /// <returns></returns>
    public static bool operator >(Quarter q1, Quarter q2) => q1.Value > q2.Value;

    /// <summary>
    /// Determines if one Quarter object is less than another.
    /// </summary>
    /// <param name="q1">The first Quarter object.</param>
    /// <param name="q2">The second Quarter object.</param>
    public static bool operator <(Quarter q1, Quarter q2) => q1.Value < q2.Value;

    /// <summary>
    /// Determines if one Quarter object is greater than or equal to another.
    /// </summary>
    /// <param name="q1">The first Quarter object.</param>
    /// <param name="q2">The second Quarter object.</param>
    public static bool operator >=(Quarter q1, Quarter q2) => q1.Value >= q2.Value;

    /// <summary>
    /// Determines if one Quarter object is less than or equal to another.
    /// </summary>
    /// /// <param name="q1">The first Quarter object.</param>
    /// <param name="q2">The second Quarter object.</param>
    public static bool operator <=(Quarter q1, Quarter q2) => q1.Value <= q2.Value;

    /// <summary>
    /// Overrides the Equals method for proper equality checking.
    /// </summary>
    /// <param name="obj">The object to compare with the current Quarter instance.</param>
    /// <returns>True if the specified object is a Quarter and belongs to the same quarter as the current instance; otherwise, false.</returns>
    public override bool Equals(object? obj)
        {
            return obj is Quarter q && this == q;
        }

        /// <summary>
        /// Overrides GetHashCode to ensure objects in the same quarter have the same hash.
        /// </summary>
        /// <returns>An integer hash code representing the quarter in which this Quarter instance falls.</returns>
        public override int GetHashCode()
        {
            return GetQuarter().GetHashCode();
        }
}

