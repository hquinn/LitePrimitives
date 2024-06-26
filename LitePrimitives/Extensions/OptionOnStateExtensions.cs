// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for OnNone on the Option type.
/// </summary>
public static class OptionOnStateExtensions
{
    /// <summary>
    ///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the None state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform the <paramref name="action"/> on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TValue">
    ///     The type of the <paramref name="input"/> parameter and the return type for <see cref="Option{TValue}"/>.
    /// </typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Option<TValue>> OnNoneAsync<TValue>(this Task<Option<TValue>> input, Func<Task> action)
    {
        var option = await input;
        await option.OnNoneAsync(action);
        return option;
    }
    
    /// <summary>
    ///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the None state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform the <paramref name="action"/> on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TValue">
    ///     The type of the <paramref name="input"/> parameter and the return type for <see cref="Option{TValue}"/>.
    /// </typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Option<TValue>> OnNoneAsync<TValue>(
        this Task<Option<TValue>> input,
        Func<Task<Unit>> action) 
    {
        var option = await input;
        await option.OnNoneAsync(action);
        return option;
    }

    /// <summary>
    ///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the None state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform the <paramref name="action"/> on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TValue">
    ///     The type of the <paramref name="input"/> parameter and the return type for <see cref="Option{TValue}"/>.
    /// </typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Option<TValue>> OnNoneAsync<TValue>(this Task<Option<TValue>> input, Action action)
    {
        var option = await input;
        option.OnNone(action);
        return option;
    }
    
    /// <summary>
    ///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the None state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform the <paramref name="action"/> on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TValue">
    ///     The type of the <paramref name="input"/> parameter and the return type for <see cref="Option{TValue}"/>.
    /// </typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Option<TValue>> OnNoneAsync<TValue>(
        this Task<Option<TValue>> input,
        Func<Unit> action) 
    {
        var option = await input;
        option.OnNone(action);
        return option;
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
        Func<TValue, Task> action) 
    {
        var option = await input;
        await option.OnSomeAsync(action);
        return option;
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
        await option.OnSomeAsync(action);
        return option;
    }
    
    /// <summary>
    ///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Some state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform the action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TValue">
    ///     The type of the <paramref name="input"/> parameter and the return type for <see cref="Option{TValue}"/>.
    /// </typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Option<TValue>> OnSomeAsync<TValue>(
        this Task<Option<TValue>> input,
        Action<TValue> action) 
    {
        var option = await input;
        option.OnSome(action);
        return option;
    }
    
    /// <summary>
    ///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Some state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform the action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TValue">
    ///     The type of the <paramref name="input"/> parameter and the return type for <see cref="Option{TValue}"/>.
    /// </typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Option<TValue>> OnSomeAsync<TValue>(
        this Task<Option<TValue>> input,
        Func<TValue, Unit> action) 
    {
        var option = await input;
        option.OnSome(action);
        return option;
    }
}