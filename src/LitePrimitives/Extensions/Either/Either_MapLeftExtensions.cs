namespace LitePrimitives;

public static class Either_MapLeftExtensions
{
    /// <summary>
    ///     Transforms the <paramref name="input"/> when it's in a Left state into <see cref="Either{TInputLeft, TOutputLeft}"/>,
    ///     otherwise returns <see cref="Either{TInputLeft, TOutputLeft}"/> with the value from the
    ///     input's Right state value.
    /// </summary>
    /// <param name="input">The input to transform.</param>
    /// <param name="transform">The function to transform the <paramref name="input"/> to <typeparamref name="TOutputLeft"/>.</param>
    /// <typeparam name="TInputLeft">The type of the Left <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputRight">The type of the Right <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputLeft">The type of the transformed Left output.</typeparam>
    /// <returns>
    ///	   The result of <paramref name="transform"/> if <paramref name="input"/> is in the Left state,
    ///		otherwise returns <see cref="Either{TInputLeft, TOutputLeft}"/> with the value from the
    ///      input's Right state value.
    /// </returns>
    public static Either<TOutputLeft, TInputRight> MapLeft<TInputLeft, TInputRight, TOutputLeft>(
        this Either<TInputLeft, TInputRight> input,
        Func<TInputLeft, TOutputLeft> transform)
    {
        return input.Match(
            left: l => Either<TOutputLeft, TInputRight>.Left(transform(l)), 
            right: r => Either<TOutputLeft, TInputRight>.Right(r));
    }

    /// <summary>
    ///     Transforms the <paramref name="input"/> when it's in a Left state into <see cref="Either{TInputLeft, TOutputLeft}"/>,
    ///     otherwise returns <see cref="Task"/> of type <see cref="Either{TInputLeft, TOutputLeft}"/> with the value from the
    ///     input's Right state value.
    /// </summary>
    /// <param name="input">The input to transform.</param>
    /// <param name="transform">The asynchronous function to transform the <paramref name="input"/> to <typeparamref name="TOutputLeft"/>.</param>
    /// <typeparam name="TInputLeft">The type of the Left <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputRight">The type of the Right <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputLeft">The type of the transformed Left output.</typeparam>
    /// <returns>
    ///	   The result of <paramref name="transform"/> if <paramref name="input"/> is in the Left state,
    ///		otherwise returns <see cref="Task"/> of type <see cref="Either{TInputLeft, TOutputLeft}"/> with the value from the
    ///      input's Right state value.
    /// </returns>
    public static async Task<Either<TOutputLeft, TInputRight>> MapLeftAsync<TInputLeft, TInputRight, TOutputLeft>(
        this Either<TInputLeft, TInputRight> input,
        Func<TInputLeft, Task<TOutputLeft>> transform)
    {
        return await input.MatchAsync(
            left: async l => Either<TOutputLeft, TInputRight>.Left(await transform(l)), 
            right: r => Either<TOutputLeft, TInputRight>.Right(r).ToTask());
    }

    /// <summary>
    ///     Transforms the <paramref name="input"/> when it's in a Left state into <see cref="Either{TInputLeft, TOutputLeft}"/>,
    ///     otherwise returns <see cref="Task"/> of type <see cref="Either{TInputLeft, TOutputLeft}"/> with the value from the
    ///     input's Right state value.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The asynchronous function to transform the <paramref name="input"/> to <typeparamref name="TOutputLeft"/>.</param>
    /// <typeparam name="TInputLeft">The type of the Left <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputRight">The type of the Right <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputLeft">The type of the transformed Left output.</typeparam>
    /// <returns>
    ///	   The result of <paramref name="transform"/> if <paramref name="input"/> is in the Left state,
    ///		otherwise returns <see cref="Task"/> of type <see cref="Either{TInputLeft, TOutputLeft}"/> with the value from the
    ///      input's Right state value.
    /// </returns>
    public static async Task<Either<TOutputLeft, TInputRight>> MapLeftAsync<TInputLeft, TInputRight, TOutputLeft>(
        this Task<Either<TInputLeft, TInputRight>> input,
        Func<TInputLeft, Task<TOutputLeft>> transform)
    {
        var either = await input;
      
        return await either.MatchAsync(
            left: async l => Either<TOutputLeft, TInputRight>.Left(await transform(l)), 
            right: r => Either<TOutputLeft, TInputRight>.Right(r).ToTask());
    }
}