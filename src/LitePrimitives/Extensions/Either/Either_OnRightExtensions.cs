namespace LitePrimitives;

public static class Either_OnRightExtensions
{
    /// <summary>
    ///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Right state.
    /// </summary>
    /// <param name="input">The input to perform the <paramref name="action"/> on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TLeft">The type of the Left <paramref name="input"/>.</typeparam>
    /// <typeparam name="TRight">The type of the Right <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static Either<TLeft, TRight> OnRight<TLeft, TRight>(
        this Either<TLeft, TRight> input,
        Action<TRight> action)
    {
        return input.Match(
            left: _ => input,
            right: response =>
            {
                action(response);
                return input;
            });
    }

    /// <summary>
    ///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Right state.
    /// </summary>
    /// <param name="input">The input to perform the <paramref name="action"/> on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TLeft">The type of the Left <paramref name="input"/>.</typeparam>
    /// <typeparam name="TRight">The type of the Right <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static Either<TLeft, TRight> OnRight<TLeft, TRight>(
        this Either<TLeft, TRight> input,
        Func<TRight, Unit> action)
    {
        return input.Match(
            left: _ => input,
            right: response =>
            {
                action(response);
                return input;
            });
    }

    /// <summary>
    ///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Right state.
    /// </summary>
    /// <param name="input">The input to perform the <paramref name="action"/> on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TLeft">The type of the Left <paramref name="input"/>.</typeparam>
    /// <typeparam name="TRight">The type of the Right <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TLeft, TRight>> OnRightAsync<TLeft, TRight>(
        this Either<TLeft, TRight> input,
        Func<TRight, Task> action)
    {
        return await input.MatchAsync(
            left: _ => input.ToTask(),
            right: async response =>
            {
                await action(response);
                return input;
            });
    }

    /// <summary>
    ///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Right state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform the <paramref name="action"/> on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TLeft">The type of the Left <paramref name="input"/>.</typeparam>
    /// <typeparam name="TRight">The type of the Right <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TLeft, TRight>> OnRightAsync<TLeft, TRight>(
        this Task<Either<TLeft, TRight>> input,
        Func<TRight, Task> action)
    {
        var either = await input;
      
        return await either.MatchAsync(
            left: _ => input,
            right: async response =>
            {
                await action(response);
                return either;
            });
    }

    /// <summary>
    ///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Right state.
    /// </summary>
    /// <param name="input">The input to perform the <paramref name="action"/> on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TLeft">The type of the Left <paramref name="input"/>.</typeparam>
    /// <typeparam name="TRight">The type of the Right <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TLeft, TRight>> OnRightAsync<TLeft, TRight>(
        this Either<TLeft, TRight> input,
        Func<TRight, Task<Unit>> action)
    {
        return await input.MatchAsync(
            left: _ => input.ToTask(),
            right: async response =>
            {
                await action(response);
                return input;
            });
    }

    /// <summary>
    ///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Right state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform the <paramref name="action"/> on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TLeft">The type of the Left <paramref name="input"/>.</typeparam>
    /// <typeparam name="TRight">The type of the Right <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TLeft, TRight>> OnRightAsync<TLeft, TRight>(
        this Task<Either<TLeft, TRight>> input,
        Func<TRight, Task<Unit>> action)
    {
        var either = await input;
      
        return await either.MatchAsync(
            left: _ => input,
            right: async response =>
            {
                await action(response);
                return either;
            });
    }
}