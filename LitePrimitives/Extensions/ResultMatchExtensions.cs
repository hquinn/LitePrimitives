// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for Match on the Result type.
/// </summary>
public static class ResultMatchExtensions
{
    /// <summary>
    ///     Outputs the following:
    ///     - <paramref name="success"/> if in the Success state.
    ///     - <paramref name="failure"/> if in the Failure state.
    ///     The output is of type <see cref="Task"/> of <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to match.</param>
    /// <param name="success">The asynchronous func to use if <see cref="Result{TValue}"/> is in the Success state.</param>
    /// <param name="failure">The asynchronous func to use if <see cref="Result{TValue}"/> is in the Failure state.</param>
    /// <typeparam name="TValue">The type of the Success state.</typeparam>
    /// <typeparam name="TOutput">The output of the match.</typeparam>
    /// <returns>The output of the match.</returns>
    public static async Task<TOutput> MatchAsync<TValue, TOutput>(
        this Task<Result<TValue>> input,
        Func<TValue, Task<TOutput>> success,
        Func<Error, Task<TOutput>> failure)
    {
        var result = await input;
        
        return await result.MatchAsync(
            success,
            failure);
    }

    /// <summary>
    ///     Outputs the following:
    ///     - <paramref name="success"/> if in the Success state.
    ///     - <paramref name="failure"/> if in the Failure state.
    ///     The output is of type <see cref="Task"/> of <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to match.</param>
    /// <param name="success">The func to use if <see cref="Result{TValue}"/> is in the Success state.</param>
    /// <param name="failure">The func to use if <see cref="Result{TValue}"/> is in the Failure state.</param>
    /// <typeparam name="TValue">The type of the Success state.</typeparam>
    /// <typeparam name="TOutput">The output of the match.</typeparam>
    /// <returns>The output of the match.</returns>
    public static async Task<TOutput> MatchAsync<TValue, TOutput>(
        this Task<Result<TValue>> input,
        Func<TValue, TOutput> success,
        Func<Error, TOutput> failure)
    {
        var result = await input;
        
        return result.Match(
            success,
            failure);
    }
}