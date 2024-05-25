// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for To Task on the Result type.
/// </summary>
public static class ResultToTaskExtensions
{
    /// <summary>
    ///     Creates a <see cref="Task"/> from <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="input">The input to create into a <see cref="Task"/>.</param>
    /// <typeparam name="TValue">The type of the Success <paramref name="input"/>.</typeparam>
    /// <returns>The created <see cref="Task"/> of from the <paramref name="input"/>.</returns>
    public static Task<Result<TValue>> ToTask<TValue>(
        this Result<TValue> input)
    {
        return Task.FromResult(input);
    }
}