// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for Match on the Option type.
/// </summary>
public static class OptionMatchExtensions
{
    /// <summary>
    ///     Outputs the following:
    ///     - <paramref name="some"/> if in the Some state.
    ///     - <paramref name="none"/> if in the None state.
    ///     The output is of type <see cref="Task"/> of <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to match.</param>
    /// <param name="some">The asynchronous func to use if <see cref="Option{TValue}"/> is in the Some state.</param>
    /// <param name="none">The asynchronous func to use if <see cref="Option{TValue}"/> is in the None state.</param>
    /// <typeparam name="TValue">The type of the Some state.</typeparam>
    /// <typeparam name="TOutput">The output of the match.</typeparam>
    /// <returns>The output of the match.</returns>
    public static async Task<TOutput> MatchAsync<TValue, TOutput>(
        this Task<Option<TValue>> input,
        Func<TValue, Task<TOutput>> some,
        Func<Task<TOutput>> none)
    {
        var option = await input;
        
        return await option.MatchAsync(
            some,
            none);
    }

    /// <summary>
    ///     Outputs the following:
    ///     - <paramref name="some"/> if in the Some state.
    ///     - <paramref name="none"/> if in the None state.
    ///     The output is of type <see cref="Task"/> of <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to match.</param>
    /// <param name="some">The func to use if <see cref="Option{TValue}"/> is in the Some state.</param>
    /// <param name="none">The func to use if <see cref="Option{TValue}"/> is in the None state.</param>
    /// <typeparam name="TValue">The type of the Some state.</typeparam>
    /// <typeparam name="TOutput">The output of the match.</typeparam>
    /// <returns>The output of the match.</returns>
    public static async Task<TOutput> MatchAsync<TValue, TOutput>(
        this Task<Option<TValue>> input,
        Func<TValue, TOutput> some,
        Func<TOutput> none)
    {
        var option = await input;
        
        return option.Match(
            some,
            none);
    }
}