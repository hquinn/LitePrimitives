using LitePrimitives.UnitTests.Helpers.Fakes;

namespace LitePrimitives.UnitTests.Extensions.EitherExtensionsTests;

public class BindLeftAsyncTests
{
    private readonly FakeBindAsync _sut = new();

    [Fact]
    public async Task Returns_Right_Value_When_Either_Parameter_Is_In_The_Right_State()
    {
        const bool expected = EitherConstants.SecondRightValue;
        var parameter = Either<int, bool>.Right(expected).ToTask();

        var actual = await parameter.BindLeftAsync(_sut.TestLeftEitherFunc);

        using var _ = new AssertionScope();
        _sut.TimesCalled.Should().Be(0);
        await actual.ShouldReturnRightValueOnMatchAsync(expected);
    }

    [Fact]
    public async Task Returns_Bind_Left_Value_When_Either_Parameter_Is_In_The_Left_State()
    {
        const bool expected = EitherConstants.SecondLeftValue;
        var parameter = Either<int, bool>.Left(EitherConstants.FirstLeftValue).ToTask();

        var actual = await parameter.BindLeftAsync(_sut.TestLeftEitherFunc);

        using var _ = new AssertionScope();
        _sut.TimesCalled.Should().Be(1);
        await actual.ShouldReturnLeftValueOnMatchAsync(expected);
    }
}