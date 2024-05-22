// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for ToTask on the Option type.
/// </summary>
public static class OptionToTaskExtensions
{
    /// <summary>
    ///     Creates a <see cref="Task"/> from <see cref="Option{TValue}"/>.
    /// </summary>
    /// <param name="input">The input to create into a <see cref="Task"/>.</param>
    /// <typeparam name="TValue">The type of the <paramref name="input"/>.</typeparam>
    /// <returns>The created <see cref="Task"/> of from the <paramref name="input"/>.</returns>
    public static Task<Option<TValue>> ToTask<TValue>(this Option<TValue> input)
    {
        return Task.FromResult(input);
    }
}