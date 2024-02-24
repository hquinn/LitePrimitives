namespace LitePrimitives.UnitTests.Extensions.ResultExtensionsTests;

public class MapTests
{
    [Fact]
    public void Returns_Mapped_Response_When_Result_Parameter_Is_A_Response()
    {
        const bool expected = ResultConstants.FirstResponse;
        var sut = Result<int>.Success(ResultConstants.SecondResponse);

        var actual = sut.Map(_ => ResultConstants.FirstResponse);

        actual.ShouldReturnResponseOnMatch(expected);
    }

    [Fact]
    public void Returns_Error_When_Result_Parameter_Is_An_Error()
    {
        var expected = ErrorFactory.CreateError();
        var sut = Result<int>.Failure(expected);

        var actual = sut.Map(_ => ResultConstants.FirstResponse);

        actual.ShouldReturnErrorOnMatch(expected);
    }
}