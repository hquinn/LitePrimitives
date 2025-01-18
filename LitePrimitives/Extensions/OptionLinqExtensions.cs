using System.Runtime.InteropServices;
using LitePrimitives.Helpers;

// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for Linq
/// </summary>
public static class OptionLinqExtensions
{
    /// <summary>
    /// Source: https://github.com/dotnet/dotNext/blob/78ba6bf37d800ae58f1a33bcd940ba0b649ccea6/src/DotNext/Collections/Generic/Collection.cs
    ///
    /// Gets the first element from the source, otherwise returns None if source is empty.
    /// </summary>
    /// <param name="source">The source to use.</param>
    /// <typeparam name="TValue">The type of the <see cref="Option{TValue}"/></typeparam>
    /// <returns>The first element, otherwise None.</returns>
    public static Option<TValue> FirstOrNone<TValue>(this IEnumerable<TValue>? source)
    {
        return source switch
        {
            null => throw new ArgumentNullException(nameof(source)),
            List<TValue> list => FirstOrNoneSpan<TValue>(CollectionsMarshal.AsSpan(list)),
            TValue[] array => FirstOrNoneSpan<TValue>(array),
            LinkedList<TValue> list => list.First is { } first ? first.Value : Option<TValue>.None(),
            IList<TValue> list => list.Count > 0 ? list[0] : Option<TValue>.None(),
            IReadOnlyList<TValue> readOnlyList => readOnlyList.Count > 0 ? readOnlyList[0] : Option<TValue>.None(),
            _ => FirstOrNoneSlow(source)
        };

        static Option<TValue> FirstOrNoneSlow(IEnumerable<TValue> collection)
        {
            using var enumerator = collection.GetEnumerator();
            return enumerator.MoveNext() ? enumerator.Current : Option<TValue>.None();
        }
    }

    /// <summary>
    /// Source: https://github.com/dotnet/dotNext/blob/78ba6bf37d800ae58f1a33bcd940ba0b649ccea6/src/DotNext/Collections/Generic/Collection.cs
    /// 
    /// Gets the first element from the source, otherwise returns None if source is empty.
    /// </summary>
    /// <param name="source">The source to use.</param>
    /// <param name="predicate">The predicate to use.</param>
    /// <typeparam name="TValue">The type of the <see cref="Option{TValue}"/></typeparam>
    /// <returns>The first element, otherwise None.</returns>
    public static Option<TValue> FirstOrNone<TValue>(
        this IEnumerable<TValue>? source,
        Predicate<TValue> predicate)
    {
        return source switch
        {
            null => throw new ArgumentNullException(nameof(source)),
            List<TValue> list => FirstOrNoneSpan(CollectionsMarshal.AsSpan(list), predicate),
            TValue[] array => FirstOrNoneSpan(array, predicate),
            _ => FirstOrNoneSlow(source, predicate)
        };

        static Option<TValue> FirstOrNoneSlow(IEnumerable<TValue> collection, Predicate<TValue> predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    return item;
                }
            }
            
            return Option<TValue>.None();
        }
    }
    
    /// <summary>
    /// Source: https://github.com/dotnet/dotNext/blob/78ba6bf37d800ae58f1a33bcd940ba0b649ccea6/src/DotNext/Collections/Generic/Collection.cs
    ///
    /// Gets the last element from the source, otherwise returns None if source is empty.
    /// </summary>
    /// <param name="source">The source to use.</param>
    /// <typeparam name="TValue">The type of the <see cref="Option{TValue}"/></typeparam>
    /// <returns>The last element, otherwise None.</returns>
    public static Option<TValue> LastOrNone<TValue>(this IEnumerable<TValue>? source)
    {
        return source switch
        {
            null => throw new ArgumentNullException(nameof(source)),
            List<TValue> list => LastOrNoneSpan<TValue>(CollectionsMarshal.AsSpan(list)),
            TValue[] array => LastOrNoneSpan<TValue>(array),
            LinkedList<TValue> list => list.Last is { } last ? last.Value : Option<TValue>.None(),
            IList<TValue> list => list.Count > 0 ? list[^1] : Option<TValue>.None(),
            IReadOnlyList<TValue> readOnlyList => readOnlyList.Count > 0 ? readOnlyList[^1] : Option<TValue>.None(),
            _ => LastOrNoneSlow(source)
        };

        static Option<TValue> LastOrNoneSlow(IEnumerable<TValue> collection)
        {
            var result = Option<TValue>.None();
            foreach (var item in collection)
            {
                result = item;
            }

            return result;
        }
    }

    /// <summary>
    /// Source: https://github.com/dotnet/dotNext/blob/78ba6bf37d800ae58f1a33bcd940ba0b649ccea6/src/DotNext/Collections/Generic/Collection.cs
    /// 
    /// Gets the last element from the source, otherwise returns None if source is empty.
    /// </summary>
    /// <param name="source">The source to use.</param>
    /// <param name="predicate">The predicate to use.</param>
    /// <typeparam name="TValue">The type of the <see cref="Option{TValue}"/></typeparam>
    /// <returns>The last element, otherwise None.</returns>
    public static Option<TValue> LastOrNone<TValue>(
        this IEnumerable<TValue>? source,
        Predicate<TValue> predicate)
    {
        return source switch
        {
            null => throw new ArgumentNullException(nameof(source)),
            List<TValue> list => LastOrNoneSpan(CollectionsMarshal.AsSpan(list), predicate),
            TValue[] array => LastOrNoneSpan(array, predicate),
            _ => LastOrNoneSlow(source, predicate)
        };

        static Option<TValue> LastOrNoneSlow(IEnumerable<TValue> collection, Predicate<TValue> predicate)
        {
            var result = Option<TValue>.None();
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    result = item;
                }
            }
            
            return result;
        }
    }

    private static Option<TValue> FirstOrNoneSpan<TValue>(ReadOnlySpan<TValue> span)
    {
        if (span.IsEmpty)
        {
            return Option<TValue>.None();
        }

        return span[0];
    }

    // https://github.com/dotnet/dotNext/blob/78ba6bf37d800ae58f1a33bcd940ba0b649ccea6/src/DotNext/Span.cs
    private static Option<TValue> FirstOrNoneSpan<TValue>(ReadOnlySpan<TValue> span, Predicate<TValue>? filter)
    {
        filter ??= Predicate.Constant<TValue>(true);

        for (var index = 0; index < span.Length; index++)
        {
            var item = span[index];
            if (filter(item))
            {
                return item;
            }
        }

        return Option<TValue>.None();
    }

    private static Option<TValue> LastOrNoneSpan<TValue>(ReadOnlySpan<TValue> span)
    {
        if (span.IsEmpty)
        {
            return Option<TValue>.None();
        }

        return span[^1];
    }

    // https://github.com/dotnet/dotNext/blob/78ba6bf37d800ae58f1a33bcd940ba0b649ccea6/src/DotNext/Span.cs
    private static Option<TValue> LastOrNoneSpan<TValue>(ReadOnlySpan<TValue> span, Predicate<TValue>? filter)
    {
        filter ??= Predicate.Constant<TValue>(true);

        for (var index = span.Length - 1; index >= 0; index--)
        {
            var item = span[index];
            if (filter(item))
            {
                return item;
            }
        }

        return Option<TValue>.None();
    }
}