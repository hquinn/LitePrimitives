namespace LitePrimitives.UnitTests.Common.ResultTests;

public class MatchAsyncTests
{
    private readonly IFixture _fixture = FixtureFactory.CreateFixture();

    [Fact]
    public async Task Returns_Error_When_Result_Is_Created_By_A_Single_Error()
    {
        var expected = _fixture.Create<IError>();

        var actual = Result<bool>.Failure(expected);
        await actual.ShouldReturnErrorOnMatchAsync(expected);
    }

    [Fact]
    public async Task Returns_Multiple_Errors_When_Result_Is_Created_By_An_Array_Of_Errors()
    {
        var expected = _fixture.CreateMany<IError>().ToArray();

        var actual = Result<bool>.Failure(expected);
        await actual.ShouldReturnArrayOfErrorOnMatchAsync(expected);
    }

    [Fact]
    public async Task Returns_Multiple_Errors_When_Result_Is_Created_By_A_List_Of_Errors()
    {
        var expected = _fixture.CreateMany<IError>().ToList();

        var actual = Result<bool>.Failure(expected);
        await actual.ShouldReturnArrayOfErrorOnMatchAsync(expected);
    }

    [Fact]
    public async Task Returns_Response_When_Result_Is_Created_By_A_Response()
    {
        const bool expected = ResultConstants.ExpectedResponse;

        var actual = Result<bool>.Success(expected);
        await actual.ShouldReturnResponseOnMatchAsync(expected);
    }
}