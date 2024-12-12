// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for Sequence on the Result type.
/// </summary>
public static class ResultSequenceExtensions
{
    /// <summary>
    ///    Sequences a collection of results into a single Result type.
    /// </summary>
    /// <param name="results">The collection of Results to sequence.</param>
    /// <typeparam name="T">The output type.</typeparam>
    /// <returns>The Result type of the sequence of results.</returns>
    public static Result<IEnumerable<T>> Sequence<T>(this IEnumerable<Result<T>> results)
    {
        var list = new List<T>();
        foreach (var result in results)
        {
            if (result.IsFailure)
            {
                return Result<IEnumerable<T>>.Failure(result.Error!.Value);
            }
            
            list.Add(result.Value!);
        }
        
        return Result<IEnumerable<T>>.Success(list);
    }
}