namespace Supplement_P1_9.Tests;

public class UnitTest1
{
    [Fact]
    public void Exception_WithMessage()
    {
         var exception = new InvalidSequenceException();
        Assert.Equal("Invalid sequence detected: Three consecutive values ≤ 0.5", exception.Message);

    }
    [Fact]
    public void ShouldGenerateNumbersBetween0And1()
    {
        var generator = new RandomFloatingNumberGenerator();
        var numbers = generator.Take(15).ToList();

        Assert.All(numbers, number => Assert.InRange(number, 0.0f, 1.0f)); // Expecting float values
    }
    [Fact]
    public void ShouldThrowExceptionOnThreeConsecutiveLowNumbers()
    {
        var generator = new RandomFloatingNumberGenerator();
        var enumerator = generator.GetEnumerator();

        Assert.Throws<InvalidSequenceException>(() =>
        {
            while (enumerator.MoveNext()) { }
        });
    }
}
