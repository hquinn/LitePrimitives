// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for On State on the Validation type.
/// </summary>
public static class ValidationOnStateExtensions
{
    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Success state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TValue">The type of the Success <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Validation<TValue>> OnSuccessAsync<TValue>(
        this Task<Validation<TValue>> input,
        Func<TValue, Task> action)
    {
        var validation = await input;
        await validation.OnSuccessAsync(action);
        return validation;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Success state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TValue">The type of the Success <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Validation<TValue>> OnSuccessAsync<TValue>(
        this Task<Validation<TValue>> input,
        Func<TValue, Task<Unit>> action)
    {
        var validation = await input;
        await validation.OnSuccessAsync(action);
        return validation;
    }
    
    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Success state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TValue">The type of the Success <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Validation<TValue>> OnSuccessAsync<TValue>(
        this Task<Validation<TValue>> input,
        Action<TValue> action)
    {
        var validation = await input;
        validation.OnSuccess(action);
        return validation;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Success state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TValue">The type of the Success <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Validation<TValue>> OnSuccessAsync<TValue>(
        this Task<Validation<TValue>> input,
        Func<TValue, Unit> action)
    {
        var validation = await input;
        validation.OnSuccess(action);
        return validation;
    }
    
    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Failure state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TValue">The type of the Success <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Validation<TValue>> OnFailureAsync<TValue>(
        this Task<Validation<TValue>> input,
        Func<IError[], Task> action)
    {
        var validation = await input;
        await validation.OnFailureAsync(action);
        return validation;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Failure state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <typeparam name="TValue">The type of the Success <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Validation<TValue>> OnFailureAsync<TValue>(
        this Task<Validation<TValue>> input,
        Func<IError[], Task<Unit>> action)
    {
        var validation = await input;
        await validation.OnFailureAsync(action);
        return validation;
    }
    
    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Failure state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TValue">The type of the Success <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Validation<TValue>> OnFailureAsync<TValue>(
        this Task<Validation<TValue>> input,
        Action<IError[]> action)
    {
        var validation = await input;
        validation.OnFailure(action);
        return validation;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Failure state.
    /// </summary>
    /// <param name="input">The asynchronous input to perform action on.</param>
    /// <param name="action">The action to perform.</param>
    /// <typeparam name="TValue">The type of the Success <paramref name="input"/>.</typeparam>
    /// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
    public static async Task<Validation<TValue>> OnFailureAsync<TValue>(
        this Task<Validation<TValue>> input,
        Func<IError[], Unit> action)
    {
        var validation = await input;
        validation.OnFailure(action);
        return validation;
    }
}