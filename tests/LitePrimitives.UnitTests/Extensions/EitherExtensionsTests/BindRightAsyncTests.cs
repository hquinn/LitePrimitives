using LitePrimitives.UnitTests.Helpers.Fakes;

namespace LitePrimitives.UnitTests.Extensions.EitherExtensionsTests;

public class BindRightAsyncTests
{
    private readonly FakeBindAsync _sut = new();

    [Fact]
    public async Task Returns_Left_Value_When_Either_Parameter_Is_In_The_Left_State()
    {
        const bool expected = EitherConstants.SecondLeftValue;
        var parameter = Either<bool, int>.Left(expected).ToTask();

        var actual = await parameter.BindRightAsync(_sut.TestRightEitherFunc);

        using var _ = new AssertionScope();
        _sut.TimesCalled.Should().Be(0);
        await actual.ShouldReturnLeftValueOnMatchAsync(expected);
    }

    [Fact]
    public async Task Returns_Bind_Right_Value_When_Either_Parameter_Is_In_The_Right_State()
    {
        const bool expected = EitherConstants.SecondRightValue;
        var parameter = Either<bool, int>.Right(EitherConstants.FirstRightValue).ToTask();

        var actual = await parameter.BindRightAsync(_sut.TestRightEitherFunc);

        using var _ = new AssertionScope();
        _sut.TimesCalled.Should().Be(1);
        await actual.ShouldReturnRightValueOnMatchAsync(expected);
    }
}