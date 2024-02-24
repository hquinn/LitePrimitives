namespace LitePrimitives.UnitTests.Common.EitherTests;

public class MatchTests
{
    [Fact] 
    public void Returns_Left_Value_When_Either_Is_Created_In_The_Left_State()
    {
        const bool expected = EitherConstants.ExpectedLeftValue;
        
        var sut = Either<bool, int>.Left(expected);
        sut.ShouldReturnLeftValueOnMatch(expected);
    }

    [Fact]
    public void Returns_Right_Value_When_Either_Is_Created_In_The_Right_State()
    {
        const int expected = EitherConstants.ExpectedRightValue;
        
        var sut = Either<bool, int>.Right(expected);
        sut.ShouldReturnRightValueOnMatch(expected);
    }
}