// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for Perform on the Option type.
/// </summary>
public static class OptionPerformExtensions
{    
    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="some">The action to perform if in the Some state.</param>
    /// <param name="none">The action to perform if in the None state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Option<TValue>> PerformAsync<TValue>(
        this Task<Option<TValue>> input,
        Action<TValue>? some = null,
        Action? none = null)
    {
        var option = await input;
        
        return option.Perform(
            some,
            none);
    }
    
    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="some">The action to perform if in the Some state.</param>
    /// <param name="none">The action to perform if in the None state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Option<TValue>> PerformAsync<TValue>(
        this Task<Option<TValue>> input,
        Func<TValue, Unit>? some = null,
        Func<Unit>? none = null)
    {
        var option = await input;
        
        return option.Perform(
            some,
            none);
    }

    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="some">The asynchronous action to perform if in the Some state.</param>
    /// <param name="none">The asynchronous action to perform if in the None state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Option<TValue>> PerformAsync<TValue>(
        this Task<Option<TValue>> input,
        Func<TValue, Task>? some = null,
        Func<Task>? none = null)
    {
        var option = await input;
        
        return await option.PerformAsync(
            some,
            none);
    }

    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="some">The action to perform if in the Some state.</param>
    /// <param name="none">The asynchronous action to perform if in the None state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Option<TValue>> PerformAsync<TValue>(
        this Task<Option<TValue>> input,
        Action<TValue>? some = null,
        Func<Task>? none = null)
    {
        var option = await input;
        
        return await option.PerformAsync(
            some,
            none);
    }

    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="some">The asynchronous action to perform if in the Some state.</param>
    /// <param name="none">The action to perform if in the None state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Option<TValue>> PerformAsync<TValue>(
        this Task<Option<TValue>> input,
        Func<TValue, Task>? some = null,
        Action? none = null)
    {
        var option = await input;
        
        return await option.PerformAsync(
            some,
            none);
    }

    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="some">The asynchronous action to perform if in the Some state.</param>
    /// <param name="none">The asynchronous action to perform if in the None state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Option<TValue>> PerformAsync<TValue>(
        this Task<Option<TValue>> input,
        Func<TValue, Task<Unit>>? some = null,
        Func<Task<Unit>>? none = null)
    {
        var option = await input;
        
        return await option.PerformAsync(
            some,
            none);
    }

    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="some">The action to perform if in the Some state.</param>
    /// <param name="none">The asynchronous action to perform if in the None state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Option<TValue>> PerformAsync<TValue>(
        this Task<Option<TValue>> input,
        Func<TValue, Unit>? some = null,
        Func<Task<Unit>>? none = null)
    {
        var option = await input;
        
        return await option.PerformAsync(
            some,
            none);
    }

    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="some">The asynchronous action to perform if in the Some state.</param>
    /// <param name="none">The action to perform if in the None state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Option<TValue>> PerformAsync<TValue>(
        this Task<Option<TValue>> input,
        Func<TValue, Task<Unit>>? some = null,
        Func<Unit>? none = null)
    {
        var option = await input;
        
        return await option.PerformAsync(
            some,
            none);
    }
}