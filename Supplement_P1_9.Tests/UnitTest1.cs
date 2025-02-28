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

    [Fact]
    public void ShouldThrowExceptionForOutOfRangeValues()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Quarter(-0.1));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Quarter(1.0));
    }

    [Fact]
    public void ShouldCorrectlyCompareQuarters()
    {
        var q1 = new Quarter(0.1);
        var q2 = new Quarter(0.2);
        var q3 = new Quarter(0.3);
        var q4 = new Quarter(0.5);
        var q5 = new Quarter(0.75);

        Assert.True(q1 == q2); // Same quarter
        Assert.False(q1 == q3); // Different quarter

        Assert.True(q3 < q4);   // 0.3 is less than 0.5
        Assert.True(q4 > q1);   // 0.5 is greater than 0.1

      
        Assert.True(q4 >= q3);  // q4 (0.5) is greater than q3 (0.3)
        Assert.True(q5 >= q4);  // q5 (0.75) is greater than q4 (0.5)
       

       
        Assert.True(q3 <= q4);  // q3 (0.3) is less than q4 (0.5)
        Assert.True(q4 <= q5);  // q4 (0.5) is less than q5 (0.75)
        
    }
}
