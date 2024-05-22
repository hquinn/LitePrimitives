// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for ToOption on the Option type.
/// </summary>
public static class OptionToOptionExtensions
{
    /// <summary>
    ///     Converts the <paramref name="value"/> parameter to a <see cref="Option{TValue}"/> in the Some state if the <paramref name="value"/> parameter is present,
    ///     otherwise converts the <paramref name="value"/> to <see cref="Option{TValue}"/> in the None state.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <typeparam name="TValue">
    ///     The type of the <paramref name="value"/> parameter and the return type for <see cref="Option{TValue}"/>.
    /// </typeparam>
    /// <returns>
    ///     The <paramref name="value"/> parameter after converting it to <see cref="Option{TValue}"/> in the Some state if the <paramref name="value"/> parameter is present,
    ///     otherwise converts the <paramref name="value"/> to <see cref="Option{TValue}"/> in the None state.
    /// </returns>
    public static Option<TValue> ToOption<TValue>(this TValue? value)
    {
        return value is not null 
            ? Option<TValue>.Some(value) 
            : Option<TValue>.None();
    }
}