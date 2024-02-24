namespace LitePrimitives.UnitTests.Extensions.EitherExtensionsTests;

public class ToEitherRightTests
{
    [Fact]
    public void Returns_Either_From_Right_Value_In_Right_State()
    {
        const int expected = EitherConstants.ExpectedRightValue;
        
        expected.ToEitherRight<bool, int>().ShouldReturnRightValueOnMatch(expected);
    }
}