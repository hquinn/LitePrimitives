// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for Map on the Option type.
/// </summary>
public static class OptionMapExtensions
{
    /// <summary>
    ///     Transforms the <paramref name="input"/> when it's in a Some state into <see cref="Option{TOutput}"/>,
    ///     otherwise returns <see cref="Task"/> of type <see cref="Option{TOutput}"/> in the None state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The asynchronous function to transform the <paramref name="input"/> to <typeparamref name="TOutput"/>.</param>
    /// <typeparam name="TInput">The type of the <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutput">The type of the transformed response.</typeparam>
    /// <returns>
    ///	    The result of <paramref name="transform"/> if <paramref name="input"/> is in the Some state,
    ///		otherwise returns <see cref="Task"/> of type <see cref="Option{TOutput}"/> in the None state.
    /// </returns>
    public static async Task<Option<TOutput>> MapAsync<TInput, TOutput>(
        this Task<Option<TInput>> input,
        Func<TInput, Task<TOutput>> transform)
    {
        var option = await input;
        
        return await option.MapAsync(transform);
    }
}