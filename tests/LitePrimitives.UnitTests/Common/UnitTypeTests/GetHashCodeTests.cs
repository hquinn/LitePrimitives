namespace LitePrimitives.UnitTests.Common.UnitTypeTests;

public class GetHashCodeTests
{
    [Fact]
    public void Returns_Zero()
    {
        Unit.Default.GetHashCode().Should().Be(0);
    }
}