namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for BindRight on the Either type.
/// </summary>
public static class Either_BindRightExtensions
{
    /// <summary>
    ///     Returns the result of the <paramref name="bindFunc"/> if the <paramref name="input"/> parameter is in the Right state,
    ///     otherwise returns <see cref="Task"/> of type <see cref="Either{TInputLeft, TOutputRight}"/> with the value from the
    ///     input's Left state value.
    /// </summary>
    /// <param name="input">The input to check.</param>
    /// <param name="bindFunc">The asynchronous func to apply if <paramref name="input"/> is in the Right state.</param>
    /// <typeparam name="TInputLeft">The type of the Left <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputRight">The type of the Right <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputRight">The type of the Right output.</typeparam>
    /// <returns>
    ///     The result of <paramref name="bindFunc"/> if <paramref name="input"/> is in the Right state,
    ///     otherwise returns <see cref="Task"/> of type <see cref="Either{TInputLeft, TOutputRight}"/> with the value from the
    ///     input's Left state value.
    /// </returns>
    public static Either<TInputLeft, TOutputRight> BindRight<TInputLeft, TInputRight, TOutputRight>(
        this Either<TInputLeft, TInputRight> input,
        Func<TInputRight, Either<TInputLeft, TOutputRight>> bindFunc)
    {
        return input.Match(
            left: l => Either<TInputLeft, TOutputRight>.Left(l), 
            right: r => bindFunc(r));
    }
    
    /// <summary>
    ///     Returns the result of the <paramref name="bindFunc"/> if the <paramref name="input"/> parameter is in the Right state,
    ///     otherwise returns <see cref="Task"/> of type <see cref="Either{TInputLeft, TOutputRight}"/> with the value from the
    ///     input's Left state value.
    /// </summary>
    /// <param name="input">The asynchronous input to check.</param>
    /// <param name="bindFunc">The asynchronous func to apply if <paramref name="input"/> is in the Right state.</param>
    /// <typeparam name="TInputLeft">The type of the Left <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputRight">The type of the Right <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputRight">The type of the Right output.</typeparam>
    /// <returns>
    ///     The result of <paramref name="bindFunc"/> if <paramref name="input"/> is in the Right state,
    ///     otherwise returns <see cref="Task"/> of type <see cref="Either{TInputLeft, TOutputRight}"/> with the value from the
    ///     input's Left state value.
    /// </returns>
    public static async Task<Either<TInputLeft, TOutputRight>> BindRightAsync<TInputLeft, TInputRight, TOutputRight>(
        this Task<Either<TInputLeft, TInputRight>> input,
        Func<TInputRight, Task<Either<TInputLeft, TOutputRight>>> bindFunc)
    {
        var either = await input;
      
        return await either.MatchAsync(
            left: l => Either<TInputLeft, TOutputRight>.Left(l).ToTask(), 
            right: async r => await bindFunc(r));
    }
}