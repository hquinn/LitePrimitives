// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for Map on the Validation type.
/// </summary>
public static class ValidationMapExtensions
{
    /// <summary>
    ///      Performs transformation into <see cref="Validation{TOutput}"/> when it's in the Success state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Validation{TOutput}"/> in the Failure state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutput"/>.</param>
    /// <typeparam name="TInput">The type of the Success <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutput">The type of the transformed Success output.</typeparam>
    /// <returns>
    ///      The validation of <paramref name="transform"/> if in the Success state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Validation{TOutput}"/> in the Failure state.
    /// </returns>
    public static async Task<Validation<TOutput>> MapAsync<TInput, TOutput>(
        this Task<Validation<TInput>> input,
        Func<TInput, Task<TOutput>> transform)
    {
        var either = await input;

        return await either.MapAsync(transform);
    }
    
    /// <summary>
    ///      Performs transformation into <see cref="Validation{TOutput}"/> when it's in the Success state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Validation{TOutput}"/> in the Failure state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutput"/>.</param>
    /// <typeparam name="TInput">The type of the Success <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutput">The type of the transformed Success output.</typeparam>
    /// <returns>
    ///      The validation of <paramref name="transform"/> if in the Success state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Validation{TOutput}"/> in the Failure state.
    /// </returns>
    public static async Task<Validation<TOutput>> MapAsync<TInput, TOutput>(
        this Task<Validation<TInput>> input,
        Func<TInput, TOutput> transform)
    {
        var either = await input;

        return either.Map(transform);
    }
}