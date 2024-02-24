namespace LitePrimitives.UnitTests.Extensions.OptionExtensionsTests;

public class OnSomeTests
{
    [Fact]
    public void Performs_Action_When_Option_Parameter_Is_In_The_Some_State()
    {
        var actual = false;
        var sut = Option<bool>.Some(OptionConstants.ExpectedValue);

        var result = sut.OnSome(value => actual = value);

        using var _ = new AssertionScope();
        actual.Should().BeTrue();
        result.Should().Be(sut);
    }
    
    [Fact]
    public void Performs_Action_When_Option_Parameter_Is_In_The_Some_State_Unit_Override()
    {
        var actual = false;
        var sut = Option<bool>.Some(OptionConstants.ExpectedValue);

        var result = sut.OnSome(value =>
        {
            actual = value;
            return Unit.Default;
        });

        using var _ = new AssertionScope();
        actual.Should().BeTrue();
        result.Should().Be(sut);
    }

    [Fact]
    public void Only_Returns_Option_When_Option_Parameter_Is_In_The_None_State()
    {
        var actual = false;
        var sut = Option<bool>.None();

        var result = sut.OnSome(value => actual = value);

        using var _ = new AssertionScope();
        actual.Should().BeFalse();
        result.Should().Be(sut);
    }

    [Fact]
    public void Only_Returns_Option_When_Option_Parameter_Is_In_The_None_State_Unit_Override()
    {
        var actual = false;
        var sut = Option<bool>.None();

        var result = sut.OnSome(value =>
        {
            actual = value;
            return Unit.Default;
        });

        using var _ = new AssertionScope();
        actual.Should().BeFalse();
        result.Should().Be(sut);
    }
}