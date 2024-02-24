namespace LitePrimitives.UnitTests.Extensions.OptionExtensionsTests;

public class MapAsyncTests
{
    [Fact]
    public async Task Returns_Mapped_Value_When_Option_Parameter_Is_In_The_Some_State()
    {
        const bool expected = OptionConstants.FirstValue;
        var sut = Option<int>.Some(OptionConstants.SecondValue);

        var actual = await sut.MapAsync(_ => Task.FromResult(OptionConstants.FirstValue));

        await actual.ShouldReturnValueOnMatchAsync(expected);
    }
    
    [Fact]
    public async Task Returns_Mapped_Value_When_Option_Task_Parameter_Is_In_The_Some_State()
    {
        const bool expected = OptionConstants.FirstValue;
        var sut = Option<int>.Some(OptionConstants.SecondValue).ToTask();

        var actual = await sut.MapAsync(_ => Task.FromResult(OptionConstants.FirstValue));

        await actual.ShouldReturnValueOnMatchAsync(expected);
    }

    [Fact]
    public async Task Returns_Nothing_When_Option_Parameter_Is_In_The_None_State()
    {
        var sut = Option<int>.None();

        var actual = await sut.MapAsync(_ => Task.FromResult(OptionConstants.FirstValue));

        await actual.ShouldReturnNothingOnMatchAsync();
    }

    [Fact]
    public async Task Returns_Nothing_When_Option_Task_Parameter_Is_In_The_None_State()
    {
        var sut = Option<int>.None().ToTask();

        var actual = await sut.MapAsync(_ => Task.FromResult(OptionConstants.FirstValue));

        await actual.ShouldReturnNothingOnMatchAsync();
    }
}