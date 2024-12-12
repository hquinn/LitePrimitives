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
        var result = await input;
        await result.OnSuccessAsync(action);
        return result;
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
        var result = await input;
        await result.OnSuccessAsync(action);
        return result;
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
        var result = await input;
        result.OnSuccess(action);
        return result;
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
        var result = await input;
        result.OnSuccess(action);
        return result;
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
        Func<Error, Task> action)
    {
        var result = await input;
        await result.OnFailureAsync(action);
        return result;
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
        Func<Error, Task<Unit>> action)
    {
        var result = await input;
        await result.OnFailureAsync(action);
        return result;
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
        Action<Error> action)
    {
        var result = await input;
        result.OnFailure(action);
        return result;
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
        Func<Error, Unit> action)
    {
        var result = await input;
        result.OnFailure(action);
        return result;
    }
}