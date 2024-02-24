namespace LitePrimitives.UnitTests.Common.ResultTests;

public class SuccessTests
{
    [Fact]
    public void Returns_Result_From_Response()
    {
        const bool expected = ResultConstants.ExpectedResponse;

        Result<bool>.Success(expected).ShouldReturnResponseOnMatch(expected);
    }
}