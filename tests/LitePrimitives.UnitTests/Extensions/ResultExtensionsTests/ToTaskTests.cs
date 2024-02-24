namespace LitePrimitives.UnitTests.Extensions.ResultExtensionsTests;

public class ToTaskTests
{
    [Fact]
    public async Task Returns_Task_Of_Result()
    {
        const bool expected = ResultConstants.ExpectedResponse;

        var sut = Result<bool>.Success(expected).ToTask();
        var actual = await sut;
        
        await actual.ShouldReturnResponseOnMatchAsync(expected);
    }
}