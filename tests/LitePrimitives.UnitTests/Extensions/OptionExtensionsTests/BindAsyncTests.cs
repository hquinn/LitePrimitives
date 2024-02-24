using LitePrimitives.UnitTests.Helpers.Fakes;

namespace LitePrimitives.UnitTests.Extensions.OptionExtensionsTests;

public class BindAsyncTests
{
    private readonly FakeBindAsync _sut = new();
    
    [Fact]
    public async Task Returns_Null_When_Option_parameter_Is_In_The_None_State()
    {
        var parameter = Option<int>.None().ToTask();

        var actual = await parameter.BindAsync(_sut.TestOptionFunc);
        
        using var _ = new AssertionScope();
        _sut.TimesCalled.Should().Be(0);
        await actual.ShouldReturnNothingOnMatchAsync();
    }

    [Fact]
    public async Task Returns_Bind_Value_When_Option_Parameter_Is_In_The_Some_State()
    {
        const bool expected = OptionConstants.FirstValue;
        var parameter = Option<int>.Some(OptionConstants.SecondValue).ToTask();

        var actual = await parameter.BindAsync(_sut.TestOptionFunc);

        using var _ = new AssertionScope();
        _sut.TimesCalled.Should().Be(1);
        await actual.ShouldReturnValueOnMatchAsync(expected);
    }
}