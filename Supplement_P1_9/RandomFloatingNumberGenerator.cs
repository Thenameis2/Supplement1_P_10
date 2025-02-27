namespace Supplement_P1_9;
using System.Collections;
using System.Collections.Generic;

public class RandomFloatingNumberGenerator: IEnumerable<float>
{
    private Random _random = new Random();

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

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

}
