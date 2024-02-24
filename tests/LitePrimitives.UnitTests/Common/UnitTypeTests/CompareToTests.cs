namespace LitePrimitives.UnitTests.Common.UnitTypeTests;

public class CompareToTests
{
    [Fact]
    public void Returns_Zero()
    {
        Unit.Default.CompareTo(Unit.Default).Should().Be(0);
    }
}