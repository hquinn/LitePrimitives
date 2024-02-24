namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for MapRight on the Either type.
/// </summary>
public static class Either_MapRightExtensions
{
    /// <summary>
    ///     Transforms the <paramref name="input"/> when it's in a Right state into <see cref="Either{TInputLeft, TOutputRight}"/>,
    ///     otherwise returns <see cref="Either{TInputLeft, TOutputRight}"/> with the value from the
    ///     input's Left state value.
    /// </summary>
    /// <param name="input">The input to transform.</param>
    /// <param name="transform">The function to transform the <paramref name="input"/> to <typeparamref name="TOutputRight"/>.</param>
    /// <typeparam name="TInputLeft">The type of the Left <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputRight">The type of the Right <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputRight">The type of the transformed Right output.</typeparam>
    /// <returns>
    ///	   The result of <paramref name="transform"/> if <paramref name="input"/> is in the Right state,
    ///		otherwise returns <see cref="Either{TInputLeft, TOutputRight}"/> with the value from the
    ///      input's Left state value.
    /// </returns>
    public static Either<TInputLeft, TOutputRight> MapRight<TInputLeft, TInputRight, TOutputRight>(
        this Either<TInputLeft, TInputRight> input,
        Func<TInputRight, TOutputRight> transform)
    {
        return input.Match(
            left: l => Either<TInputLeft, TOutputRight>.Left(l), 
            right: r => Either<TInputLeft, TOutputRight>.Right(transform(r)));
    }

    /// <summary>
    ///     Transforms the <paramref name="input"/> when it's in a Right state into <see cref="Either{TInputLeft, TOutputRight}"/>,
    ///     otherwise returns <see cref="Task"/> of type <see cref="Either{TInputLeft, TOutputRight}"/> with the value from the
    ///     input's Left state value.
    /// </summary>
    /// <param name="input">The input to transform.</param>
    /// <param name="transform">The asynchronous function to transform the <paramref name="input"/> to <typeparamref name="TOutputRight"/>.</param>
    /// <typeparam name="TInputLeft">The type of the Left <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputRight">The type of the Right <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputRight">The type of the transformed Right output.</typeparam>
    /// <returns>
    ///	   The result of <paramref name="transform"/> if <paramref name="input"/> is in the Right state,
    ///		otherwise returns <see cref="Task"/> of type <see cref="Either{TInputLeft, TOutputRight}"/> with the value from the
    ///      input's Left state value.
    /// </returns>
    public static async Task<Either<TInputLeft, TOutputRight>> MapRightAsync<TInputLeft, TInputRight, TOutputRight>(
        this Either<TInputLeft, TInputRight> input,
        Func<TInputRight, Task<TOutputRight>> transform)
    {
        return await input.MatchAsync(
            left: l => Either<TInputLeft, TOutputRight>.Left(l).ToTask(), 
            right: async r => Either<TInputLeft, TOutputRight>.Right(await transform(r)));
    }

    /// <summary>
    ///     Transforms the <paramref name="input"/> when it's in a Right state into <see cref="Either{TInputLeft, TOutputRight}"/>,
    ///     otherwise returns <see cref="Task"/> of type <see cref="Either{TInputLeft, TOutputRight}"/> with the value from the
    ///     input's Left state value.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The asynchronous function to transform the <paramref name="input"/> to <typeparamref name="TOutputRight"/>.</param>
    /// <typeparam name="TInputLeft">The type of the Left <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputRight">The type of the Right <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputRight">The type of the transformed Right output.</typeparam>
    /// <returns>
    ///	   The result of <paramref name="transform"/> if <paramref name="input"/> is in the Right state,
    ///		otherwise returns <see cref="Task"/> of type <see cref="Either{TInputLeft, TOutputRight}"/> with the value from the
    ///      input's Left state value.
    /// </returns>
    public static async Task<Either<TInputLeft, TOutputRight>> MapRightAsync<TInputLeft, TInputRight, TOutputRight>(
        this Task<Either<TInputLeft, TInputRight>> input,
        Func<TInputRight, Task<TOutputRight>> transform)
    {
        var either = await input;
      
        return await either.MatchAsync(
            left: l => Either<TInputLeft, TOutputRight>.Left(l).ToTask(), 
            right: async r => Either<TInputLeft, TOutputRight>.Right(await transform(r)));
    }
}