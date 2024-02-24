namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for OnLeft on the Either type.
/// </summary>
public static class Either_OnLeftExtensions
{
    /// <summary>
    ///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Left state.
    /// </summary>
    /// <param name="input">The input to perform the <paramref name="action"/> on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TLeft">The type of the Left <paramref name="input"/>.</typeparam>
    /// <typeparam name="TRight">The type of the Right <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static Either<TLeft, TRight> OnLeft<TLeft, TRight>(
        this Either<TLeft, TRight> input,
        Action<TLeft> action)
    {
        return input.Match(
            left: l =>
            {
                action(l);
                return input;
            },
            right: _ => input);
    }

    /// <summary>
    ///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Left state.
    /// </summary>
    /// <param name="input">The input to perform the <paramref name="action"/> on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TLeft">The type of the Left <paramref name="input"/>.</typeparam>
    /// <typeparam name="TRight">The type of the Right <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static Either<TLeft, TRight> OnLeft<TLeft, TRight>(
        this Either<TLeft, TRight> input,
        Func<TLeft, Unit> action)
    {
        return input.Match(
            left: l =>
            {
                action(l);
                return input;
            },
            right: _ => input);
    }

    /// <summary>
    ///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Left state.
    /// </summary>
    /// <param name="input">The input to perform the <paramref name="action"/> on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TLeft">The type of the Left <paramref name="input"/>.</typeparam>
    /// <typeparam name="TRight">The type of the Right <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TLeft, TRight>> OnLeftAsync<TLeft, TRight>(
        this Either<TLeft, TRight> input,
        Func<TLeft, Task> action)
    {
        return await input.MatchAsync(
            left: async l =>
            {
                await action(l);
                return input;
            },
            right: _ => input.ToTask());
    }

    /// <summary>
    ///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Left state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform the <paramref name="action"/> on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TLeft">The type of the Left <paramref name="input"/>.</typeparam>
    /// <typeparam name="TRight">The type of the Right <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TLeft, TRight>> OnLeftAsync<TLeft, TRight>(
        this Task<Either<TLeft, TRight>> input,
        Func<TLeft, Task> action)
    {
        var either = await input;
      
        return await either.MatchAsync(
            left: async l =>
            {
                await action(l);
                return either;
            },
            right: _ => input);
    }

    /// <summary>
    ///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Left state.
    /// </summary>
    /// <param name="input">The input to perform the <paramref name="action"/> on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TLeft">The type of the Left <paramref name="input"/>.</typeparam>
    /// <typeparam name="TRight">The type of the Right <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TLeft, TRight>> OnLeftAsync<TLeft, TRight>(
        this Either<TLeft, TRight> input,
        Func<TLeft, Task<Unit>> action)
    {
        return await input.MatchAsync(
            left: async l =>
            {
                await action(l);
                return input;
            },
            right: _ => input.ToTask());
    }

    /// <summary>
    ///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Left state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform the <paramref name="action"/> on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TLeft">The type of the Left <paramref name="input"/>.</typeparam>
    /// <typeparam name="TRight">The type of the Right <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TLeft, TRight>> OnLeftAsync<TLeft, TRight>(
        this Task<Either<TLeft, TRight>> input,
        Func<TLeft, Task<Unit>> action)
    {
        var either = await input;
      
        return await either.MatchAsync(
            left: async l =>
            {
                await action(l);
                return either;
            },
            right: _ => input);
    }
}