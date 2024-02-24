namespace LitePrimitives.UnitTests.Extensions.OptionExtensionsTests;

public class OnNoneAsyncTests
{
    [Fact]
    public async Task Performs_Action_When_Option_Parameter_Is_In_The_None_State()
    {
        var actual = false;
        var sut = Option<bool>.None();

        var result = await sut.OnNoneAsync(() => Task.FromResult(actual = true));

        using var _ = new AssertionScope();
        actual.Should().BeTrue();
        result.Should().Be(sut);
    }
    
    [Fact]
    public async Task Performs_Action_When_Option_Task_Parameter_Is_In_The_None_State()
    {
        var actual = false;
        var sut = Option<bool>.None().ToTask();
        var awaitedSut = await sut;

        var result = await sut.OnNoneAsync(() => Task.FromResult(actual = true));

        using var _ = new AssertionScope();
        actual.Should().BeTrue();
        result.Should().Be(awaitedSut);
    }
    
    [Fact]
    public async Task Performs_Action_When_Option_Parameter_Is_In_The_None_State_Unit_Override()
    {
        var actual = false;
        var sut = Option<bool>.None();

        var result = await sut.OnNoneAsync(() =>
        {
            actual = true;
            return Task.FromResult(Unit.Default);
        });

        using var _ = new AssertionScope();
        actual.Should().BeTrue();
        result.Should().Be(sut);
    }
    
    [Fact]
    public async Task Performs_Action_When_Option_Task_Parameter_Is_In_The_None_State_Unit_Override()
    {
        var actual = false;
        var sut = Option<bool>.None().ToTask();
        var awaitedSut = await sut;

        var result = await sut.OnNoneAsync(() =>
        {
            actual = true;
            return Task.FromResult(Unit.Default);
        });

        using var _ = new AssertionScope();
        actual.Should().BeTrue();
        result.Should().Be(awaitedSut);
    }

    [Fact]
    public async Task Only_Returns_Option_When_Option_Parameter_Is_In_The_Some_State()
    {
        var actual = false;
        var sut = Option<bool>.Some(OptionConstants.ExpectedValue);

        var result = await sut.OnNoneAsync(() => Task.FromResult(actual = true));

        using var _ = new AssertionScope();
        actual.Should().BeFalse();
        result.Should().Be(sut);
    }

    [Fact]
    public async Task Only_Returns_Option_When_Option_Task_Parameter_Is_In_The_Some_State()
    {
        var actual = false;
        var sut = Option<bool>.Some(OptionConstants.ExpectedValue).ToTask();
        var awaitedSut = await sut;

        var result = await sut.OnNoneAsync(() => Task.FromResult(actual = true));

        using var _ = new AssertionScope();
        actual.Should().BeFalse();
        result.Should().Be(awaitedSut);
    }

    [Fact]
    public async Task Only_Returns_Option_When_Option_Parameter_Is_In_The_Some_State_Unit_Override()
    {
        var actual = false;
        var sut = Option<bool>.Some(OptionConstants.ExpectedValue);

        var result = await sut.OnNoneAsync(() =>
        {
            actual = true;
            return Task.FromResult(Unit.Default);
        });

        using var _ = new AssertionScope();
        actual.Should().BeFalse();
        result.Should().Be(sut);
    }

    [Fact]
    public async Task Only_Returns_Option_When_Option_Task_Parameter_Is_In_The_Some_State_Unit_Override()
    {
        var actual = false;
        var sut = Option<bool>.Some(OptionConstants.ExpectedValue).ToTask();
        var awaitedSut = await sut;

        var result = await sut.OnNoneAsync(() =>
        {
            actual = true;
            return Task.FromResult(Unit.Default);
        });

        using var _ = new AssertionScope();
        actual.Should().BeFalse();
        result.Should().Be(awaitedSut);
    }
}