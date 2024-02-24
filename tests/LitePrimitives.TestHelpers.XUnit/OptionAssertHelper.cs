using FluentAssertions;

namespace LitePrimitives.TestHelpers.XUnit;

public static class OptionAssertHelper
{
    public static void ShouldReturnValueOnMatch<TValue>(this Option<TValue> sut, TValue expected)
    {
        var actual = sut.Match(
            some: value => value,
            none: () => throw new Exception("Should not be called"));

        actual.Should().BeEquivalentTo(expected);
    }

    public static async Task ShouldReturnValueOnMatchAsync<TValue>(this Option<TValue> sut, TValue expected)
    {
        var actual = await sut.MatchAsync(
            some: Task.FromResult, 
            none: () => throw new Exception("Should not be called"));

        actual.Should().BeEquivalentTo(expected);
    }

    public static void ShouldReturnNothingOnMatch<TValue>(this Option<TValue> sut)
    {
        var actual = sut.Match<TValue?>(
            some: _ => throw new Exception("Should not be called"),
            none: () => default);

        actual.Should().BeEquivalentTo(default(TValue?));
    }

    public static async Task ShouldReturnNothingOnMatchAsync<TValue>(this Option<TValue> sut)
    {
        var actual = await sut.MatchAsync(
            some: _ => throw new Exception("Should not be called"), 
            none: () => Task.FromResult(default(TValue?)));

        actual.Should().BeEquivalentTo(default(TValue?));
    }
}