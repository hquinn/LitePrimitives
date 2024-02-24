namespace LitePrimitives.UnitTests.Common.EitherTests;

public class LeftTests
{
    [Fact]
    public void Returns_Either_From_Value()
    {
        const bool expected = EitherConstants.ExpectedLeftValue;
        
        Either<bool, int>.Left(expected).ShouldReturnLeftValueOnMatch(expected);
    }
}