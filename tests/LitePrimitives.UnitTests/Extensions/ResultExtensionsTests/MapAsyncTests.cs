namespace LitePrimitives.UnitTests.Extensions.ResultExtensionsTests;

public class MapAsyncTests
{
    [Fact]
    public async Task Returns_Mapped_Response_When_Result_Parameter_Is_In_The_Success_State()
    {
        const bool expected = ResultConstants.FirstResponse;
        var sut = Result<int>.Success(ResultConstants.SecondResponse);

        var actual = await sut.MapAsync(_ => Task.FromResult(ResultConstants.FirstResponse));

        await actual.ShouldReturnResponseOnMatchAsync(expected);
    }
    
    [Fact]
    public async Task Returns_Mapped_Response_When_Result_Task_Parameter_Is_In_The_Success_State()
    {
        const bool expected = ResultConstants.FirstResponse;
        var sut = Result<int>.Success(ResultConstants.SecondResponse).ToTask();

        var actual = await sut.MapAsync(_ => Task.FromResult(ResultConstants.FirstResponse));

        await actual.ShouldReturnResponseOnMatchAsync(expected);
    }

    [Fact]
    public async Task Returns_Error_When_Result_Parameter_Is_In_The_Failure_State()
    {
        var expected = ErrorFactory.CreateError();
        var sut = Result<int>.Failure(expected);

        var actual = await sut.MapAsync(_ => Task.FromResult(ResultConstants.FirstResponse));

        await actual.ShouldReturnErrorOnMatchAsync(expected);
    }

    [Fact]
    public async Task Returns_Error_When_Result_Task_Parameter_Is_In_The_Failure_State()
    {
        var expected = ErrorFactory.CreateError();
        var sut = Result<int>.Failure(expected).ToTask();

        var actual = await sut.MapAsync(_ => Task.FromResult(ResultConstants.FirstResponse));

        await actual.ShouldReturnErrorOnMatchAsync(expected);
    }
}