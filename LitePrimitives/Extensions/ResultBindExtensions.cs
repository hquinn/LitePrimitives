// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for Bind on the Result type.
/// </summary>
public static class ResultBindExtensions
{
    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Success state,
    ///      otherwise returns <see cref="Result{TOutput}"/> in the Failure state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the Success state.</param>
    /// <typeparam name="TInput">The type of the Success <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutput">The type of the Success output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the Success state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Result{TOutput}"/> in the Failure state.
    /// </returns>
    public static async Task<Result<TOutput>> BindAsync<TInput, TOutput>(
        this Task<Result<TInput>> input,
        Func<TInput, Task<Result<TOutput>>> bindFunc)
    {
        var result = await input;
        return await result.BindAsync(bindFunc);
    }
}