namespace LitePrimitives.UnitTests.Common.EitherTests;

public class RightTests
{
    [Fact]
    public void Returns_Either_From_Value()
    {
        const int expected = EitherConstants.ExpectedRightValue;
        
        Either<bool, int>.Right(expected).ShouldReturnRightValueOnMatch(expected);
    }
}