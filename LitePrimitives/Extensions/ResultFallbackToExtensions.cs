// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for FallbackTo on the Result type.
/// </summary>
public static class ResultFallbackToExtensions
{
    /// <summary>
    ///      Returns the <paramref name="fallback"/> if in the Failure state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform fallbacking on.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>Returns the <paramref name="fallback"/> if in the Failure state.</returns>
    public static async Task<Result<TValue>> FallbackToAsync<TValue>(
        this Task<Result<TValue>> input,
        Result<TValue> fallback)
    {
        var result = await input;
        
        return result.FallbackTo(fallback);
    }
    
    /// <summary>
    ///      Returns the <paramref name="fallback"/> if in the Failure state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform fallbacking on.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>Returns the <paramref name="fallback"/> if in the Failure state.</returns>
    public static async Task<Result<TValue>> FallbackToAsync<TValue>(
        this Task<Result<TValue>> input,
        Task<Result<TValue>> fallback)
    {
        var result = await input;
        
        return await result.FallbackToAsync(fallback);
    }
    
    /// <summary>
    ///      Returns the <paramref name="fallback"/> if in the Failure state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform fallbacking on.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>Returns the <paramref name="fallback"/> if in the Failure state.</returns>
    public static async Task<Result<TValue>> FallbackToAsync<TValue>(
        this Task<Result<TValue>> input,
        Func<Result<TValue>> fallback)
    {
        var result = await input;
        
        return result.FallbackTo(fallback);
    }
    
    /// <summary>
    ///      Returns the <paramref name="fallback"/> if in the Failure state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform fallbacking on.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>Returns the <paramref name="fallback"/> if in the Failure state.</returns>
    public static async Task<Result<TValue>> FallbackToAsync<TValue>(
        this Task<Result<TValue>> input,
        Func<Task<Result<TValue>>> fallback)
    {
        var result = await input;
        
        return await result.FallbackToAsync(fallback);
    }
}