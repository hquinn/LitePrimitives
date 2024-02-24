using LitePrimitives.UnitTests.Helpers.Fakes;

namespace LitePrimitives.UnitTests.Extensions.OptionExtensionsTests;

public class BindTests
{
    private readonly FakeBind _sut = new();
    
    [Fact]
    public void Returns_Null_When_Option_parameter_Is_In_The_None_State()
    {
        var parameter = Option<int>.None();

        var actual = parameter.Bind(_sut.TestOptionFunc);
        
        using var _ = new AssertionScope();
        _sut.TimesCalled.Should().Be(0);
        actual.ShouldReturnNothingOnMatch();
    }

    [Fact]
    public void Returns_Bind_Value_When_Option_Parameter_Is_In_The_Some_State()
    {
        const bool expected = OptionConstants.FirstValue;
        var parameter = Option<int>.Some(OptionConstants.SecondValue);

        var actual = parameter.Bind(_sut.TestOptionFunc);

        using var _ = new AssertionScope();
        _sut.TimesCalled.Should().Be(1);
        actual.ShouldReturnValueOnMatch(expected);
    }
}