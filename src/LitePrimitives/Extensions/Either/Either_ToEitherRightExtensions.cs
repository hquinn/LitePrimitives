namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for ToEitherRight on the Either type.
/// </summary>
public static class Either_ToEitherRightExtensions
{
    /// <summary>
    ///     Converts the <paramref name="right"/> parameter to an <see cref="Either{TLeft, TRight}"/> in the Left state.
    /// </summary>
    /// <param name="right">The parameter to convert.</param>
    /// <typeparam name="TLeft">
    ///     Part of the return type for <see cref="Either{TLeft, TRight}"/>.
    /// </typeparam>
    /// <typeparam name="TRight">
    ///     The type of the <paramref name="right"/> parameter and the return type for <see cref="Either{TLeft, TRight}"/>.
    /// </typeparam>
    /// <returns>
    ///     The <paramref name="right"/> parameter after converting it to <see cref="Either{TLeft, TRight}"/> in the Left state.
    /// </returns>
    public static Either<TLeft, TRight> ToEitherRight<TLeft, TRight>(this TRight right)
    {
        return Either<TLeft, TRight>.Right(right);
    }
}