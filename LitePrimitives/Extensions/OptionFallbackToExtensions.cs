// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for FallbackTo on the Option type.
/// </summary>
public static class OptionFallbackToExtensions
{
    /// <summary>
    ///      Returns the <paramref name="fallback"/> if in the None state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform fallbacking on.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>Returns the <paramref name="fallback"/> if in the None state.</returns>
    public static async Task<Option<TValue>> FallbackToAsync<TValue>(
        this Task<Option<TValue>> input,
        Option<TValue> fallback)
    {
        var option = await input;
        
        return option.FallbackTo(fallback);
    }
    
    /// <summary>
    ///      Returns the <paramref name="fallback"/> if in the None state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform fallbacking on.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>Returns the <paramref name="fallback"/> if in the None state.</returns>
    public static async Task<Option<TValue>> FallbackToAsync<TValue>(
        this Task<Option<TValue>> input,
        Task<Option<TValue>> fallback)
    {
        var option = await input;
        
        return await option.FallbackToAsync(fallback);
    }
    
    /// <summary>
    ///      Returns the <paramref name="fallback"/> if in the None state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform fallbacking on.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>Returns the <paramref name="fallback"/> if in the None state.</returns>
    public static async Task<Option<TValue>> FallbackToAsync<TValue>(
        this Task<Option<TValue>> input,
        Func<Option<TValue>> fallback)
    {
        var option = await input;
        
        return option.FallbackTo(fallback);
    }
    
    /// <summary>
    ///      Returns the <paramref name="fallback"/> if in the None state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform fallbacking on.</param>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>Returns the <paramref name="fallback"/> if in the None state.</returns>
    public static async Task<Option<TValue>> FallbackToAsync<TValue>(
        this Task<Option<TValue>> input,
        Func<Task<Option<TValue>>> fallback)
    {
        var option = await input;
        
        return await option.FallbackToAsync(fallback);
    }
}