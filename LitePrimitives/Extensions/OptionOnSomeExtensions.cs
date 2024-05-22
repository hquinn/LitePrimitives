// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for OnSome on the Option type.
/// </summary>
public static class OptionOnSomeExtensions
{
    
    /// <summary>
    ///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Some state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform the action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TValue">
    ///     The type of the <paramref name="input"/> parameter and the return type for <see cref="Option{TValue}"/>.
    /// </typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Option<TValue>> OnSomeAsync<TValue>(
        this Task<Option<TValue>> input,
        Func<TValue, Task> action) 
    {
        var option = await input;
        
        return await option.MatchAsync(
            some: async value =>
            {
                await action(value);
                return option;
            },
            none: () => input);
    }
    
    /// <summary>
    ///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Some state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform the action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TValue">
    ///     The type of the <paramref name="input"/> parameter and the return type for <see cref="Option{TValue}"/>.
    /// </typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Option<TValue>> OnSomeAsync<TValue>(
        this Task<Option<TValue>> input,
        Func<TValue, Task<Unit>> action) 
    {
        var option = await input;
        
        return await option.MatchAsync(
            some: async value =>
            {
                await action(value);
                return option;
            },
            none: () => input);
    }
}