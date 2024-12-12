// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for Match on the Either type.
/// </summary>
public static class EitherMatchExtensions
{
    /// <summary>
    ///     Outputs the following:
    ///     - <paramref name="first"/> if in the First state.
    ///     - <paramref name="last"/> if in the Last state.
    ///     The output is of type <see cref="Task"/> of <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to match.</param>
    /// <param name="first">The asynchronous func to use if <see cref="Either{TFirst, TLast}"/> is in the First state.</param>
    /// <param name="last">The asynchronous func to use if <see cref="Either{TFirst, TLast}"/> is in the Last state.</param>
    /// <typeparam name="TFirst">The type of the First state.</typeparam>
    /// <typeparam name="TLast">The type of the Last state.</typeparam>
    /// <typeparam name="TOutput">The output of the match.</typeparam>
    /// <returns>The output of the match.</returns>
    public static async Task<TOutput> MatchAsync<TFirst, TLast, TOutput>(
        this Task<Either<TFirst, TLast>> input,
        Func<TFirst, Task<TOutput>> first,
        Func<TLast, Task<TOutput>> last)
    {
        var either = await input;
        
        return await either.MatchAsync(
            first,
            last);
    }

    /// <summary>
    ///     Outputs the following:
    ///     - <paramref name="first"/> if in the First state.
    ///     - <paramref name="last"/> if in the Last state.
    ///     The output is of type <see cref="Task"/> of <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to match.</param>
    /// <param name="first">The func to use if <see cref="Either{TFirst, TLast}"/> is in the First state.</param>
    /// <param name="last">The func to use if <see cref="Either{TFirst, TLast}"/> is in the Last state.</param>
    /// <typeparam name="TFirst">The type of the First state.</typeparam>
    /// <typeparam name="TLast">The type of the Last state.</typeparam>
    /// <typeparam name="TOutput">The output of the match.</typeparam>
    /// <returns>The output of the match.</returns>
    public static async Task<TOutput> MatchAsync<TFirst, TLast, TOutput>(
        this Task<Either<TFirst, TLast>> input,
        Func<TFirst, TOutput> first,
        Func<TLast, TOutput> last)
    {
        var either = await input;
        
        return either.Match(
            first,
            last);
    }

    /// <summary>
    ///     Outputs the following:
    ///     - <paramref name="first"/> if in the First state.
    ///     - <paramref name="second"/> if in the Second state.
    ///     - <paramref name="last"/> if in the Last state.
    ///     The output is of type <see cref="Task"/> of <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to match.</param>
    /// <param name="first">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TLast}"/> is in the First state.</param>
    /// <param name="second">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TLast}"/> is in the Second state.</param>
    /// <param name="last">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TLast}"/> is in the Last state.</param>
    /// <typeparam name="TFirst">The type of the First state.</typeparam>
    /// <typeparam name="TSecond">The type of the Second state.</typeparam>
    /// <typeparam name="TLast">The type of the Last state.</typeparam>
    /// <typeparam name="TOutput">The output of the match.</typeparam>
    /// <returns>The output of the match.</returns>
    public static async Task<TOutput> MatchAsync<TFirst, TSecond, TLast, TOutput>(
        this Task<Either<TFirst, TSecond, TLast>> input,
        Func<TFirst, Task<TOutput>> first,
        Func<TSecond, Task<TOutput>> second,
        Func<TLast, Task<TOutput>> last)
    {
        var either = await input;
        
        return await either.MatchAsync(
            first,
            second,
            last);
    }

    /// <summary>
    ///     Outputs the following:
    ///     - <paramref name="first"/> if in the First state.
    ///     - <paramref name="second"/> if in the Second state.
    ///     - <paramref name="last"/> if in the Last state.
    ///     The output is of type <see cref="Task"/> of <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to match.</param>
    /// <param name="first">The func to use if <see cref="Either{TFirst, TSecond, TLast}"/> is in the First state.</param>
    /// <param name="second">The func to use if <see cref="Either{TFirst, TSecond, TLast}"/> is in the Second state.</param>
    /// <param name="last">The func to use if <see cref="Either{TFirst, TSecond, TLast}"/> is in the Last state.</param>
    /// <typeparam name="TFirst">The type of the First state.</typeparam>
    /// <typeparam name="TSecond">The type of the Second state.</typeparam>
    /// <typeparam name="TLast">The type of the Last state.</typeparam>
    /// <typeparam name="TOutput">The output of the match.</typeparam>
    /// <returns>The output of the match.</returns>
    public static async Task<TOutput> MatchAsync<TFirst, TSecond, TLast, TOutput>(
        this Task<Either<TFirst, TSecond, TLast>> input,
        Func<TFirst, TOutput> first,
        Func<TSecond, TOutput> second,
        Func<TLast, TOutput> last)
    {
        var either = await input;
        
        return either.Match(
            first,
            second,
            last);
    }

    /// <summary>
    ///     Outputs the following:
    ///     - <paramref name="first"/> if in the First state.
    ///     - <paramref name="second"/> if in the Second state.
    ///     - <paramref name="third"/> if in the Third state.
    ///     - <paramref name="last"/> if in the Last state.
    ///     The output is of type <see cref="Task"/> of <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to match.</param>
    /// <param name="first">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TLast}"/> is in the First state.</param>
    /// <param name="second">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TLast}"/> is in the Second state.</param>
    /// <param name="third">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TLast}"/> is in the Third state.</param>
    /// <param name="last">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TLast}"/> is in the Last state.</param>
    /// <typeparam name="TFirst">The type of the First state.</typeparam>
    /// <typeparam name="TSecond">The type of the Second state.</typeparam>
    /// <typeparam name="TThird">The type of the Third state.</typeparam>
    /// <typeparam name="TLast">The type of the Last state.</typeparam>
    /// <typeparam name="TOutput">The output of the match.</typeparam>
    /// <returns>The output of the match.</returns>
    public static async Task<TOutput> MatchAsync<TFirst, TSecond, TThird, TLast, TOutput>(
        this Task<Either<TFirst, TSecond, TThird, TLast>> input,
        Func<TFirst, Task<TOutput>> first,
        Func<TSecond, Task<TOutput>> second,
        Func<TThird, Task<TOutput>> third,
        Func<TLast, Task<TOutput>> last)
    {
        var either = await input;
        
        return await either.MatchAsync(
            first,
            second,
            third,
            last);
    }

    /// <summary>
    ///     Outputs the following:
    ///     - <paramref name="first"/> if in the First state.
    ///     - <paramref name="second"/> if in the Second state.
    ///     - <paramref name="third"/> if in the Third state.
    ///     - <paramref name="last"/> if in the Last state.
    ///     The output is of type <see cref="Task"/> of <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to match.</param>
    /// <param name="first">The func to use if <see cref="Either{TFirst, TSecond, TThird, TLast}"/> is in the First state.</param>
    /// <param name="second">The func to use if <see cref="Either{TFirst, TSecond, TThird, TLast}"/> is in the Second state.</param>
    /// <param name="third">The func to use if <see cref="Either{TFirst, TSecond, TThird, TLast}"/> is in the Third state.</param>
    /// <param name="last">The func to use if <see cref="Either{TFirst, TSecond, TThird, TLast}"/> is in the Last state.</param>
    /// <typeparam name="TFirst">The type of the First state.</typeparam>
    /// <typeparam name="TSecond">The type of the Second state.</typeparam>
    /// <typeparam name="TThird">The type of the Third state.</typeparam>
    /// <typeparam name="TLast">The type of the Last state.</typeparam>
    /// <typeparam name="TOutput">The output of the match.</typeparam>
    /// <returns>The output of the match.</returns>
    public static async Task<TOutput> MatchAsync<TFirst, TSecond, TThird, TLast, TOutput>(
        this Task<Either<TFirst, TSecond, TThird, TLast>> input,
        Func<TFirst, TOutput> first,
        Func<TSecond, TOutput> second,
        Func<TThird, TOutput> third,
        Func<TLast, TOutput> last)
    {
        var either = await input;
        
        return either.Match(
            first,
            second,
            third,
            last);
    }

    /// <summary>
    ///     Outputs the following:
    ///     - <paramref name="first"/> if in the First state.
    ///     - <paramref name="second"/> if in the Second state.
    ///     - <paramref name="third"/> if in the Third state.
    ///     - <paramref name="fourth"/> if in the Fourth state.
    ///     - <paramref name="last"/> if in the Last state.
    ///     The output is of type <see cref="Task"/> of <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to match.</param>
    /// <param name="first">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> is in the First state.</param>
    /// <param name="second">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> is in the Second state.</param>
    /// <param name="third">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> is in the Third state.</param>
    /// <param name="fourth">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> is in the Fourth state.</param>
    /// <param name="last">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> is in the Last state.</param>
    /// <typeparam name="TFirst">The type of the First state.</typeparam>
    /// <typeparam name="TSecond">The type of the Second state.</typeparam>
    /// <typeparam name="TThird">The type of the Third state.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth state.</typeparam>
    /// <typeparam name="TLast">The type of the Last state.</typeparam>
    /// <typeparam name="TOutput">The output of the match.</typeparam>
    /// <returns>The output of the match.</returns>
    public static async Task<TOutput> MatchAsync<TFirst, TSecond, TThird, TFourth, TLast, TOutput>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> input,
        Func<TFirst, Task<TOutput>> first,
        Func<TSecond, Task<TOutput>> second,
        Func<TThird, Task<TOutput>> third,
        Func<TFourth, Task<TOutput>> fourth,
        Func<TLast, Task<TOutput>> last)
    {
        var either = await input;
        
        return await either.MatchAsync(
            first,
            second,
            third,
            fourth,
            last);
    }

    /// <summary>
    ///     Outputs the following:
    ///     - <paramref name="first"/> if in the First state.
    ///     - <paramref name="second"/> if in the Second state.
    ///     - <paramref name="third"/> if in the Third state.
    ///     - <paramref name="fourth"/> if in the Fourth state.
    ///     - <paramref name="last"/> if in the Last state.
    ///     The output is of type <see cref="Task"/> of <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to match.</param>
    /// <param name="first">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> is in the First state.</param>
    /// <param name="second">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> is in the Second state.</param>
    /// <param name="third">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> is in the Third state.</param>
    /// <param name="fourth">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> is in the Fourth state.</param>
    /// <param name="last">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> is in the Last state.</param>
    /// <typeparam name="TFirst">The type of the First state.</typeparam>
    /// <typeparam name="TSecond">The type of the Second state.</typeparam>
    /// <typeparam name="TThird">The type of the Third state.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth state.</typeparam>
    /// <typeparam name="TLast">The type of the Last state.</typeparam>
    /// <typeparam name="TOutput">The output of the match.</typeparam>
    /// <returns>The output of the match.</returns>
    public static async Task<TOutput> MatchAsync<TFirst, TSecond, TThird, TFourth, TLast, TOutput>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> input,
        Func<TFirst, TOutput> first,
        Func<TSecond, TOutput> second,
        Func<TThird, TOutput> third,
        Func<TFourth, TOutput> fourth,
        Func<TLast, TOutput> last)
    {
        var either = await input;
        
        return either.Match(
            first,
            second,
            third,
            fourth,
            last);
    }

    /// <summary>
    ///     Outputs the following:
    ///     - <paramref name="first"/> if in the First state.
    ///     - <paramref name="second"/> if in the Second state.
    ///     - <paramref name="third"/> if in the Third state.
    ///     - <paramref name="fourth"/> if in the Fourth state.
    ///     - <paramref name="fifth"/> if in the Fifth state.
    ///     - <paramref name="last"/> if in the Last state.
    ///     The output is of type <see cref="Task"/> of <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to match.</param>
    /// <param name="first">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TLast}"/> is in the First state.</param>
    /// <param name="second">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TLast}"/> is in the Second state.</param>
    /// <param name="third">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TLast}"/> is in the Third state.</param>
    /// <param name="fourth">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TLast}"/> is in the Fourth state.</param>
    /// <param name="fifth">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TLast}"/> is in the Fifth state.</param>
    /// <param name="last">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TLast}"/> is in the Last state.</param>
    /// <typeparam name="TFirst">The type of the First state.</typeparam>
    /// <typeparam name="TSecond">The type of the Second state.</typeparam>
    /// <typeparam name="TThird">The type of the Third state.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth state.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth state.</typeparam>
    /// <typeparam name="TLast">The type of the Last state.</typeparam>
    /// <typeparam name="TOutput">The output of the match.</typeparam>
    /// <returns>The output of the match.</returns>
    public static async Task<TOutput> MatchAsync<TFirst, TSecond, TThird, TFourth, TFifth, TLast, TOutput>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> input,
        Func<TFirst, Task<TOutput>> first,
        Func<TSecond, Task<TOutput>> second,
        Func<TThird, Task<TOutput>> third,
        Func<TFourth, Task<TOutput>> fourth,
        Func<TFifth, Task<TOutput>> fifth,
        Func<TLast, Task<TOutput>> last)
    {
        var either = await input;
        
        return await either.MatchAsync(
            first,
            second,
            third,
            fourth,
            fifth,
            last);
    }

    /// <summary>
    ///     Outputs the following:
    ///     - <paramref name="first"/> if in the First state.
    ///     - <paramref name="second"/> if in the Second state.
    ///     - <paramref name="third"/> if in the Third state.
    ///     - <paramref name="fourth"/> if in the Fourth state.
    ///     - <paramref name="fifth"/> if in the Fifth state.
    ///     - <paramref name="last"/> if in the Last state.
    ///     The output is of type <see cref="Task"/> of <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to match.</param>
    /// <param name="first">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TLast}"/> is in the First state.</param>
    /// <param name="second">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TLast}"/> is in the Second state.</param>
    /// <param name="third">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TLast}"/> is in the Third state.</param>
    /// <param name="fourth">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TLast}"/> is in the Fourth state.</param>
    /// <param name="fifth">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TLast}"/> is in the Fifth state.</param>
    /// <param name="last">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TLast}"/> is in the Last state.</param>
    /// <typeparam name="TFirst">The type of the First state.</typeparam>
    /// <typeparam name="TSecond">The type of the Second state.</typeparam>
    /// <typeparam name="TThird">The type of the Third state.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth state.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth state.</typeparam>
    /// <typeparam name="TLast">The type of the Last state.</typeparam>
    /// <typeparam name="TOutput">The output of the match.</typeparam>
    /// <returns>The output of the match.</returns>
    public static async Task<TOutput> MatchAsync<TFirst, TSecond, TThird, TFourth, TFifth, TLast, TOutput>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> input,
        Func<TFirst, TOutput> first,
        Func<TSecond, TOutput> second,
        Func<TThird, TOutput> third,
        Func<TFourth, TOutput> fourth,
        Func<TFifth, TOutput> fifth,
        Func<TLast, TOutput> last)
    {
        var either = await input;
        
        return either.Match(
            first,
            second,
            third,
            fourth,
            fifth,
            last);
    }

    /// <summary>
    ///     Outputs the following:
    ///     - <paramref name="first"/> if in the First state.
    ///     - <paramref name="second"/> if in the Second state.
    ///     - <paramref name="third"/> if in the Third state.
    ///     - <paramref name="fourth"/> if in the Fourth state.
    ///     - <paramref name="fifth"/> if in the Fifth state.
    ///     - <paramref name="sixth"/> if in the Sixth state.
    ///     - <paramref name="last"/> if in the Last state.
    ///     The output is of type <see cref="Task"/> of <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to match.</param>
    /// <param name="first">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast}"/> is in the First state.</param>
    /// <param name="second">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast}"/> is in the Second state.</param>
    /// <param name="third">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast}"/> is in the Third state.</param>
    /// <param name="fourth">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast}"/> is in the Fourth state.</param>
    /// <param name="fifth">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast}"/> is in the Fifth state.</param>
    /// <param name="sixth">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast}"/> is in the Sixth state.</param>
    /// <param name="last">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast}"/> is in the Last state.</param>
    /// <typeparam name="TFirst">The type of the First state.</typeparam>
    /// <typeparam name="TSecond">The type of the Second state.</typeparam>
    /// <typeparam name="TThird">The type of the Third state.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth state.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth state.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth state.</typeparam>
    /// <typeparam name="TLast">The type of the Last state.</typeparam>
    /// <typeparam name="TOutput">The output of the match.</typeparam>
    /// <returns>The output of the match.</returns>
    public static async Task<TOutput> MatchAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast, TOutput>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> input,
        Func<TFirst, Task<TOutput>> first,
        Func<TSecond, Task<TOutput>> second,
        Func<TThird, Task<TOutput>> third,
        Func<TFourth, Task<TOutput>> fourth,
        Func<TFifth, Task<TOutput>> fifth,
        Func<TSixth, Task<TOutput>> sixth,
        Func<TLast, Task<TOutput>> last)
    {
        var either = await input;
        
        return await either.MatchAsync(
            first,
            second,
            third,
            fourth,
            fifth,
            sixth,
            last);
    }

    /// <summary>
    ///     Outputs the following:
    ///     - <paramref name="first"/> if in the First state.
    ///     - <paramref name="second"/> if in the Second state.
    ///     - <paramref name="third"/> if in the Third state.
    ///     - <paramref name="fourth"/> if in the Fourth state.
    ///     - <paramref name="fifth"/> if in the Fifth state.
    ///     - <paramref name="sixth"/> if in the Sixth state.
    ///     - <paramref name="last"/> if in the Last state.
    ///     The output is of type <see cref="Task"/> of <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to match.</param>
    /// <param name="first">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast}"/> is in the First state.</param>
    /// <param name="second">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast}"/> is in the Second state.</param>
    /// <param name="third">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast}"/> is in the Third state.</param>
    /// <param name="fourth">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast}"/> is in the Fourth state.</param>
    /// <param name="fifth">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast}"/> is in the Fifth state.</param>
    /// <param name="sixth">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast}"/> is in the Sixth state.</param>
    /// <param name="last">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast}"/> is in the Last state.</param>
    /// <typeparam name="TFirst">The type of the First state.</typeparam>
    /// <typeparam name="TSecond">The type of the Second state.</typeparam>
    /// <typeparam name="TThird">The type of the Third state.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth state.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth state.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth state.</typeparam>
    /// <typeparam name="TLast">The type of the Last state.</typeparam>
    /// <typeparam name="TOutput">The output of the match.</typeparam>
    /// <returns>The output of the match.</returns>
    public static async Task<TOutput> MatchAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast, TOutput>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> input,
        Func<TFirst, TOutput> first,
        Func<TSecond, TOutput> second,
        Func<TThird, TOutput> third,
        Func<TFourth, TOutput> fourth,
        Func<TFifth, TOutput> fifth,
        Func<TSixth, TOutput> sixth,
        Func<TLast, TOutput> last)
    {
        var either = await input;
        
        return either.Match(
            first,
            second,
            third,
            fourth,
            fifth,
            sixth,
            last);
    }

    /// <summary>
    ///     Outputs the following:
    ///     - <paramref name="first"/> if in the First state.
    ///     - <paramref name="second"/> if in the Second state.
    ///     - <paramref name="third"/> if in the Third state.
    ///     - <paramref name="fourth"/> if in the Fourth state.
    ///     - <paramref name="fifth"/> if in the Fifth state.
    ///     - <paramref name="sixth"/> if in the Sixth state.
    ///     - <paramref name="seventh"/> if in the Seventh state.
    ///     - <paramref name="last"/> if in the Last state.
    ///     The output is of type <see cref="Task"/> of <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to match.</param>
    /// <param name="first">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> is in the First state.</param>
    /// <param name="second">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> is in the Second state.</param>
    /// <param name="third">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> is in the Third state.</param>
    /// <param name="fourth">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> is in the Fourth state.</param>
    /// <param name="fifth">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> is in the Fifth state.</param>
    /// <param name="sixth">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> is in the Sixth state.</param>
    /// <param name="seventh">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> is in the Seventh state.</param>
    /// <param name="last">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> is in the Last state.</param>
    /// <typeparam name="TFirst">The type of the First state.</typeparam>
    /// <typeparam name="TSecond">The type of the Second state.</typeparam>
    /// <typeparam name="TThird">The type of the Third state.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth state.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth state.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth state.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh state.</typeparam>
    /// <typeparam name="TLast">The type of the Last state.</typeparam>
    /// <typeparam name="TOutput">The output of the match.</typeparam>
    /// <returns>The output of the match.</returns>
    public static async Task<TOutput> MatchAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast, TOutput>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Func<TFirst, Task<TOutput>> first,
        Func<TSecond, Task<TOutput>> second,
        Func<TThird, Task<TOutput>> third,
        Func<TFourth, Task<TOutput>> fourth,
        Func<TFifth, Task<TOutput>> fifth,
        Func<TSixth, Task<TOutput>> sixth,
        Func<TSeventh, Task<TOutput>> seventh,
        Func<TLast, Task<TOutput>> last)
    {
        var either = await input;
        
        return await either.MatchAsync(
            first,
            second,
            third,
            fourth,
            fifth,
            sixth,
            seventh,
            last);
    }

    /// <summary>
    ///     Outputs the following:
    ///     - <paramref name="first"/> if in the First state.
    ///     - <paramref name="second"/> if in the Second state.
    ///     - <paramref name="third"/> if in the Third state.
    ///     - <paramref name="fourth"/> if in the Fourth state.
    ///     - <paramref name="fifth"/> if in the Fifth state.
    ///     - <paramref name="sixth"/> if in the Sixth state.
    ///     - <paramref name="seventh"/> if in the Seventh state.
    ///     - <paramref name="last"/> if in the Last state.
    ///     The output is of type <see cref="Task"/> of <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to match.</param>
    /// <param name="first">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> is in the First state.</param>
    /// <param name="second">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> is in the Second state.</param>
    /// <param name="third">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> is in the Third state.</param>
    /// <param name="fourth">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> is in the Fourth state.</param>
    /// <param name="fifth">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> is in the Fifth state.</param>
    /// <param name="sixth">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> is in the Sixth state.</param>
    /// <param name="seventh">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> is in the Seventh state.</param>
    /// <param name="last">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> is in the Last state.</param>
    /// <typeparam name="TFirst">The type of the First state.</typeparam>
    /// <typeparam name="TSecond">The type of the Second state.</typeparam>
    /// <typeparam name="TThird">The type of the Third state.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth state.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth state.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth state.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh state.</typeparam>
    /// <typeparam name="TLast">The type of the Last state.</typeparam>
    /// <typeparam name="TOutput">The output of the match.</typeparam>
    /// <returns>The output of the match.</returns>
    public static async Task<TOutput> MatchAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast, TOutput>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Func<TFirst, TOutput> first,
        Func<TSecond, TOutput> second,
        Func<TThird, TOutput> third,
        Func<TFourth, TOutput> fourth,
        Func<TFifth, TOutput> fifth,
        Func<TSixth, TOutput> sixth,
        Func<TSeventh, TOutput> seventh,
        Func<TLast, TOutput> last)
    {
        var either = await input;
        
        return either.Match(
            first,
            second,
            third,
            fourth,
            fifth,
            sixth,
            seventh,
            last);
    }
}