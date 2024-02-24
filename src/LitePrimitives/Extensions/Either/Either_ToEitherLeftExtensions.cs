namespace LitePrimitives;

public static class Either_ToEitherLeftExtensions
{
    /// <summary>
    ///     Converts the <paramref name="left"/> parameter to an <see cref="Either{TLeft, TRight}"/> in the Left state.
    /// </summary>
    /// <param name="left">The parameter to convert.</param>
    /// <typeparam name="TLeft">
    ///     The type of the <paramref name="left"/> parameter and the return type for <see cref="Either{TLeft, TRight}"/>.
    /// </typeparam>
    /// <typeparam name="TRight">
    ///     Part of the return type for <see cref="Either{TLeft, TRight}"/>.
    /// </typeparam>
    /// <returns>
    ///     The <paramref name="left"/> parameter after converting it to <see cref="Either{TLeft, TRight}"/> in the Left state.
    /// </returns>
    public static Either<TLeft, TRight> ToEitherLeft<TLeft, TRight>(this TLeft left)
    {
        return Either<TLeft, TRight>.Left(left);
    }
}