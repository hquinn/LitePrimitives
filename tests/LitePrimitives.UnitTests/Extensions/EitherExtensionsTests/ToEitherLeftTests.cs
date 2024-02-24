namespace LitePrimitives.UnitTests.Extensions.EitherExtensionsTests;

public class ToEitherLeftTests
{
    [Fact]
    public void Returns_Either_From_Left_Value_In_Left_State()
    {
        const bool expected = EitherConstants.ExpectedLeftValue;
        
        expected.ToEitherLeft<bool, int>().ShouldReturnLeftValueOnMatch(expected);
    }
}