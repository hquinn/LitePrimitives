namespace LitePrimitives.UnitTests.Common.EitherTests;

public class MatchAsyncTests
{
    [Fact] 
    public async Task Returns_Left_Value_When_Either_Is_Created_In_The_Left_State()
    {
        const bool expected = EitherConstants.ExpectedLeftValue;
        
        var sut = Either<bool, int>.Left(expected);
        await sut.ShouldReturnLeftValueOnMatchAsync(expected);
    }

    [Fact]
    public async Task Returns_Right_Value_When_Either_Is_Created_In_The_Right_State()
    {
        const int expected = EitherConstants.ExpectedRightValue;
        
        var sut = Either<bool, int>.Right(expected);
        await sut.ShouldReturnRightValueOnMatchAsync(expected);
    }
}