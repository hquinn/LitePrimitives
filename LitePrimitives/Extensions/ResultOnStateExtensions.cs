// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for On State on the Result type.
/// </summary>
public static class ResultOnStateExtensions
{
    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Success state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TValue">The type of the Success <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Result<TValue>> OnSuccessAsync<TValue>(
        this Task<Result<TValue>> input,
        Func<TValue, Task> action)
    {
        var either = await input;
        await either.OnSuccessAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Success state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TValue">The type of the Success <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Result<TValue>> OnSuccessAsync<TValue>(
        this Task<Result<TValue>> input,
        Func<TValue, Task<Unit>> action)
    {
        var either = await input;
        await either.OnSuccessAsync(action);
        return either;
    }
    
    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Success state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TValue">The type of the Success <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Result<TValue>> OnSuccessAsync<TValue>(
        this Task<Result<TValue>> input,
        Action<TValue> action)
    {
        var either = await input;
        either.OnSuccess(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Success state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TValue">The type of the Success <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Result<TValue>> OnSuccessAsync<TValue>(
        this Task<Result<TValue>> input,
        Func<TValue, Unit> action)
    {
        var either = await input;
        either.OnSuccess(action);
        return either;
    }
    
    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Failure state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TValue">The type of the Success <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Result<TValue>> OnFailureAsync<TValue>(
        this Task<Result<TValue>> input,
        Func<IError[], Task> action)
    {
        var either = await input;
        await either.OnFailureAsync(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Failure state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TValue">The type of the Success <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Result<TValue>> OnFailureAsync<TValue>(
        this Task<Result<TValue>> input,
        Func<IError[], Task<Unit>> action)
    {
        var either = await input;
        await either.OnFailureAsync(action);
        return either;
    }
    
    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Failure state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TValue">The type of the Success <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Result<TValue>> OnFailureAsync<TValue>(
        this Task<Result<TValue>> input,
        Action<IError[]> action)
    {
        var either = await input;
        either.OnFailure(action);
        return either;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Failure state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TValue">The type of the Success <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Result<TValue>> OnFailureAsync<TValue>(
        this Task<Result<TValue>> input,
        Func<IError[], Unit> action)
    {
        var either = await input;
        either.OnFailure(action);
        return either;
    }
}