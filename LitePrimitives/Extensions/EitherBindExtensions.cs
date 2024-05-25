// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for Bind on the Either type.
/// </summary>
public static class EitherBindExtensions
{
    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the First state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFirst">The type of the First output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TOutputFirst, TInputLast>> BindFirstAsync<TInputFirst, TInputLast, TOutputFirst>(
        this Task<Either<TInputFirst, TInputLast>> input,
        Func<TInputFirst, Task<Either<TOutputFirst, TInputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindFirstAsync(bindFunc);
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the Last state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputLast">The type of the Last output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TOutputLast>> BindLastAsync<TInputFirst, TInputLast, TOutputLast>(
        this Task<Either<TInputFirst, TInputLast>> input,
        Func<TInputLast, Task<Either<TInputFirst, TOutputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindLastAsync(bindFunc);
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the First state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFirst">The type of the First output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TOutputFirst, TInputSecond, TInputLast>> BindFirstAsync<TInputFirst, TInputSecond, TInputLast, TOutputFirst>(
        this Task<Either<TInputFirst, TInputSecond, TInputLast>> input,
        Func<TInputFirst, Task<Either<TOutputFirst, TInputSecond, TInputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindFirstAsync(bindFunc);
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the Second state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputSecond">The type of the Second output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TOutputSecond, TInputLast>> BindSecondAsync<TInputFirst, TInputSecond, TInputLast, TOutputSecond>(
        this Task<Either<TInputFirst, TInputSecond, TInputLast>> input,
        Func<TInputSecond, Task<Either<TInputFirst, TOutputSecond, TInputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindSecondAsync(bindFunc);
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the Last state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputLast">The type of the Last output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TOutputLast>> BindLastAsync<TInputFirst, TInputSecond, TInputLast, TOutputLast>(
        this Task<Either<TInputFirst, TInputSecond, TInputLast>> input,
        Func<TInputLast, Task<Either<TInputFirst, TInputSecond, TOutputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindLastAsync(bindFunc);
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the First state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFirst">The type of the First output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TOutputFirst, TInputSecond, TInputThird, TInputLast>> BindFirstAsync<TInputFirst, TInputSecond, TInputThird, TInputLast, TOutputFirst>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputLast>> input,
        Func<TInputFirst, Task<Either<TOutputFirst, TInputSecond, TInputThird, TInputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindFirstAsync(bindFunc);
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the Second state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputSecond">The type of the Second output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TOutputSecond, TInputThird, TInputLast>> BindSecondAsync<TInputFirst, TInputSecond, TInputThird, TInputLast, TOutputSecond>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputLast>> input,
        Func<TInputSecond, Task<Either<TInputFirst, TOutputSecond, TInputThird, TInputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindSecondAsync(bindFunc);
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the Third state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputThird">The type of the Third output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TOutputThird, TInputLast>> BindThirdAsync<TInputFirst, TInputSecond, TInputThird, TInputLast, TOutputThird>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputLast>> input,
        Func<TInputThird, Task<Either<TInputFirst, TInputSecond, TOutputThird, TInputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindThirdAsync(bindFunc);
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the Last state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputLast">The type of the Last output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TOutputLast>> BindLastAsync<TInputFirst, TInputSecond, TInputThird, TInputLast, TOutputLast>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputLast>> input,
        Func<TInputLast, Task<Either<TInputFirst, TInputSecond, TInputThird, TOutputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindLastAsync(bindFunc);
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the First state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFirst">The type of the First output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast>> BindFirstAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast, TOutputFirst>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast>> input,
        Func<TInputFirst, Task<Either<TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindFirstAsync(bindFunc);
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the Second state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputSecond">The type of the Second output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputLast>> BindSecondAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast, TOutputSecond>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast>> input,
        Func<TInputSecond, Task<Either<TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindSecondAsync(bindFunc);
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the Third state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputThird">The type of the Third output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputLast>> BindThirdAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast, TOutputThird>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast>> input,
        Func<TInputThird, Task<Either<TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindThirdAsync(bindFunc);
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Fourth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the Fourth state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFourth">The type of the Fourth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the Fourth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputLast>> BindFourthAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast, TOutputFourth>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast>> input,
        Func<TInputFourth, Task<Either<TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindFourthAsync(bindFunc);
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the Last state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputLast">The type of the Last output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputLast>> BindLastAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast, TOutputLast>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast>> input,
        Func<TInputLast, Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindLastAsync(bindFunc);
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the First state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFirst">The type of the First output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast>> BindFirstAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast, TOutputFirst>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast>> input,
        Func<TInputFirst, Task<Either<TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindFirstAsync(bindFunc);
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the Second state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputSecond">The type of the Second output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast>> BindSecondAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast, TOutputSecond>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast>> input,
        Func<TInputSecond, Task<Either<TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindSecondAsync(bindFunc);
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the Third state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputThird">The type of the Third output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputLast>> BindThirdAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast, TOutputThird>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast>> input,
        Func<TInputThird, Task<Either<TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindThirdAsync(bindFunc);
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Fourth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the Fourth state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFourth">The type of the Fourth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the Fourth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputLast>> BindFourthAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast, TOutputFourth>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast>> input,
        Func<TInputFourth, Task<Either<TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindFourthAsync(bindFunc);
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Fifth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the Fifth state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFifth">The type of the Fifth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the Fifth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputLast>> BindFifthAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast, TOutputFifth>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast>> input,
        Func<TInputFifth, Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindFifthAsync(bindFunc);
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the Last state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputLast">The type of the Last output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputLast>> BindLastAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast, TOutputLast>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast>> input,
        Func<TInputLast, Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindLastAsync(bindFunc);
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the First state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFirst">The type of the First output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast>> BindFirstAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast, TOutputFirst>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast>> input,
        Func<TInputFirst, Task<Either<TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindFirstAsync(bindFunc);
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the Second state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputSecond">The type of the Second output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast>> BindSecondAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast, TOutputSecond>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast>> input,
        Func<TInputSecond, Task<Either<TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindSecondAsync(bindFunc);
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the Third state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputThird">The type of the Third output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast>> BindThirdAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast, TOutputThird>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast>> input,
        Func<TInputThird, Task<Either<TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindThirdAsync(bindFunc);
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Fourth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputSixth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the Fourth state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFourth">The type of the Fourth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the Fourth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputSixth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputSixth, TInputLast>> BindFourthAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast, TOutputFourth>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast>> input,
        Func<TInputFourth, Task<Either<TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputSixth, TInputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindFourthAsync(bindFunc);
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Fifth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputSixth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the Fifth state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFifth">The type of the Fifth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the Fifth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputSixth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputSixth, TInputLast>> BindFifthAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast, TOutputFifth>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast>> input,
        Func<TInputFifth, Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputSixth, TInputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindFifthAsync(bindFunc);
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Sixth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputSixth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the Sixth state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputSixth">The type of the Sixth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the Sixth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputSixth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputSixth, TInputLast>> BindSixthAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast, TOutputSixth>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast>> input,
        Func<TInputSixth, Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputSixth, TInputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindSixthAsync(bindFunc);
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TOutputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the Last state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputLast">The type of the Last output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TOutputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TOutputLast>> BindLastAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast, TOutputLast>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast>> input,
        Func<TInputLast, Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TOutputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindLastAsync(bindFunc);
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the First state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFirst">The type of the First output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> BindFirstAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast, TOutputFirst>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> input,
        Func<TInputFirst, Task<Either<TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindFirstAsync(bindFunc);
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the Second state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputSecond">The type of the Second output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> BindSecondAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast, TOutputSecond>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> input,
        Func<TInputSecond, Task<Either<TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindSecondAsync(bindFunc);
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the Third state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputThird">The type of the Third output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> BindThirdAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast, TOutputThird>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> input,
        Func<TInputThird, Task<Either<TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindThirdAsync(bindFunc);
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Fourth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the Fourth state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFourth">The type of the Fourth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the Fourth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> BindFourthAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast, TOutputFourth>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> input,
        Func<TInputFourth, Task<Either<TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindFourthAsync(bindFunc);
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Fifth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the Fifth state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFifth">The type of the Fifth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the Fifth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputSixth, TInputSeventh, TInputLast>> BindFifthAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast, TOutputFifth>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> input,
        Func<TInputFifth, Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputSixth, TInputSeventh, TInputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindFifthAsync(bindFunc);
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Sixth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the Sixth state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputSixth">The type of the Sixth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the Sixth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputSixth, TInputSeventh, TInputLast>> BindSixthAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast, TOutputSixth>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> input,
        Func<TInputSixth, Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputSixth, TInputSeventh, TInputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindSixthAsync(bindFunc);
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Seventh state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TOutputSeventh, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the Seventh state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputSeventh">The type of the Seventh output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the Seventh state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TOutputSeventh, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TOutputSeventh, TInputLast>> BindSeventhAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast, TOutputSeventh>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> input,
        Func<TInputSeventh, Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TOutputSeventh, TInputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindSeventhAsync(bindFunc);
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TOutputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to bind.</param>
    /// <param name="bindFunc">The func to apply if in the Last state.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputLast">The type of the Last output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if <paramref name="input"/> in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TOutputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TOutputLast>> BindLastAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast, TOutputLast>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> input,
        Func<TInputLast, Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TOutputLast>>> bindFunc)
    {
        var either = await input;

        return await either.BindLastAsync(bindFunc);
    }
}