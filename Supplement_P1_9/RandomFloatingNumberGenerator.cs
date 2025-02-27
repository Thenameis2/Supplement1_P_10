namespace Supplement_P1_9;

public class RandomFloatingNumberGenerator: IEnumerable<float>
{
    private Random _random = new Random();

    public IEnumerator<float> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

}
