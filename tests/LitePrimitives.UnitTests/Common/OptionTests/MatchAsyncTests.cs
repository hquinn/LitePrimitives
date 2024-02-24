namespace LitePrimitives.UnitTests.Common.OptionTests;

public class MatchAsyncTests
{
    [Fact] 
    public async Task Returns_Null_When_Option_Is_Created_In_The_None_State()
    {
        var sut = Option<bool>.None();
        await sut.ShouldReturnNothingOnMatchAsync();
    }

    [Fact]
    public async Task Returns_Value_When_Option_Is_Created_In_The_Some_State()
    {
        const bool expected = OptionConstants.ExpectedValue;
        
        var sut = Option<bool>.Some(expected);
        await sut.ShouldReturnValueOnMatchAsync(expected);
    }
}