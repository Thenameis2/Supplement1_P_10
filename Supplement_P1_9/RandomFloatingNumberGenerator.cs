namespace Supplement_P1_9;
using System.Collections;
using System.Collections.Generic;

public class RandomFloatingNumberGenerator: IEnumerable<float>
{
    private Random _random = new Random();

    /// <summary>
    /// Generates an infinite sequence of random floating-point numbers between 0 and 1.
    /// If three consecutive numbers are <= 0.5, an InvalidSequenceException is thrown.
    /// </summary>
    /// <returns>An enumerator that iterates over random float values.</returns>
    /// <exception cref="InvalidSequenceException">Thrown when three consecutive numbers are <= 0.5.</exception>
    public IEnumerator<float> GetEnumerator()
    {
         int lowCount = 0;

        while (true)
        {
            float number = (float)_random.NextDouble(); // Cast to float
            yield return number;

            if (number <= 0.5f)
                lowCount++;
            else
                lowCount = 0;

            if (lowCount == 3)
                throw new InvalidSequenceException();
        }
    }

    /// <summary>
    /// Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>An IEnumerator instance.</returns>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

}
