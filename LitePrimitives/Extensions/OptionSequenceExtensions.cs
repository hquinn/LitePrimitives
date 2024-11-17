// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for Sequence on the Option type.
/// </summary>
public static class OptionSequenceExtensions
{
    /// <summary>
    ///    Sequences a collection of results into a single Option type.
    /// </summary>
    /// <param name="options">The collection of Options to sequence.</param>
    /// <typeparam name="T">The output type.</typeparam>
    /// <returns>The Option type of the sequence of options.</returns>
    public static Option<IEnumerable<T>> Sequence<T>(this IEnumerable<Option<T>> options)
    {
        var list = new List<T>();
        foreach (var option in options)
        {
            if (option.IsNone)
            {
                return Option<IEnumerable<T>>.None();
            }
            
            list.Add(option.Value!);
        }
        
        return Option<IEnumerable<T>>.Some(list);
    }
}