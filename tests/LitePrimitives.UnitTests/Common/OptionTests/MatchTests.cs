namespace LitePrimitives.UnitTests.Common.OptionTests;

public class MatchTests
{
    [Fact] 
    public void Returns_Null_When_Option_Is_Created_In_The_None_State()
    {
        var sut = Option<bool>.None();
        sut.ShouldReturnNothingOnMatch();
    }

    [Fact]
    public void Returns_Value_When_Option_Is_Created_In_The_Some_State()
    {
        const bool expected = OptionConstants.ExpectedValue;
        
        var sut = Option<bool>.Some(expected);
        sut.ShouldReturnValueOnMatch(expected);
    }
}