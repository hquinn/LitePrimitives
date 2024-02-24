namespace LitePrimitives.UnitTests.Common.OptionTests;

public class SomeTests
{
    [Fact]
    public void Returns_Option_From_Value()
    {
        const bool expected = OptionConstants.ExpectedValue;
        
        Option<bool>.Some(expected).ShouldReturnValueOnMatch(expected);
    }
}