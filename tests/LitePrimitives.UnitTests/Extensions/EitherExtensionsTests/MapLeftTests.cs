namespace LitePrimitives.UnitTests.Extensions.EitherExtensionsTests;

public class MapLeftTests
{
    [Fact]
    public void Returns_Mapped_Left_Value_When_Either_Parameter_Is_In_The_Left_State()
    {
        const int expected = EitherConstants.FirstLeftValue;
        var sut = Either<bool, bool>.Left(EitherConstants.SecondLeftValue);

        var actual = sut.MapLeft(_ => EitherConstants.FirstLeftValue);

        actual.ShouldReturnLeftValueOnMatch(expected);
    }

    [Fact]
    public void Returns_Right_Value_When_Either_Parameter_Is_In_The_Right_State()
    {
        const bool expected = EitherConstants.SecondRightValue;
        var sut = Either<bool, bool>.Right(EitherConstants.SecondRightValue);

        var actual = sut.MapLeft(_ => EitherConstants.FirstLeftValue);

        actual.ShouldReturnRightValueOnMatch(expected);
    }
}