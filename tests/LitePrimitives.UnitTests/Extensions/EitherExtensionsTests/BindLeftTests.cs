using LitePrimitives.UnitTests.Helpers.Fakes;

namespace LitePrimitives.UnitTests.Extensions.EitherExtensionsTests;

public class BindLeftTests
{
    private readonly FakeBind _sut = new();

    [Fact]
    public void Returns_Right_Value_When_Either_Parameter_Is_In_The_Right_State()
    {
        const bool expected = EitherConstants.SecondRightValue;
        var parameter = Either<int, bool>.Right(expected);

        var actual = parameter.BindLeft(_sut.TestLeftEitherFunc);

        using var _ = new AssertionScope();
        _sut.TimesCalled.Should().Be(0);
        actual.ShouldReturnRightValueOnMatch(expected);
    }

    [Fact]
    public void Returns_Bind_Left_Value_When_Either_Parameter_Is_In_The_Left_State()
    {
        const bool expected = EitherConstants.SecondLeftValue;
        var parameter = Either<int, bool>.Left(EitherConstants.FirstLeftValue);

        var actual = parameter.BindLeft(_sut.TestLeftEitherFunc);

        using var _ = new AssertionScope();
        _sut.TimesCalled.Should().Be(1);
        actual.ShouldReturnLeftValueOnMatch(expected);
    }
}