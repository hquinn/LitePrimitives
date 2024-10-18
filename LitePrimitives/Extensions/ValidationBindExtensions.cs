// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for Bind on the Validation type.
/// </summary>
public static class ValidationBindExtensions
{
    /// <summary>
    ///      Returns the validation of <paramref name="bindFunc"/> if in the Success state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Validation{TOutput}"/> in the Failure state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the Success state.</param>
    /// <typeparam name="TInput">The type of the Success <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutput">The type of the Success output.</typeparam>
    /// <returns>
    ///      The validation of <paramref name="bindFunc"/> if <paramref name="input"/> in the Success state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Validation{TOutput}"/> in the Failure state.
    /// </returns>
    public static async Task<Validation<TOutput>> BindAsync<TInput, TOutput>(
        this Task<Validation<TInput>> input,
        Func<TInput, Task<Validation<TOutput>>> bindFunc)
    {
        var validation = await input;
        return await validation.BindAsync(bindFunc);
    }
    
    /// <summary>
    ///      Returns the validation of <paramref name="bindFunc"/> if in the Success state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Validation{TOutput}"/> in the Failure state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the Success state.</param>
    /// <typeparam name="TInput">The type of the Success <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutput">The type of the Success output.</typeparam>
    /// <returns>
    ///      The validation of <paramref name="bindFunc"/> if <paramref name="input"/> in the Success state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Validation{TOutput}"/> in the Failure state.
    /// </returns>
    public static async Task<Validation<TOutput>> BindAsync<TInput, TOutput>(
        this Task<Validation<TInput>> input,
        Func<TInput, Validation<TOutput>> bindFunc)
    {
        var validation = await input;
        return validation.Bind(bindFunc);
    }
}