namespace LitePrimitives.UnitTests.Extensions.EitherExtensionsTests;

public class MapRightTests
{
    [Fact]
    public void Returns_Mapped_Right_Value_When_Either_Parameter_Is_In_The_Right_State()
    {
        const int expected = EitherConstants.FirstRightValue;
        var sut = Either<bool, bool>.Right(EitherConstants.SecondRightValue);

        var actual = sut.MapRight(_ => EitherConstants.FirstRightValue);

        actual.ShouldReturnRightValueOnMatch(expected);
    }

    [Fact]
    public void Returns_Left_Value_When_Either_Parameter_Is_In_The_Left_State()
    {
        const bool expected = EitherConstants.SecondLeftValue;
        var sut = Either<bool, bool>.Left(EitherConstants.SecondLeftValue);

        var actual = sut.MapRight(_ => EitherConstants.FirstRightValue);

        actual.ShouldReturnLeftValueOnMatch(expected);
    }
}