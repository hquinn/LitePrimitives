// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for Bind on the Option type.
/// </summary>
public static class OptionBindExtensions
{
    /// <summary>
    ///     Returns the return type of <paramref name="bindFunc"/> if the <paramref name="input"/> parameter is in the Some state,
    ///     otherwise returns <see cref="Task"/> of type <see cref="Option{TOutput}"/> in the None state.
    /// </summary>
    /// <param name="input">The asynchronous input to check.</param>
    /// <param name="bindFunc">The asynchronous func to apply if <paramref name="input"/> is in the Some state.</param>
    /// <typeparam name="TInput">The type of the <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutput">The type of the output.</typeparam>
    /// <returns>
    ///     The result of <paramref name="bindFunc"/> if <paramref name="input"/> is in the Some state,
    ///     otherwise returns <see cref="Task"/> of type <see cref="Option{TOutput}"/> in the None state.
    /// </returns>
    public static async Task<Option<TOutput>> BindAsync<TInput, TOutput>(
        this Task<Option<TInput>> input,
        Func<TInput, Task<Option<TOutput>>> bindFunc)
    {
        var option = await input;
        
        return await option.MatchAsync(
            some: async value => await bindFunc(value),
            none: () => Option<TOutput>.None().ToTask());
    }
}