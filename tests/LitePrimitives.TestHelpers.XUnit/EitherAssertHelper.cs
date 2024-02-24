using FluentAssertions;

namespace LitePrimitives.TestHelpers.XUnit;

public static class EitherAssertHelper
{
    public static void ShouldReturnLeftValueOnMatch<TLeft, TRight>(this Either<TLeft, TRight> sut, TLeft expected)
    {
        var actual = sut.Match(
            left: value => value,
            right: _ => throw new Exception("Should not be called"));

        actual.Should().BeEquivalentTo(expected);
    }
    
    public static async Task ShouldReturnLeftValueOnMatchAsync<TLeft, TRight>(this Either<TLeft, TRight> sut, TLeft expected)
    {
        var actual = await sut.MatchAsync(
            left: Task.FromResult,
            right: _ => throw new Exception("Should not be called"));

        actual.Should().BeEquivalentTo(expected);
    }
    
    public static void ShouldReturnRightValueOnMatch<TLeft, TRight>(this Either<TLeft, TRight> sut, TRight expected)
    {
        var actual = sut.Match(
            left: _ => throw new Exception("Should not be called"),
            right: value => value);

        actual.Should().BeEquivalentTo(expected);
    }
    
    public static async Task ShouldReturnRightValueOnMatchAsync<TLeft, TRight>(this Either<TLeft, TRight> sut, TRight expected)
    {
        var actual = await sut.MatchAsync(
            left: _ => throw new Exception("Should not be called"),
            right: Task.FromResult);

        actual.Should().BeEquivalentTo(expected);
    }
}