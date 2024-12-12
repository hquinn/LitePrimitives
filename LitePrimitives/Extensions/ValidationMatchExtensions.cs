// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for Match on the Validation type.
/// </summary>
public static class ValidationMatchExtensions
{
    /// <summary>
    ///     Outputs the following:
    ///     - <paramref name="success"/> if in the Success state.
    ///     - <paramref name="failure"/> if in the Failure state.
    ///     The output is of type <see cref="Task"/> of <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to match.</param>
    /// <param name="success">The asynchronous func to use if <see cref="Validation{TValue}"/> is in the Success state.</param>
    /// <param name="failure">The asynchronous func to use if <see cref="Validation{TValue}"/> is in the Failure state.</param>
    /// <typeparam name="TValue">The type of the Success state.</typeparam>
    /// <typeparam name="TOutput">The output of the match.</typeparam>
    /// <returns>The output of the match.</returns>
    public static async Task<TOutput> MatchAsync<TValue, TOutput>(
        this Task<Validation<TValue>> input,
        Func<TValue, Task<TOutput>> success,
        Func<Error[], Task<TOutput>> failure)
    {
        var validation = await input;
        
        return await validation.MatchAsync(
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
    /// <param name="success">The func to use if <see cref="Validation{TValue}"/> is in the Success state.</param>
    /// <param name="failure">The func to use if <see cref="Validation{TValue}"/> is in the Failure state.</param>
    /// <typeparam name="TValue">The type of the Success state.</typeparam>
    /// <typeparam name="TOutput">The output of the match.</typeparam>
    /// <returns>The output of the match.</returns>
    public static async Task<TOutput> MatchAsync<TValue, TOutput>(
        this Task<Validation<TValue>> input,
        Func<TValue, TOutput> success,
        Func<Error[], TOutput> failure)
    {
        var validation = await input;
        
        return validation.Match(
            success,
            failure);
    }
}