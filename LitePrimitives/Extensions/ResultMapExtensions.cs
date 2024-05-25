// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for Map on the Result type.
/// </summary>
public static class ResultMapExtensions
{    
    /// <summary>
    ///      Performs transformation into <see cref="Result{TOutput}"/> when it's in the Success state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Result{TOutput}"/> in the Failure state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutput"/>.</param>
    /// <typeparam name="TInput">The type of the Success <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutput">The type of the transformed Success output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Success state,
    ///      otherwise returns <see cref="Result{TOutput}"/> in the Failure state.
    /// </returns>
    public static async Task<Result<TOutput>> MapAsync<TInput, TOutput>(
        this Task<Result<TInput>> input,
        Func<TInput, Task<TOutput>> transform)
    {
        var either = await input;

        return await either.MapAsync(transform);
    }
}