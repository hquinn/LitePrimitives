// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for To Task on the Validation type.
/// </summary>
public static class ValidationToTaskExtensions
{
    /// <summary>
    ///     Creates a <see cref="Task"/> from <see cref="Validation{TValue}"/>.
    /// </summary>
    /// <param name="input">The input to create into a <see cref="Task"/>.</param>
    /// <typeparam name="TValue">The type of the Success <paramref name="input"/>.</typeparam>
    /// <returns>The created <see cref="Task"/> of from the <paramref name="input"/>.</returns>
    public static Task<Validation<TValue>> ToTask<TValue>(
        this Validation<TValue> input)
    {
        return Task.FromResult(input);
    }
}