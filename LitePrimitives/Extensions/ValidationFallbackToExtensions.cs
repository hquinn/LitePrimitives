// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for FallbackTo on the Validation type.
/// </summary>
public static class ValidationFallbackToExtensions
{
    /// <summary>
    ///      Returns the <paramref name="fallback"/> if in the Failure state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform fallbacking on.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>Returns the <paramref name="fallback"/> if in the Failure state.</returns>
    public static async Task<Validation<TValue>> FallbackToAsync<TValue>(
        this Task<Validation<TValue>> input,
        Validation<TValue> fallback)
    {
        var validation = await input;
        
        return validation.FallbackTo(fallback);
    }
    
    /// <summary>
    ///      Returns the <paramref name="fallback"/> if in the Failure state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform fallbacking on.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>Returns the <paramref name="fallback"/> if in the Failure state.</returns>
    public static async Task<Validation<TValue>> FallbackToAsync<TValue>(
        this Task<Validation<TValue>> input,
        Task<Validation<TValue>> fallback)
    {
        var validation = await input;
        
        return await validation.FallbackToAsync(fallback);
    }
    
    /// <summary>
    ///      Returns the <paramref name="fallback"/> if in the Failure state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform fallbacking on.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>Returns the <paramref name="fallback"/> if in the Failure state.</returns>
    public static async Task<Validation<TValue>> FallbackToAsync<TValue>(
        this Task<Validation<TValue>> input,
        Func<Validation<TValue>> fallback)
    {
        var validation = await input;
        
        return validation.FallbackTo(fallback);
    }
    
    /// <summary>
    ///      Returns the <paramref name="fallback"/> if in the Failure state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform fallbacking on.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>Returns the <paramref name="fallback"/> if in the Failure state.</returns>
    public static async Task<Validation<TValue>> FallbackToAsync<TValue>(
        this Task<Validation<TValue>> input,
        Func<Task<Validation<TValue>>> fallback)
    {
        var validation = await input;
        
        return await validation.FallbackToAsync(fallback);
    }
}