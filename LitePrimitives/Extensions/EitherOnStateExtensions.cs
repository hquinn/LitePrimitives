// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for On State on the Either type.
/// </summary>
public static class EitherOnStateExtensions
{
    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the First state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TLast>> OnFirstAsync<TFirst, TLast>(
        this Task<Either<TFirst, TLast>> input,
        Func<TFirst, Task> action)
    {
        var either = await input;
        await either.OnFirstAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the First state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TLast>> OnFirstAsync<TFirst, TLast>(
        this Task<Either<TFirst, TLast>> input,
        Func<TFirst, Task<Unit>> action)
    {
        var either = await input;
        await either.OnFirstAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the First state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TLast>> OnFirstAsync<TFirst, TLast>(
        this Task<Either<TFirst, TLast>> input,
        Action<TFirst> action)
    {
        var either = await input;
        either.OnFirst(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the First state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TLast>> OnFirstAsync<TFirst, TLast>(
        this Task<Either<TFirst, TLast>> input,
        Func<TFirst, Unit> action)
    {
        var either = await input;
        either.OnFirst(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Last state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TLast>> OnLastAsync<TFirst, TLast>(
        this Task<Either<TFirst, TLast>> input,
        Func<TLast, Task> action)
    {
        var either = await input;
        await either.OnLastAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Last state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TLast>> OnLastAsync<TFirst, TLast>(
        this Task<Either<TFirst, TLast>> input,
        Func<TLast, Task<Unit>> action)
    {
        var either = await input;
        await either.OnLastAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Last state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TLast>> OnLastAsync<TFirst, TLast>(
        this Task<Either<TFirst, TLast>> input,
        Action<TLast> action)
    {
        var either = await input;
        either.OnLast(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Last state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TLast>> OnLastAsync<TFirst, TLast>(
        this Task<Either<TFirst, TLast>> input,
        Func<TLast, Unit> action)
    {
        var either = await input;
        either.OnLast(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the First state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TLast>> OnFirstAsync<TFirst, TSecond, TLast>(
        this Task<Either<TFirst, TSecond, TLast>> input,
        Func<TFirst, Task> action)
    {
        var either = await input;
        await either.OnFirstAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the First state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TLast>> OnFirstAsync<TFirst, TSecond, TLast>(
        this Task<Either<TFirst, TSecond, TLast>> input,
        Func<TFirst, Task<Unit>> action)
    {
        var either = await input;
        await either.OnFirstAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the First state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TLast>> OnFirstAsync<TFirst, TSecond, TLast>(
        this Task<Either<TFirst, TSecond, TLast>> input,
        Action<TFirst> action)
    {
        var either = await input;
        either.OnFirst(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the First state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TLast>> OnFirstAsync<TFirst, TSecond, TLast>(
        this Task<Either<TFirst, TSecond, TLast>> input,
        Func<TFirst, Unit> action)
    {
        var either = await input;
        either.OnFirst(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Second state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TLast>> OnSecondAsync<TFirst, TSecond, TLast>(
        this Task<Either<TFirst, TSecond, TLast>> input,
        Func<TSecond, Task> action)
    {
        var either = await input;
        await either.OnSecondAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Second state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TLast>> OnSecondAsync<TFirst, TSecond, TLast>(
        this Task<Either<TFirst, TSecond, TLast>> input,
        Func<TSecond, Task<Unit>> action)
    {
        var either = await input;
        await either.OnSecondAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Second state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TLast>> OnSecondAsync<TFirst, TSecond, TLast>(
        this Task<Either<TFirst, TSecond, TLast>> input,
        Action<TSecond> action)
    {
        var either = await input;
        either.OnSecond(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Second state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TLast>> OnSecondAsync<TFirst, TSecond, TLast>(
        this Task<Either<TFirst, TSecond, TLast>> input,
        Func<TSecond, Unit> action)
    {
        var either = await input;
        either.OnSecond(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Last state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TLast>> OnLastAsync<TFirst, TSecond, TLast>(
        this Task<Either<TFirst, TSecond, TLast>> input,
        Func<TLast, Task> action)
    {
        var either = await input;
        await either.OnLastAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Last state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TLast>> OnLastAsync<TFirst, TSecond, TLast>(
        this Task<Either<TFirst, TSecond, TLast>> input,
        Func<TLast, Task<Unit>> action)
    {
        var either = await input;
        await either.OnLastAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Last state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TLast>> OnLastAsync<TFirst, TSecond, TLast>(
        this Task<Either<TFirst, TSecond, TLast>> input,
        Action<TLast> action)
    {
        var either = await input;
        either.OnLast(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Last state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TLast>> OnLastAsync<TFirst, TSecond, TLast>(
        this Task<Either<TFirst, TSecond, TLast>> input,
        Func<TLast, Unit> action)
    {
        var either = await input;
        either.OnLast(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the First state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TLast>> OnFirstAsync<TFirst, TSecond, TThird, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TLast>> input,
        Func<TFirst, Task> action)
    {
        var either = await input;
        await either.OnFirstAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the First state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TLast>> OnFirstAsync<TFirst, TSecond, TThird, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TLast>> input,
        Func<TFirst, Task<Unit>> action)
    {
        var either = await input;
        await either.OnFirstAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the First state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TLast>> OnFirstAsync<TFirst, TSecond, TThird, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TLast>> input,
        Action<TFirst> action)
    {
        var either = await input;
        either.OnFirst(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the First state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TLast>> OnFirstAsync<TFirst, TSecond, TThird, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TLast>> input,
        Func<TFirst, Unit> action)
    {
        var either = await input;
        either.OnFirst(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Second state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TLast>> OnSecondAsync<TFirst, TSecond, TThird, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TLast>> input,
        Func<TSecond, Task> action)
    {
        var either = await input;
        await either.OnSecondAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Second state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TLast>> OnSecondAsync<TFirst, TSecond, TThird, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TLast>> input,
        Func<TSecond, Task<Unit>> action)
    {
        var either = await input;
        await either.OnSecondAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Second state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TLast>> OnSecondAsync<TFirst, TSecond, TThird, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TLast>> input,
        Action<TSecond> action)
    {
        var either = await input;
        either.OnSecond(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Second state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TLast>> OnSecondAsync<TFirst, TSecond, TThird, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TLast>> input,
        Func<TSecond, Unit> action)
    {
        var either = await input;
        either.OnSecond(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Third state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TLast>> OnThirdAsync<TFirst, TSecond, TThird, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TLast>> input,
        Func<TThird, Task> action)
    {
        var either = await input;
        await either.OnThirdAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Third state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TLast>> OnThirdAsync<TFirst, TSecond, TThird, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TLast>> input,
        Func<TThird, Task<Unit>> action)
    {
        var either = await input;
        await either.OnThirdAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Third state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TLast>> OnThirdAsync<TFirst, TSecond, TThird, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TLast>> input,
        Action<TThird> action)
    {
        var either = await input;
        either.OnThird(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Third state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TLast>> OnThirdAsync<TFirst, TSecond, TThird, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TLast>> input,
        Func<TThird, Unit> action)
    {
        var either = await input;
        either.OnThird(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Last state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TLast>> OnLastAsync<TFirst, TSecond, TThird, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TLast>> input,
        Func<TLast, Task> action)
    {
        var either = await input;
        await either.OnLastAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Last state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TLast>> OnLastAsync<TFirst, TSecond, TThird, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TLast>> input,
        Func<TLast, Task<Unit>> action)
    {
        var either = await input;
        await either.OnLastAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Last state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TLast>> OnLastAsync<TFirst, TSecond, TThird, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TLast>> input,
        Action<TLast> action)
    {
        var either = await input;
        either.OnLast(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Last state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TLast>> OnLastAsync<TFirst, TSecond, TThird, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TLast>> input,
        Func<TLast, Unit> action)
    {
        var either = await input;
        either.OnLast(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the First state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> OnFirstAsync<TFirst, TSecond, TThird, TFourth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> input,
        Func<TFirst, Task> action)
    {
        var either = await input;
        await either.OnFirstAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the First state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> OnFirstAsync<TFirst, TSecond, TThird, TFourth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> input,
        Func<TFirst, Task<Unit>> action)
    {
        var either = await input;
        await either.OnFirstAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the First state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> OnFirstAsync<TFirst, TSecond, TThird, TFourth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> input,
        Action<TFirst> action)
    {
        var either = await input;
        either.OnFirst(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the First state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> OnFirstAsync<TFirst, TSecond, TThird, TFourth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> input,
        Func<TFirst, Unit> action)
    {
        var either = await input;
        either.OnFirst(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Second state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> OnSecondAsync<TFirst, TSecond, TThird, TFourth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> input,
        Func<TSecond, Task> action)
    {
        var either = await input;
        await either.OnSecondAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Second state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> OnSecondAsync<TFirst, TSecond, TThird, TFourth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> input,
        Func<TSecond, Task<Unit>> action)
    {
        var either = await input;
        await either.OnSecondAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Second state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> OnSecondAsync<TFirst, TSecond, TThird, TFourth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> input,
        Action<TSecond> action)
    {
        var either = await input;
        either.OnSecond(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Second state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> OnSecondAsync<TFirst, TSecond, TThird, TFourth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> input,
        Func<TSecond, Unit> action)
    {
        var either = await input;
        either.OnSecond(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Third state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> OnThirdAsync<TFirst, TSecond, TThird, TFourth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> input,
        Func<TThird, Task> action)
    {
        var either = await input;
        await either.OnThirdAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Third state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> OnThirdAsync<TFirst, TSecond, TThird, TFourth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> input,
        Func<TThird, Task<Unit>> action)
    {
        var either = await input;
        await either.OnThirdAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Third state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> OnThirdAsync<TFirst, TSecond, TThird, TFourth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> input,
        Action<TThird> action)
    {
        var either = await input;
        either.OnThird(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Third state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> OnThirdAsync<TFirst, TSecond, TThird, TFourth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> input,
        Func<TThird, Unit> action)
    {
        var either = await input;
        either.OnThird(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Fourth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> OnFourthAsync<TFirst, TSecond, TThird, TFourth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> input,
        Func<TFourth, Task> action)
    {
        var either = await input;
        await either.OnFourthAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Fourth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> OnFourthAsync<TFirst, TSecond, TThird, TFourth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> input,
        Func<TFourth, Task<Unit>> action)
    {
        var either = await input;
        await either.OnFourthAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Fourth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> OnFourthAsync<TFirst, TSecond, TThird, TFourth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> input,
        Action<TFourth> action)
    {
        var either = await input;
        either.OnFourth(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Fourth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> OnFourthAsync<TFirst, TSecond, TThird, TFourth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> input,
        Func<TFourth, Unit> action)
    {
        var either = await input;
        either.OnFourth(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Last state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> OnLastAsync<TFirst, TSecond, TThird, TFourth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> input,
        Func<TLast, Task> action)
    {
        var either = await input;
        await either.OnLastAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Last state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> OnLastAsync<TFirst, TSecond, TThird, TFourth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> input,
        Func<TLast, Task<Unit>> action)
    {
        var either = await input;
        await either.OnLastAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Last state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> OnLastAsync<TFirst, TSecond, TThird, TFourth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> input,
        Action<TLast> action)
    {
        var either = await input;
        either.OnLast(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Last state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> OnLastAsync<TFirst, TSecond, TThird, TFourth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> input,
        Func<TLast, Unit> action)
    {
        var either = await input;
        either.OnLast(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the First state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> OnFirstAsync<TFirst, TSecond, TThird, TFourth, TFifth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> input,
        Func<TFirst, Task> action)
    {
        var either = await input;
        await either.OnFirstAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the First state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> OnFirstAsync<TFirst, TSecond, TThird, TFourth, TFifth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> input,
        Func<TFirst, Task<Unit>> action)
    {
        var either = await input;
        await either.OnFirstAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the First state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> OnFirstAsync<TFirst, TSecond, TThird, TFourth, TFifth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> input,
        Action<TFirst> action)
    {
        var either = await input;
        either.OnFirst(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the First state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> OnFirstAsync<TFirst, TSecond, TThird, TFourth, TFifth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> input,
        Func<TFirst, Unit> action)
    {
        var either = await input;
        either.OnFirst(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Second state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> OnSecondAsync<TFirst, TSecond, TThird, TFourth, TFifth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> input,
        Func<TSecond, Task> action)
    {
        var either = await input;
        await either.OnSecondAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Second state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> OnSecondAsync<TFirst, TSecond, TThird, TFourth, TFifth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> input,
        Func<TSecond, Task<Unit>> action)
    {
        var either = await input;
        await either.OnSecondAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Second state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> OnSecondAsync<TFirst, TSecond, TThird, TFourth, TFifth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> input,
        Action<TSecond> action)
    {
        var either = await input;
        either.OnSecond(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Second state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> OnSecondAsync<TFirst, TSecond, TThird, TFourth, TFifth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> input,
        Func<TSecond, Unit> action)
    {
        var either = await input;
        either.OnSecond(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Third state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> OnThirdAsync<TFirst, TSecond, TThird, TFourth, TFifth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> input,
        Func<TThird, Task> action)
    {
        var either = await input;
        await either.OnThirdAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Third state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> OnThirdAsync<TFirst, TSecond, TThird, TFourth, TFifth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> input,
        Func<TThird, Task<Unit>> action)
    {
        var either = await input;
        await either.OnThirdAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Third state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> OnThirdAsync<TFirst, TSecond, TThird, TFourth, TFifth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> input,
        Action<TThird> action)
    {
        var either = await input;
        either.OnThird(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Third state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> OnThirdAsync<TFirst, TSecond, TThird, TFourth, TFifth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> input,
        Func<TThird, Unit> action)
    {
        var either = await input;
        either.OnThird(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Fourth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> OnFourthAsync<TFirst, TSecond, TThird, TFourth, TFifth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> input,
        Func<TFourth, Task> action)
    {
        var either = await input;
        await either.OnFourthAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Fourth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> OnFourthAsync<TFirst, TSecond, TThird, TFourth, TFifth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> input,
        Func<TFourth, Task<Unit>> action)
    {
        var either = await input;
        await either.OnFourthAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Fourth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> OnFourthAsync<TFirst, TSecond, TThird, TFourth, TFifth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> input,
        Action<TFourth> action)
    {
        var either = await input;
        either.OnFourth(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Fourth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> OnFourthAsync<TFirst, TSecond, TThird, TFourth, TFifth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> input,
        Func<TFourth, Unit> action)
    {
        var either = await input;
        either.OnFourth(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Fifth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> OnFifthAsync<TFirst, TSecond, TThird, TFourth, TFifth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> input,
        Func<TFifth, Task> action)
    {
        var either = await input;
        await either.OnFifthAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Fifth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> OnFifthAsync<TFirst, TSecond, TThird, TFourth, TFifth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> input,
        Func<TFifth, Task<Unit>> action)
    {
        var either = await input;
        await either.OnFifthAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Fifth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> OnFifthAsync<TFirst, TSecond, TThird, TFourth, TFifth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> input,
        Action<TFifth> action)
    {
        var either = await input;
        either.OnFifth(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Fifth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> OnFifthAsync<TFirst, TSecond, TThird, TFourth, TFifth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> input,
        Func<TFifth, Unit> action)
    {
        var either = await input;
        either.OnFifth(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Last state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> OnLastAsync<TFirst, TSecond, TThird, TFourth, TFifth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> input,
        Func<TLast, Task> action)
    {
        var either = await input;
        await either.OnLastAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Last state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> OnLastAsync<TFirst, TSecond, TThird, TFourth, TFifth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> input,
        Func<TLast, Task<Unit>> action)
    {
        var either = await input;
        await either.OnLastAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Last state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> OnLastAsync<TFirst, TSecond, TThird, TFourth, TFifth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> input,
        Action<TLast> action)
    {
        var either = await input;
        either.OnLast(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Last state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> OnLastAsync<TFirst, TSecond, TThird, TFourth, TFifth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> input,
        Func<TLast, Unit> action)
    {
        var either = await input;
        either.OnLast(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the First state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> OnFirstAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> input,
        Func<TFirst, Task> action)
    {
        var either = await input;
        await either.OnFirstAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the First state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> OnFirstAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> input,
        Func<TFirst, Task<Unit>> action)
    {
        var either = await input;
        await either.OnFirstAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the First state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> OnFirstAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> input,
        Action<TFirst> action)
    {
        var either = await input;
        either.OnFirst(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the First state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> OnFirstAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> input,
        Func<TFirst, Unit> action)
    {
        var either = await input;
        either.OnFirst(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Second state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> OnSecondAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> input,
        Func<TSecond, Task> action)
    {
        var either = await input;
        await either.OnSecondAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Second state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> OnSecondAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> input,
        Func<TSecond, Task<Unit>> action)
    {
        var either = await input;
        await either.OnSecondAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Second state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> OnSecondAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> input,
        Action<TSecond> action)
    {
        var either = await input;
        either.OnSecond(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Second state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> OnSecondAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> input,
        Func<TSecond, Unit> action)
    {
        var either = await input;
        either.OnSecond(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Third state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> OnThirdAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> input,
        Func<TThird, Task> action)
    {
        var either = await input;
        await either.OnThirdAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Third state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> OnThirdAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> input,
        Func<TThird, Task<Unit>> action)
    {
        var either = await input;
        await either.OnThirdAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Third state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> OnThirdAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> input,
        Action<TThird> action)
    {
        var either = await input;
        either.OnThird(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Third state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> OnThirdAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> input,
        Func<TThird, Unit> action)
    {
        var either = await input;
        either.OnThird(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Fourth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> OnFourthAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> input,
        Func<TFourth, Task> action)
    {
        var either = await input;
        await either.OnFourthAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Fourth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> OnFourthAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> input,
        Func<TFourth, Task<Unit>> action)
    {
        var either = await input;
        await either.OnFourthAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Fourth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> OnFourthAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> input,
        Action<TFourth> action)
    {
        var either = await input;
        either.OnFourth(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Fourth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> OnFourthAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> input,
        Func<TFourth, Unit> action)
    {
        var either = await input;
        either.OnFourth(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Fifth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> OnFifthAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> input,
        Func<TFifth, Task> action)
    {
        var either = await input;
        await either.OnFifthAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Fifth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> OnFifthAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> input,
        Func<TFifth, Task<Unit>> action)
    {
        var either = await input;
        await either.OnFifthAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Fifth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> OnFifthAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> input,
        Action<TFifth> action)
    {
        var either = await input;
        either.OnFifth(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Fifth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> OnFifthAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> input,
        Func<TFifth, Unit> action)
    {
        var either = await input;
        either.OnFifth(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Sixth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> OnSixthAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> input,
        Func<TSixth, Task> action)
    {
        var either = await input;
        await either.OnSixthAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Sixth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> OnSixthAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> input,
        Func<TSixth, Task<Unit>> action)
    {
        var either = await input;
        await either.OnSixthAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Sixth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> OnSixthAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> input,
        Action<TSixth> action)
    {
        var either = await input;
        either.OnSixth(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Sixth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> OnSixthAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> input,
        Func<TSixth, Unit> action)
    {
        var either = await input;
        either.OnSixth(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Last state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> OnLastAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> input,
        Func<TLast, Task> action)
    {
        var either = await input;
        await either.OnLastAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Last state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> OnLastAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> input,
        Func<TLast, Task<Unit>> action)
    {
        var either = await input;
        await either.OnLastAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Last state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> OnLastAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> input,
        Action<TLast> action)
    {
        var either = await input;
        either.OnLast(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Last state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> OnLastAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> input,
        Func<TLast, Unit> action)
    {
        var either = await input;
        either.OnLast(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the First state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnFirstAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Func<TFirst, Task> action)
    {
        var either = await input;
        await either.OnFirstAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the First state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnFirstAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Func<TFirst, Task<Unit>> action)
    {
        var either = await input;
        await either.OnFirstAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the First state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnFirstAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Action<TFirst> action)
    {
        var either = await input;
        either.OnFirst(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the First state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnFirstAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Func<TFirst, Unit> action)
    {
        var either = await input;
        either.OnFirst(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Second state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnSecondAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Func<TSecond, Task> action)
    {
        var either = await input;
        await either.OnSecondAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Second state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnSecondAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Func<TSecond, Task<Unit>> action)
    {
        var either = await input;
        await either.OnSecondAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Second state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnSecondAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Action<TSecond> action)
    {
        var either = await input;
        either.OnSecond(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Second state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnSecondAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Func<TSecond, Unit> action)
    {
        var either = await input;
        either.OnSecond(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Third state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnThirdAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Func<TThird, Task> action)
    {
        var either = await input;
        await either.OnThirdAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Third state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnThirdAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Func<TThird, Task<Unit>> action)
    {
        var either = await input;
        await either.OnThirdAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Third state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnThirdAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Action<TThird> action)
    {
        var either = await input;
        either.OnThird(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Third state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnThirdAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Func<TThird, Unit> action)
    {
        var either = await input;
        either.OnThird(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Fourth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnFourthAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Func<TFourth, Task> action)
    {
        var either = await input;
        await either.OnFourthAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Fourth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnFourthAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Func<TFourth, Task<Unit>> action)
    {
        var either = await input;
        await either.OnFourthAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Fourth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnFourthAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Action<TFourth> action)
    {
        var either = await input;
        either.OnFourth(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Fourth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnFourthAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Func<TFourth, Unit> action)
    {
        var either = await input;
        either.OnFourth(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Fifth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnFifthAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Func<TFifth, Task> action)
    {
        var either = await input;
        await either.OnFifthAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Fifth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnFifthAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Func<TFifth, Task<Unit>> action)
    {
        var either = await input;
        await either.OnFifthAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Fifth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnFifthAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Action<TFifth> action)
    {
        var either = await input;
        either.OnFifth(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Fifth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnFifthAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Func<TFifth, Unit> action)
    {
        var either = await input;
        either.OnFifth(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Sixth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnSixthAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Func<TSixth, Task> action)
    {
        var either = await input;
        await either.OnSixthAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Sixth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnSixthAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Func<TSixth, Task<Unit>> action)
    {
        var either = await input;
        await either.OnSixthAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Sixth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnSixthAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Action<TSixth> action)
    {
        var either = await input;
        either.OnSixth(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Sixth state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnSixthAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Func<TSixth, Unit> action)
    {
        var either = await input;
        either.OnSixth(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Seventh state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnSeventhAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Func<TSeventh, Task> action)
    {
        var either = await input;
        await either.OnSeventhAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Seventh state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnSeventhAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Func<TSeventh, Task<Unit>> action)
    {
        var either = await input;
        await either.OnSeventhAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Seventh state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnSeventhAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Action<TSeventh> action)
    {
        var either = await input;
        either.OnSeventh(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Seventh state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnSeventhAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Func<TSeventh, Unit> action)
    {
        var either = await input;
        either.OnSeventh(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Last state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnLastAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Func<TLast, Task> action)
    {
        var either = await input;
        await either.OnLastAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Last state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnLastAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Func<TLast, Task<Unit>> action)
    {
        var either = await input;
        await either.OnLastAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Last state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnLastAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Action<TLast> action)
    {
        var either = await input;
        either.OnLast(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Last state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnLastAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Func<TLast, Unit> action)
    {
        var either = await input;
        either.OnLast(action);
        return either;
    }
}