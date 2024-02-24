using LitePrimitives.UnitTests.Helpers.Fakes;

namespace LitePrimitives.UnitTests.Extensions.EitherExtensionsTests;

public class BindRightTests
{
    private readonly FakeBind _sut = new();

    [Fact]
    public void Returns_Left_Value_When_Either_Parameter_Is_In_The_Left_State()
    {
        const bool expected = EitherConstants.SecondLeftValue;
        var parameter = Either<bool, int>.Left(expected);

        var actual = parameter.BindRight(_sut.TestRightEitherFunc);

        using var _ = new AssertionScope();
        _sut.TimesCalled.Should().Be(0);
        actual.ShouldReturnLeftValueOnMatch(expected);
    }

    [Fact]
    public void Returns_Bind_Right_Value_When_Either_Parameter_Is_In_The_Right_State()
    {
        const bool expected = EitherConstants.SecondRightValue;
        var parameter = Either<bool, int>.Right(EitherConstants.FirstRightValue);

        var actual = parameter.BindRight(_sut.TestRightEitherFunc);

        using var _ = new AssertionScope();
        _sut.TimesCalled.Should().Be(1);
        actual.ShouldReturnRightValueOnMatch(expected);
    }
}