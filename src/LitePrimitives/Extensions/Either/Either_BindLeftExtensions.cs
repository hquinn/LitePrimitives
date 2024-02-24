namespace LitePrimitives;

public static class Either_BindLeftExtensions
{
    /// <summary>
    ///     Returns the result of the <paramref name="bindFunc"/> if the <paramref name="input"/> parameter is in the Left state,
    ///     otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputLeft, TInputRight}"/> with the value from the
    ///     input's Right state value.
    /// </summary>
    /// <param name="input">The input to check.</param>
    /// <param name="bindFunc">The asynchronous func to apply if <paramref name="input"/> is in the Left state.</param>
    /// <typeparam name="TInputLeft">The type of the Left <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputRight">The type of the Right <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputLeft">The type of the Left output.</typeparam>
    /// <returns>
    ///     The result of <paramref name="bindFunc"/> if <paramref name="input"/> is in the Left state,
    ///     otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputLeft, TInputRight}"/> with the value from the
    ///     input's Right state value.
    /// </returns>
    public static Either<TOutputLeft, TInputRight> BindLeft<TInputLeft, TInputRight, TOutputLeft>(
        this Either<TInputLeft, TInputRight> input,
        Func<TInputLeft, Either<TOutputLeft, TInputRight>> bindFunc)
    {
        return input.Match(
            left: l => bindFunc(l), 
            right: r => Either<TOutputLeft, TInputRight>.Right(r));
    }
    
    /// <summary>
    ///     Returns the result of the <paramref name="bindFunc"/> if the <paramref name="input"/> parameter is in the Left state,
    ///     otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputLeft, TInputRight}"/> with the value from the
    ///     input's Right state value.
    /// </summary>
    /// <param name="input">The asynchronous input to check.</param>
    /// <param name="bindFunc">The asynchronous func to apply if <paramref name="input"/> is in the Left state.</param>
    /// <typeparam name="TInputLeft">The type of the Left <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputRight">The type of the Right <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputLeft">The type of the Left output.</typeparam>
    /// <returns>
    ///     The result of <paramref name="bindFunc"/> if <paramref name="input"/> is in the Left state,
    ///     otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputLeft, TInputRight}"/> with the value from the
    ///     input's Right state value.
    /// </returns>
    public static async Task<Either<TOutputLeft, TInputRight>> BindLeftAsync<TInputLeft, TInputRight, TOutputLeft>(
        this Task<Either<TInputLeft, TInputRight>> input,
        Func<TInputLeft, Task<Either<TOutputLeft, TInputRight>>> bindFunc)
    {
        var either = await input;
      
        return await either.MatchAsync(
            left: async l => await bindFunc(l), 
            right: r => Either<TOutputLeft, TInputRight>.Right(r).ToTask());
    }
}