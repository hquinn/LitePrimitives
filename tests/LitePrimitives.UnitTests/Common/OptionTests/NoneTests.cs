namespace LitePrimitives.UnitTests.Common.OptionTests;

public class NoneTests
{
    [Fact]
    public void Returns_Option()
    {
        Option<bool>.None().ShouldReturnNothingOnMatch();
    }
}