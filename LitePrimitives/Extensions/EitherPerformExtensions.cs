// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for Perform on the Either type.
/// </summary>
public static class EitherPerformExtensions
{
    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="first">The action to perform if in the First state.</param>
    /// <param name="last">The action to perform if in the Last state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Either<TFirst, TLast>> PerformAsync<TFirst, TLast>(
        this Task<Either<TFirst, TLast>> input,
        Action<TFirst>? first = null,
        Action<TLast>? last = null)
    {
        var either = await input;
        
        return either.Perform(
            first,
            last);
    }
    
    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="first">The action to perform if in the First state.</param>
    /// <param name="last">The action to perform if in the Last state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Either<TFirst, TLast>> PerformAsync<TFirst, TLast>(
        this Task<Either<TFirst, TLast>> input,
        Func<TFirst, Unit>? first = null,
        Func<TLast, Unit>? last = null)
    {
        var either = await input;
        
        return either.Perform(
            first,
            last);
    }

    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="first">The asynchronous action to perform if in the First state.</param>
    /// <param name="last">The asynchronous action to perform if in the Last state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Either<TFirst, TLast>> PerformAsync<TFirst, TLast>(
        this Task<Either<TFirst, TLast>> input,
        Func<TFirst, Task>? first = null,
        Func<TLast, Task>? last = null)
    {
        var either = await input;
        
        return await either.PerformAsync(
            first,
            last);
    }

    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="first">The asynchronous action to perform if in the First state.</param>
    /// <param name="last">The asynchronous action to perform if in the Last state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Either<TFirst, TLast>> PerformAsync<TFirst, TLast>(
        this Task<Either<TFirst, TLast>> input,
        Func<TFirst, Task<Unit>>? first = null,
        Func<TLast, Task<Unit>>? last = null)
    {
        var either = await input;
        
        return await either.PerformAsync(
            first,
            last);
    }

    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="first">The action to perform if in the First state.</param>
    /// <param name="second">The action to perform if in the Second state.</param>
    /// <param name="last">The action to perform if in the Last state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Either<TFirst, TSecond, TLast>> PerformAsync<TFirst, TSecond, TLast>(
        this Task<Either<TFirst, TSecond, TLast>> input,
        Action<TFirst>? first = null,
        Action<TSecond>? second = null,
        Action<TLast>? last = null)
    {
        var either = await input;
        
        return either.Perform(
            first,
            second,
            last);
    }
    
    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="first">The action to perform if in the First state.</param>
    /// <param name="second">The action to perform if in the Second state.</param>
    /// <param name="last">The action to perform if in the Last state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Either<TFirst, TSecond, TLast>> PerformAsync<TFirst, TSecond, TLast>(
        this Task<Either<TFirst, TSecond, TLast>> input,
        Func<TFirst, Unit>? first = null,
        Func<TSecond, Unit>? second = null,
        Func<TLast, Unit>? last = null)
    {
        var either = await input;
        
        return either.Perform(
            first,
            second,
            last);
    }

    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="first">The asynchronous action to perform if in the First state.</param>
    /// <param name="second">The asynchronous action to perform if in the Second state.</param>
    /// <param name="last">The asynchronous action to perform if in the Last state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Either<TFirst, TSecond, TLast>> PerformAsync<TFirst, TSecond, TLast>(
        this Task<Either<TFirst, TSecond, TLast>> input,
        Func<TFirst, Task>? first = null,
        Func<TSecond, Task>? second = null,
        Func<TLast, Task>? last = null)
    {
        var either = await input;
        
        return await either.PerformAsync(
            first,
            second,
            last);
    }

    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="first">The asynchronous action to perform if in the First state.</param>
    /// <param name="second">The asynchronous action to perform if in the Second state.</param>
    /// <param name="last">The asynchronous action to perform if in the Last state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Either<TFirst, TSecond, TLast>> PerformAsync<TFirst, TSecond, TLast>(
        this Task<Either<TFirst, TSecond, TLast>> input,
        Func<TFirst, Task<Unit>>? first = null,
        Func<TSecond, Task<Unit>>? second = null,
        Func<TLast, Task<Unit>>? last = null)
    {
        var either = await input;
        
        return await either.PerformAsync(
            first,
            second,
            last);
    }

    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="first">The action to perform if in the First state.</param>
    /// <param name="second">The action to perform if in the Second state.</param>
    /// <param name="third">The action to perform if in the Third state.</param>
    /// <param name="last">The action to perform if in the Last state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TLast>> PerformAsync<TFirst, TSecond, TThird, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TLast>> input,
        Action<TFirst>? first = null,
        Action<TSecond>? second = null,
        Action<TThird>? third = null,
        Action<TLast>? last = null)
    {
        var either = await input;
        
        return either.Perform(
            first,
            second,
            third,
            last);
    }
    
    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="first">The action to perform if in the First state.</param>
    /// <param name="second">The action to perform if in the Second state.</param>
    /// <param name="third">The action to perform if in the Third state.</param>
    /// <param name="last">The action to perform if in the Last state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TLast>> PerformAsync<TFirst, TSecond, TThird, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TLast>> input,
        Func<TFirst, Unit>? first = null,
        Func<TSecond, Unit>? second = null,
        Func<TThird, Unit>? third = null,
        Func<TLast, Unit>? last = null)
    {
        var either = await input;
        
        return either.Perform(
            first,
            second,
            third,
            last);
    }

    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="first">The asynchronous action to perform if in the First state.</param>
    /// <param name="second">The asynchronous action to perform if in the Second state.</param>
    /// <param name="third">The asynchronous action to perform if in the Third state.</param>
    /// <param name="last">The asynchronous action to perform if in the Last state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TLast>> PerformAsync<TFirst, TSecond, TThird, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TLast>> input,
        Func<TFirst, Task>? first = null,
        Func<TSecond, Task>? second = null,
        Func<TThird, Task>? third = null,
        Func<TLast, Task>? last = null)
    {
        var either = await input;
        
        return await either.PerformAsync(
            first,
            second,
            third,
            last);
    }

    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="first">The asynchronous action to perform if in the First state.</param>
    /// <param name="second">The asynchronous action to perform if in the Second state.</param>
    /// <param name="third">The asynchronous action to perform if in the Third state.</param>
    /// <param name="last">The asynchronous action to perform if in the Last state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TLast>> PerformAsync<TFirst, TSecond, TThird, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TLast>> input,
        Func<TFirst, Task<Unit>>? first = null,
        Func<TSecond, Task<Unit>>? second = null,
        Func<TThird, Task<Unit>>? third = null,
        Func<TLast, Task<Unit>>? last = null)
    {
        var either = await input;
        
        return await either.PerformAsync(
            first,
            second,
            third,
            last);
    }

    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="first">The action to perform if in the First state.</param>
    /// <param name="second">The action to perform if in the Second state.</param>
    /// <param name="third">The action to perform if in the Third state.</param>
    /// <param name="fourth">The action to perform if in the Fourth state.</param>
    /// <param name="last">The action to perform if in the Last state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> PerformAsync<TFirst, TSecond, TThird, TFourth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> input,
        Action<TFirst>? first = null,
        Action<TSecond>? second = null,
        Action<TThird>? third = null,
        Action<TFourth>? fourth = null,
        Action<TLast>? last = null)
    {
        var either = await input;
        
        return either.Perform(
            first,
            second,
            third,
            fourth,
            last);
    }
    
    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="first">The action to perform if in the First state.</param>
    /// <param name="second">The action to perform if in the Second state.</param>
    /// <param name="third">The action to perform if in the Third state.</param>
    /// <param name="fourth">The action to perform if in the Fourth state.</param>
    /// <param name="last">The action to perform if in the Last state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> PerformAsync<TFirst, TSecond, TThird, TFourth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> input,
        Func<TFirst, Unit>? first = null,
        Func<TSecond, Unit>? second = null,
        Func<TThird, Unit>? third = null,
        Func<TFourth, Unit>? fourth = null,
        Func<TLast, Unit>? last = null)
    {
        var either = await input;
        
        return either.Perform(
            first,
            second,
            third,
            fourth,
            last);
    }

    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="first">The asynchronous action to perform if in the First state.</param>
    /// <param name="second">The asynchronous action to perform if in the Second state.</param>
    /// <param name="third">The asynchronous action to perform if in the Third state.</param>
    /// <param name="fourth">The asynchronous action to perform if in the Fourth state.</param>
    /// <param name="last">The asynchronous action to perform if in the Last state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> PerformAsync<TFirst, TSecond, TThird, TFourth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> input,
        Func<TFirst, Task>? first = null,
        Func<TSecond, Task>? second = null,
        Func<TThird, Task>? third = null,
        Func<TFourth, Task>? fourth = null,
        Func<TLast, Task>? last = null)
    {
        var either = await input;
        
        return await either.PerformAsync(
            first,
            second,
            third,
            fourth,
            last);
    }

    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="first">The asynchronous action to perform if in the First state.</param>
    /// <param name="second">The asynchronous action to perform if in the Second state.</param>
    /// <param name="third">The asynchronous action to perform if in the Third state.</param>
    /// <param name="fourth">The asynchronous action to perform if in the Fourth state.</param>
    /// <param name="last">The asynchronous action to perform if in the Last state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> PerformAsync<TFirst, TSecond, TThird, TFourth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> input,
        Func<TFirst, Task<Unit>>? first = null,
        Func<TSecond, Task<Unit>>? second = null,
        Func<TThird, Task<Unit>>? third = null,
        Func<TFourth, Task<Unit>>? fourth = null,
        Func<TLast, Task<Unit>>? last = null)
    {
        var either = await input;
        
        return await either.PerformAsync(
            first,
            second,
            third,
            fourth,
            last);
    }

    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="first">The action to perform if in the First state.</param>
    /// <param name="second">The action to perform if in the Second state.</param>
    /// <param name="third">The action to perform if in the Third state.</param>
    /// <param name="fourth">The action to perform if in the Fourth state.</param>
    /// <param name="fifth">The action to perform if in the Fifth state.</param>
    /// <param name="last">The action to perform if in the Last state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> PerformAsync<TFirst, TSecond, TThird, TFourth, TFifth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> input,
        Action<TFirst>? first = null,
        Action<TSecond>? second = null,
        Action<TThird>? third = null,
        Action<TFourth>? fourth = null,
        Action<TFifth>? fifth = null,
        Action<TLast>? last = null)
    {
        var either = await input;
        
        return either.Perform(
            first,
            second,
            third,
            fourth,
            fifth,
            last);
    }
    
    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="first">The action to perform if in the First state.</param>
    /// <param name="second">The action to perform if in the Second state.</param>
    /// <param name="third">The action to perform if in the Third state.</param>
    /// <param name="fourth">The action to perform if in the Fourth state.</param>
    /// <param name="fifth">The action to perform if in the Fifth state.</param>
    /// <param name="last">The action to perform if in the Last state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> PerformAsync<TFirst, TSecond, TThird, TFourth, TFifth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> input,
        Func<TFirst, Unit>? first = null,
        Func<TSecond, Unit>? second = null,
        Func<TThird, Unit>? third = null,
        Func<TFourth, Unit>? fourth = null,
        Func<TFifth, Unit>? fifth = null,
        Func<TLast, Unit>? last = null)
    {
        var either = await input;
        
        return either.Perform(
            first,
            second,
            third,
            fourth,
            fifth,
            last);
    }

    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="first">The asynchronous action to perform if in the First state.</param>
    /// <param name="second">The asynchronous action to perform if in the Second state.</param>
    /// <param name="third">The asynchronous action to perform if in the Third state.</param>
    /// <param name="fourth">The asynchronous action to perform if in the Fourth state.</param>
    /// <param name="fifth">The asynchronous action to perform if in the Fifth state.</param>
    /// <param name="last">The asynchronous action to perform if in the Last state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> PerformAsync<TFirst, TSecond, TThird, TFourth, TFifth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> input,
        Func<TFirst, Task>? first = null,
        Func<TSecond, Task>? second = null,
        Func<TThird, Task>? third = null,
        Func<TFourth, Task>? fourth = null,
        Func<TFifth, Task>? fifth = null,
        Func<TLast, Task>? last = null)
    {
        var either = await input;
        
        return await either.PerformAsync(
            first,
            second,
            third,
            fourth,
            fifth,
            last);
    }

    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="first">The asynchronous action to perform if in the First state.</param>
    /// <param name="second">The asynchronous action to perform if in the Second state.</param>
    /// <param name="third">The asynchronous action to perform if in the Third state.</param>
    /// <param name="fourth">The asynchronous action to perform if in the Fourth state.</param>
    /// <param name="fifth">The asynchronous action to perform if in the Fifth state.</param>
    /// <param name="last">The asynchronous action to perform if in the Last state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> PerformAsync<TFirst, TSecond, TThird, TFourth, TFifth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> input,
        Func<TFirst, Task<Unit>>? first = null,
        Func<TSecond, Task<Unit>>? second = null,
        Func<TThird, Task<Unit>>? third = null,
        Func<TFourth, Task<Unit>>? fourth = null,
        Func<TFifth, Task<Unit>>? fifth = null,
        Func<TLast, Task<Unit>>? last = null)
    {
        var either = await input;
        
        return await either.PerformAsync(
            first,
            second,
            third,
            fourth,
            fifth,
            last);
    }

    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="first">The action to perform if in the First state.</param>
    /// <param name="second">The action to perform if in the Second state.</param>
    /// <param name="third">The action to perform if in the Third state.</param>
    /// <param name="fourth">The action to perform if in the Fourth state.</param>
    /// <param name="fifth">The action to perform if in the Fifth state.</param>
    /// <param name="sixth">The action to perform if in the Sixth state.</param>
    /// <param name="last">The action to perform if in the Last state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> PerformAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> input,
        Action<TFirst>? first = null,
        Action<TSecond>? second = null,
        Action<TThird>? third = null,
        Action<TFourth>? fourth = null,
        Action<TFifth>? fifth = null,
        Action<TSixth>? sixth = null,
        Action<TLast>? last = null)
    {
        var either = await input;
        
        return either.Perform(
            first,
            second,
            third,
            fourth,
            fifth,
            sixth,
            last);
    }
    
    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="first">The action to perform if in the First state.</param>
    /// <param name="second">The action to perform if in the Second state.</param>
    /// <param name="third">The action to perform if in the Third state.</param>
    /// <param name="fourth">The action to perform if in the Fourth state.</param>
    /// <param name="fifth">The action to perform if in the Fifth state.</param>
    /// <param name="sixth">The action to perform if in the Sixth state.</param>
    /// <param name="last">The action to perform if in the Last state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> PerformAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> input,
        Func<TFirst, Unit>? first = null,
        Func<TSecond, Unit>? second = null,
        Func<TThird, Unit>? third = null,
        Func<TFourth, Unit>? fourth = null,
        Func<TFifth, Unit>? fifth = null,
        Func<TSixth, Unit>? sixth = null,
        Func<TLast, Unit>? last = null)
    {
        var either = await input;
        
        return either.Perform(
            first,
            second,
            third,
            fourth,
            fifth,
            sixth,
            last);
    }

    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="first">The asynchronous action to perform if in the First state.</param>
    /// <param name="second">The asynchronous action to perform if in the Second state.</param>
    /// <param name="third">The asynchronous action to perform if in the Third state.</param>
    /// <param name="fourth">The asynchronous action to perform if in the Fourth state.</param>
    /// <param name="fifth">The asynchronous action to perform if in the Fifth state.</param>
    /// <param name="sixth">The asynchronous action to perform if in the Sixth state.</param>
    /// <param name="last">The asynchronous action to perform if in the Last state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> PerformAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> input,
        Func<TFirst, Task>? first = null,
        Func<TSecond, Task>? second = null,
        Func<TThird, Task>? third = null,
        Func<TFourth, Task>? fourth = null,
        Func<TFifth, Task>? fifth = null,
        Func<TSixth, Task>? sixth = null,
        Func<TLast, Task>? last = null)
    {
        var either = await input;
        
        return await either.PerformAsync(
            first,
            second,
            third,
            fourth,
            fifth,
            sixth,
            last);
    }

    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="first">The asynchronous action to perform if in the First state.</param>
    /// <param name="second">The asynchronous action to perform if in the Second state.</param>
    /// <param name="third">The asynchronous action to perform if in the Third state.</param>
    /// <param name="fourth">The asynchronous action to perform if in the Fourth state.</param>
    /// <param name="fifth">The asynchronous action to perform if in the Fifth state.</param>
    /// <param name="sixth">The asynchronous action to perform if in the Sixth state.</param>
    /// <param name="last">The asynchronous action to perform if in the Last state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> PerformAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> input,
        Func<TFirst, Task<Unit>>? first = null,
        Func<TSecond, Task<Unit>>? second = null,
        Func<TThird, Task<Unit>>? third = null,
        Func<TFourth, Task<Unit>>? fourth = null,
        Func<TFifth, Task<Unit>>? fifth = null,
        Func<TSixth, Task<Unit>>? sixth = null,
        Func<TLast, Task<Unit>>? last = null)
    {
        var either = await input;
        
        return await either.PerformAsync(
            first,
            second,
            third,
            fourth,
            fifth,
            sixth,
            last);
    }

    /// <summary>
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="first">The action to perform if in the First state.</param>
    /// <param name="second">The action to perform if in the Second state.</param>
    /// <param name="third">The action to perform if in the Third state.</param>
    /// <param name="fourth">The action to perform if in the Fourth state.</param>
    /// <param name="fifth">The action to perform if in the Fifth state.</param>
    /// <param name="sixth">The action to perform if in the Sixth state.</param>
    /// <param name="seventh">The action to perform if in the Seventh state.</param>
    /// <param name="last">The action to perform if in the Last state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> PerformAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Action<TFirst>? first = null,
        Action<TSecond>? second = null,
        Action<TThird>? third = null,
        Action<TFourth>? fourth = null,
        Action<TFifth>? fifth = null,
        Action<TSixth>? sixth = null,
        Action<TSeventh>? seventh = null,
        Action<TLast>? last = null)
    {
        var either = await input;
        
        return either.Perform(
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
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="first">The action to perform if in the First state.</param>
    /// <param name="second">The action to perform if in the Second state.</param>
    /// <param name="third">The action to perform if in the Third state.</param>
    /// <param name="fourth">The action to perform if in the Fourth state.</param>
    /// <param name="fifth">The action to perform if in the Fifth state.</param>
    /// <param name="sixth">The action to perform if in the Sixth state.</param>
    /// <param name="seventh">The action to perform if in the Seventh state.</param>
    /// <param name="last">The action to perform if in the Last state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> PerformAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Func<TFirst, Unit>? first = null,
        Func<TSecond, Unit>? second = null,
        Func<TThird, Unit>? third = null,
        Func<TFourth, Unit>? fourth = null,
        Func<TFifth, Unit>? fifth = null,
        Func<TSixth, Unit>? sixth = null,
        Func<TSeventh, Unit>? seventh = null,
        Func<TLast, Unit>? last = null)
    {
        var either = await input;
        
        return either.Perform(
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
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="first">The asynchronous action to perform if in the First state.</param>
    /// <param name="second">The asynchronous action to perform if in the Second state.</param>
    /// <param name="third">The asynchronous action to perform if in the Third state.</param>
    /// <param name="fourth">The asynchronous action to perform if in the Fourth state.</param>
    /// <param name="fifth">The asynchronous action to perform if in the Fifth state.</param>
    /// <param name="sixth">The asynchronous action to perform if in the Sixth state.</param>
    /// <param name="seventh">The asynchronous action to perform if in the Seventh state.</param>
    /// <param name="last">The asynchronous action to perform if in the Last state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> PerformAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Func<TFirst, Task>? first = null,
        Func<TSecond, Task>? second = null,
        Func<TThird, Task>? third = null,
        Func<TFourth, Task>? fourth = null,
        Func<TFifth, Task>? fifth = null,
        Func<TSixth, Task>? sixth = null,
        Func<TSeventh, Task>? seventh = null,
        Func<TLast, Task>? last = null)
    {
        var either = await input;
        
        return await either.PerformAsync(
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
    ///      Performs the relevant action based on the current state from the <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The asynchronous input to perform actions on.</param>
    /// <param name="first">The asynchronous action to perform if in the First state.</param>
    /// <param name="second">The asynchronous action to perform if in the Second state.</param>
    /// <param name="third">The asynchronous action to perform if in the Third state.</param>
    /// <param name="fourth">The asynchronous action to perform if in the Fourth state.</param>
    /// <param name="fifth">The asynchronous action to perform if in the Fifth state.</param>
    /// <param name="sixth">The asynchronous action to perform if in the Sixth state.</param>
    /// <param name="seventh">The asynchronous action to perform if in the Seventh state.</param>
    /// <param name="last">The asynchronous action to perform if in the Last state.</param>
    /// <returns>The <paramref name="input"/> after possibly performing the action.</returns>
    public static async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> PerformAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> input,
        Func<TFirst, Task<Unit>>? first = null,
        Func<TSecond, Task<Unit>>? second = null,
        Func<TThird, Task<Unit>>? third = null,
        Func<TFourth, Task<Unit>>? fourth = null,
        Func<TFifth, Task<Unit>>? fifth = null,
        Func<TSixth, Task<Unit>>? sixth = null,
        Func<TSeventh, Task<Unit>>? seventh = null,
        Func<TLast, Task<Unit>>? last = null)
    {
        var either = await input;
        
        return await either.PerformAsync(
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