// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for Perform on the Validation type.
/// </summary>
public static class ValidationPerformExtensions
{
    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="success">The action to perform if in the Success state.</param>
    /// <param name="failure">The action to perform if in the Failure state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Validation<TValue>> PerformAsync<TValue>(
        this Task<Validation<TValue>> input,
        Action<TValue>? success = null,
        Action<IError[]>? failure = null)
    {
        var validation = await input;
        
        return validation.Perform(
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
    public static async Task<Validation<TValue>> PerformAsync<TValue>(
        this Task<Validation<TValue>> input,
        Func<TValue, Unit>? success = null,
        Func<IError[], Unit>? failure = null)
    {
        var validation = await input;
        
        return validation.Perform(
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
    public static async Task<Validation<TValue>> PerformAsync<TValue>(
        this Task<Validation<TValue>> input,
        Func<TValue, Task>? success = null,
        Func<IError[], Task>? failure = null)
    {
        var validation = await input;
        
        return await validation.PerformAsync(
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
    public static async Task<Validation<TValue>> PerformAsync<TValue>(
        this Task<Validation<TValue>> input,
        Action<TValue>? success = null,
        Func<IError[], Task>? failure = null)
    {
        var validation = await input;
        
        return await validation.PerformAsync(
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
    public static async Task<Validation<TValue>> PerformAsync<TValue>(
        this Task<Validation<TValue>> input,
        Func<TValue, Task>? success = null,
        Action<IError[]>? failure = null)
    {
        var validation = await input;
        
        return await validation.PerformAsync(
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
    public static async Task<Validation<TValue>> PerformAsync<TValue>(
        this Task<Validation<TValue>> input,
        Func<TValue, Task<Unit>>? success = null,
        Func<IError[], Task<Unit>>? failure = null)
    {
        var validation = await input;
        
        return await validation.PerformAsync(
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
    public static async Task<Validation<TValue>> PerformAsync<TValue>(
        this Task<Validation<TValue>> input,
        Func<TValue, Unit>? success = null,
        Func<IError[], Task<Unit>>? failure = null)
    {
        var validation = await input;
        
        return await validation.PerformAsync(
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
    public static async Task<Validation<TValue>> PerformAsync<TValue>(
        this Task<Validation<TValue>> input,
        Func<TValue, Task<Unit>>? success = null,
        Func<IError[], Unit>? failure = null)
    {
        var validation = await input;
        
        return await validation.PerformAsync(
            success,
            failure);
    }
}