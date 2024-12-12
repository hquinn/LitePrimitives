// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for Perform on the Result type.
/// </summary>
public static class ResultPerformExtensions
{
    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="success">The action to perform if in the Success state.</param>
    /// <param name="failure">The action to perform if in the Failure state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Result<TValue>> PerformAsync<TValue>(
        this Task<Result<TValue>> input,
        Action<TValue>? success = null,
        Action<Error>? failure = null)
    {
        var result = await input;
        
        return result.Perform(
            success,
            failure);
    }
    
    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="success">The action to perform if in the Success state.</param>
    /// <param name="failure">The action to perform if in the Failure state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Result<TValue>> PerformAsync<TValue>(
        this Task<Result<TValue>> input,
        Func<TValue, Unit>? success = null,
        Func<Error, Unit>? failure = null)
    {
        var result = await input;
        
        return result.Perform(
            success,
            failure);
    }

    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="success">The asynchronous action to perform if in the Success state.</param>
    /// <param name="failure">The asynchronous action to perform if in the Failure state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Result<TValue>> PerformAsync<TValue>(
        this Task<Result<TValue>> input,
        Func<TValue, Task>? success = null,
        Func<Error, Task>? failure = null)
    {
        var result = await input;
        
        return await result.PerformAsync(
            success,
            failure);
    }

    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="success">The action to perform if in the Success state.</param>
    /// <param name="failure">The asynchronous action to perform if in the Failure state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Result<TValue>> PerformAsync<TValue>(
        this Task<Result<TValue>> input,
        Action<TValue>? success = null,
        Func<Error, Task>? failure = null)
    {
        var result = await input;
        
        return await result.PerformAsync(
            success,
            failure);
    }

    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="success">The asynchronous action to perform if in the Success state.</param>
    /// <param name="failure">The action to perform if in the Failure state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Result<TValue>> PerformAsync<TValue>(
        this Task<Result<TValue>> input,
        Func<TValue, Task>? success = null,
        Action<Error>? failure = null)
    {
        var result = await input;
        
        return await result.PerformAsync(
            success,
            failure);
    }

    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="success">The asynchronous action to perform if in the Success state.</param>
    /// <param name="failure">The asynchronous action to perform if in the Failure state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Result<TValue>> PerformAsync<TValue>(
        this Task<Result<TValue>> input,
        Func<TValue, Task<Unit>>? success = null,
        Func<Error, Task<Unit>>? failure = null)
    {
        var result = await input;
        
        return await result.PerformAsync(
            success,
            failure);
    }

    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="success">The action to perform if in the Success state.</param>
    /// <param name="failure">The asynchronous action to perform if in the Failure state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Result<TValue>> PerformAsync<TValue>(
        this Task<Result<TValue>> input,
        Func<TValue, Unit>? success = null,
        Func<Error, Task<Unit>>? failure = null)
    {
        var result = await input;
        
        return await result.PerformAsync(
            success,
            failure);
    }

    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="success">The asynchronous action to perform if in the Success state.</param>
    /// <param name="failure">The action to perform if in the Failure state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Result<TValue>> PerformAsync<TValue>(
        this Task<Result<TValue>> input,
        Func<TValue, Task<Unit>>? success = null,
        Func<Error, Unit>? failure = null)
    {
        var result = await input;
        
        return await result.PerformAsync(
            success,
            failure);
    }
}