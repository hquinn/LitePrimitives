namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for OnNone on the Option type.
/// </summary>
public static class Option_OnNoneExtensions
{
    /// <summary>
    ///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the None state.
    /// </summary>
    /// <param name="input">The input to perform the <paramref name="action"/> on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TValue">
    ///     The type of the <paramref name="input"/> parameter and the return type for <see cref="Option{TValue}"/>.
    /// </typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static Option<TValue> OnNone<TValue>(this Option<TValue> input, Action action)
    {
        return input.Match(
            some: _ => input,
            none: () =>
            {
                action();
                return input;
            });
    }

    /// <summary>
    ///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the None state.
    /// </summary>
    /// <param name="input">The input to perform the <paramref name="action"/> on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TValue">
    ///     The type of the <paramref name="input"/> parameter and the return type for <see cref="Option{TValue}"/>.
    /// </typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static Option<TValue> OnNone<TValue>(this Option<TValue> input, Func<Unit> action)
    {
        return input.Match(
            some: _ => input,
            none: () =>
            {
                action();
                return input;
            });
    }

    /// <summary>
    ///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the None state.
    /// </summary>
    /// <param name="input">The input to perform the <paramref name="action"/> on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TValue">
    ///     The type of the <paramref name="input"/> parameter and the return type for <see cref="Option{TValue}"/>.
    /// </typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Option<TValue>> OnNoneAsync<TValue>(this Option<TValue> input, Func<Task> action)
    {
        return await input.MatchAsync(
            some: _ => input.ToTask(),
            none: async () =>
            {
                await action();
                return input;
            });
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
    public static async Task<Option<TValue>> OnNoneAsync<TValue>(this Task<Option<TValue>> input, Func<Task> action)
    {
        var option = await input;
        
        return await option.MatchAsync(
            some: _ => input,
            none: async () =>
            {
                await action();
                return option;
            });
    }

    /// <summary>
    ///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the None state.
    /// </summary>
    /// <param name="input">The input to perform the <paramref name="action"/> on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TValue">
    ///     The type of the <paramref name="input"/> parameter and the return type for <see cref="Option{TValue}"/>.
    /// </typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Option<TValue>> OnNoneAsync<TValue>(
        this Option<TValue> input,
        Func<Task<Unit>> action)
    {
        return await input.MatchAsync(
            some: _ => input.ToTask(),
            none: async () =>
            {
                await action();
                return input;
            });
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
        
        return await option.MatchAsync(
            some: _ => input,
            none: async () =>
            {
                await action();
                return option;
            });
    }
}