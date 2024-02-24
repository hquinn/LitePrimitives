using FluentAssertions;

namespace LitePrimitives.TestHelpers.XUnit;

public static class ResultAssertHelper
{
    public static void ShouldReturnErrorOnMatch<TResponse>(this Result<TResponse> sut, IError expected)
    {
        sut.ShouldReturnArrayOfErrorOnMatch(new[] { expected, });
    }

    public static void ShouldReturnArrayOfErrorOnMatch<TResponse>(this Result<TResponse> sut, IEnumerable<IError> expected)
    {
        IError[] actual = sut.Match(
            success: _ => throw new Exception("Should not be called"), 
            failure: errors => errors);

        actual.Should().BeEquivalentTo(expected);
    }

    public static async Task ShouldReturnErrorOnMatchAsync<TResponse>(this Result<TResponse> sut, IError expected)
    {
        await sut.ShouldReturnArrayOfErrorOnMatchAsync(new[] { expected, });
    }

    public static async Task ShouldReturnArrayOfErrorOnMatchAsync<TResponse>(this Result<TResponse> sut, IEnumerable<IError> expected)
    {
        IError[] actual = await sut.MatchAsync(
            success: _ => throw new Exception("Should not be called"), 
            failure: Task.FromResult);

        actual.Should().BeEquivalentTo(expected);
    }
    
    public static void ShouldReturnResponseOnMatch<TResponse>(this Result<TResponse> sut, TResponse expected)
    {
        var actual = sut.Match(
            success: response => response, 
            failure: _ => throw new Exception("Should not be called"));

        actual.Should().BeEquivalentTo(expected);
    }

    public static async Task ShouldReturnResponseOnMatchAsync<TResponse>(this Result<TResponse> sut, TResponse expected)
    {
        var actual = await sut.MatchAsync(
            success: Task.FromResult, 
            failure: _ => throw new Exception("Should not be called"));

        actual.Should().BeEquivalentTo(expected);
    }
}