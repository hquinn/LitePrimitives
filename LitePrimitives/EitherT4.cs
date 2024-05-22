// ReSharper disable once CheckNamespace

using LitePrimitives.Enums;

namespace LitePrimitives;

/// <summary>
///     Represents a value of one of four possible types (a disjointed union).
///     This type can encapsulate either:
///     - <typeparamref name="TFirst"/> in the First state.
///     - <typeparamref name="TSecond"/> in the Second state.
///     - <typeparamref name="TThird"/> in the Third state.
///     - <typeparamref name="TLast"/> in the Last state.
///     But not all at once.
/// </summary>
/// <typeparam name="TFirst">The type of the First state.</typeparam>
/// <typeparam name="TSecond">The type of the Second state.</typeparam>
/// <typeparam name="TThird">The type of the Third state.</typeparam>
/// <typeparam name="TLast">The type of the Last state.</typeparam>
public readonly struct Either<TFirst, TSecond, TThird, TLast>
{
    private readonly EitherState _state;
    private readonly TFirst? _first;
    private readonly TSecond? _second;
    private readonly TThird? _third;
    private readonly TLast? _last;

    private Either(TFirst first)
    {
        _first = first;
        _state = EitherState.First;
    }

    private Either(TSecond second)
    {
        _second = second;
        _state = EitherState.Second;
    }

    private Either(TThird third)
    {
        _third = third;
        _state = EitherState.Third;
    }

    private Either(TLast last)
    {
        _last = last;
        _state = EitherState.Last;
    }

    /// <summary>
    ///     Outputs the following:
    ///     - <paramref name="first"/> if in the First state.
    ///     - <paramref name="second"/> if in the Second state.
    ///     - <paramref name="third"/> if in the Third state.
    ///     - <paramref name="last"/> if in the Last state.
    ///     The output is of type <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="first">The func to use if <see cref="Either{TFirst, TSecond, TThird, TLast}"/> is in the First state.</param>
    /// <param name="second">The func to use if <see cref="Either{TFirst, TSecond, TThird, TLast}"/> is in the Second state.</param>
    /// <param name="third">The func to use if <see cref="Either{TFirst, TSecond, TThird, TLast}"/> is in the Third state.</param>
    /// <param name="last">The func to use if <see cref="Either{TFirst, TSecond, TThird, TLast}"/> is in the Last state.</param>
    /// <typeparam name="TOutput">The output of the match.</typeparam>
    /// <returns>The output of the match.</returns>
    public TOutput Match<TOutput>(
        Func<TFirst, TOutput> first,
        Func<TSecond, TOutput> second,
        Func<TThird, TOutput> third,
        Func<TLast, TOutput> last)
    {
        return _state switch
        {
            EitherState.First => first(_first!),
            EitherState.Second => second(_second!),
            EitherState.Third => third(_third!),
            EitherState.Last => last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }

    /// <summary>
    ///     Outputs the following:
    ///     - <paramref name="first"/> if in the First state.
    ///     - <paramref name="second"/> if in the Second state.
    ///     - <paramref name="third"/> if in the Third state.
    ///     - <paramref name="last"/> if in the Last state.
    ///     The output is of type <see cref="Task"/> of <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="first">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TLast}"/> is in the First state.</param>
    /// <param name="second">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TLast}"/> is in the Second state.</param>
    /// <param name="third">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TLast}"/> is in the Third state.</param>
    /// <param name="last">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TLast}"/> is in the Last state.</param>
    /// <typeparam name="TOutput">The output of the match.</typeparam>
    /// <returns>The output of the match.</returns>
    public async Task<TOutput> MatchAsync<TOutput>(
        Func<TFirst, Task<TOutput>> first,
        Func<TSecond, Task<TOutput>> second,
        Func<TThird, Task<TOutput>> third,
        Func<TLast, Task<TOutput>> last)
    {
        return _state switch
        {
            EitherState.First => await first(_first!),
            EitherState.Second => await second(_second!),
            EitherState.Third => await third(_third!),
            EitherState.Last => await last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the First state,
    ///      otherwise returns <see cref="Either{TOutputFirst, TSecond, TThird, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="bindFunc">The func to apply if in the First state.</param>
    /// <typeparam name="TOutputFirst">The type of the First output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the First state,
    ///      otherwise returns <see cref="Either{TOutputFirst, TSecond, TThird, TLast}"/> in the appropriate state.
    /// </returns>
    public Either<TOutputFirst, TSecond, TThird, TLast> BindFirst<TOutputFirst>(
        Func<TFirst, Either<TOutputFirst, TSecond, TThird, TLast>> bindFunc)
    {
        return _state switch
        {
            EitherState.First => bindFunc(_first!),
            EitherState.Second => Either<TOutputFirst, TSecond, TThird, TLast>.Second(_second!),
            EitherState.Third => Either<TOutputFirst, TSecond, TThird, TLast>.Third(_third!),
            EitherState.Last => Either<TOutputFirst, TSecond, TThird, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Second state,
    ///      otherwise returns <see cref="Either{TFirst, TOutputSecond, TThird, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="bindFunc">The func to apply if in the Second state.</param>
    /// <typeparam name="TOutputSecond">The type of the Second output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the Second state,
    ///      otherwise returns <see cref="Either{TFirst, TOutputSecond, TThird, TLast}"/> in the appropriate state.
    /// </returns>
    public Either<TFirst, TOutputSecond, TThird, TLast> BindSecond<TOutputSecond>(
        Func<TSecond, Either<TFirst, TOutputSecond, TThird, TLast>> bindFunc)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TOutputSecond, TThird, TLast>.First(_first!),
            EitherState.Second => bindFunc(_second!),
            EitherState.Third => Either<TFirst, TOutputSecond, TThird, TLast>.Third(_third!),
            EitherState.Last => Either<TFirst, TOutputSecond, TThird, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Third state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TOutputThird, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="bindFunc">The func to apply if in the Third state.</param>
    /// <typeparam name="TOutputThird">The type of the Third output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the Third state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TOutputThird, TLast}"/> in the appropriate state.
    /// </returns>
    public Either<TFirst, TSecond, TOutputThird, TLast> BindThird<TOutputThird>(
        Func<TThird, Either<TFirst, TSecond, TOutputThird, TLast>> bindFunc)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TOutputThird, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TOutputThird, TLast>.Second(_second!),
            EitherState.Third => bindFunc(_third!),
            EitherState.Last => Either<TFirst, TSecond, TOutputThird, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Last state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TThird, TOutputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="bindFunc">The func to apply if in the Last state.</param>
    /// <typeparam name="TOutputLast">The type of the Last output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the Last state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TThird, TOutputLast}"/> in the appropriate state.
    /// </returns>
    public Either<TFirst, TSecond, TThird, TOutputLast> BindLast<TOutputLast>(
        Func<TLast, Either<TFirst, TSecond, TThird, TOutputLast>> bindFunc)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TThird, TOutputLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TThird, TOutputLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TThird, TOutputLast>.Third(_third!),
            EitherState.Last => bindFunc(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TSecond, TThird, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="bindFunc">The asynchronous func to apply if in the First state.</param>
    /// <typeparam name="TOutputFirst">The type of the First output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TSecond, TThird, TLast}"/> in the appropriate state.
    /// </returns>
    public async Task<Either<TOutputFirst, TSecond, TThird, TLast>> BindFirstAsync<TOutputFirst>(
        Func<TFirst, Task<Either<TOutputFirst, TSecond, TThird, TLast>>> bindFunc)
    {
        return _state switch
        {
            EitherState.First => await bindFunc(_first!),
            EitherState.Second => Either<TOutputFirst, TSecond, TThird, TLast>.Second(_second!),
            EitherState.Third => Either<TOutputFirst, TSecond, TThird, TLast>.Third(_third!),
            EitherState.Last => Either<TOutputFirst, TSecond, TThird, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TOutputSecond, TThird, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="bindFunc">The asynchronous func to apply if in the Second state.</param>
    /// <typeparam name="TOutputSecond">The type of the Second output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TOutputSecond, TThird, TLast}"/> in the appropriate state.
    /// </returns>
    public async Task<Either<TFirst, TOutputSecond, TThird, TLast>> BindSecondAsync<TOutputSecond>(
        Func<TSecond, Task<Either<TFirst, TOutputSecond, TThird, TLast>>> bindFunc)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TOutputSecond, TThird, TLast>.First(_first!),
            EitherState.Second => await bindFunc(_second!),
            EitherState.Third => Either<TFirst, TOutputSecond, TThird, TLast>.Third(_third!),
            EitherState.Last => Either<TFirst, TOutputSecond, TThird, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TOutputThird, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="bindFunc">The asynchronous func to apply if in the Third state.</param>
    /// <typeparam name="TOutputThird">The type of the Third output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TOutputThird, TLast}"/> in the appropriate state.
    /// </returns>
    public async Task<Either<TFirst, TSecond, TOutputThird, TLast>> BindThirdAsync<TOutputThird>(
        Func<TThird, Task<Either<TFirst, TSecond, TOutputThird, TLast>>> bindFunc)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TOutputThird, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TOutputThird, TLast>.Second(_second!),
            EitherState.Third => await bindFunc(_third!),
            EitherState.Last => Either<TFirst, TSecond, TOutputThird, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TThird, TOutputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="bindFunc">The asynchronous func to apply if in the Last state.</param>
    /// <typeparam name="TOutputLast">The type of the Last output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TThird, TOutputLast}"/> in the appropriate state.
    /// </returns>
    public async Task<Either<TFirst, TSecond, TThird, TOutputLast>> BindLastAsync<TOutputLast>(
        Func<TLast, Task<Either<TFirst, TSecond, TThird, TOutputLast>>> bindFunc)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TThird, TOutputLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TThird, TOutputLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TThird, TOutputLast>.Third(_third!),
            EitherState.Last => await bindFunc(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TOutputFirst, TSecond, TThird, TLast}"/> when it's in the First state,
    ///      otherwise returns <see cref="Either{TOutputFirst, TSecond, TThird, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputFirst"/>.</param>
    /// <typeparam name="TOutputFirst">The type of the transformed First output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the First state,
    ///      otherwise returns <see cref="Either{TOutputFirst, TSecond, TThird, TLast}"/> in the appropriate state.
    /// </returns>
    public Either<TOutputFirst, TSecond, TThird, TLast> MapFirst<TOutputFirst>(
        Func<TFirst, TOutputFirst> transform)
    {
        return _state switch
        {
            EitherState.First => Either<TOutputFirst, TSecond, TThird, TLast>.First(transform(_first!)),
            EitherState.Second => Either<TOutputFirst, TSecond, TThird, TLast>.Second(_second!),
            EitherState.Third => Either<TOutputFirst, TSecond, TThird, TLast>.Third(_third!),
            EitherState.Last => Either<TOutputFirst, TSecond, TThird, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TFirst, TOutputSecond, TThird, TLast}"/> when it's in the Second state,
    ///      otherwise returns <see cref="Either{TFirst, TOutputSecond, TThird, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputSecond"/>.</param>
    /// <typeparam name="TOutputSecond">The type of the transformed Second output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Second state,
    ///      otherwise returns <see cref="Either{TFirst, TOutputSecond, TThird, TLast}"/> in the appropriate state.
    /// </returns>
    public Either<TFirst, TOutputSecond, TThird, TLast> MapSecond<TOutputSecond>(
        Func<TSecond, TOutputSecond> transform)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TOutputSecond, TThird, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TOutputSecond, TThird, TLast>.Second(transform(_second!)),
            EitherState.Third => Either<TFirst, TOutputSecond, TThird, TLast>.Third(_third!),
            EitherState.Last => Either<TFirst, TOutputSecond, TThird, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TFirst, TSecond, TOutputThird, TLast}"/> when it's in the Third state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TOutputThird, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputThird"/>.</param>
    /// <typeparam name="TOutputThird">The type of the transformed Third output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Third state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TOutputThird, TLast}"/> in the appropriate state.
    /// </returns>
    public Either<TFirst, TSecond, TOutputThird, TLast> MapThird<TOutputThird>(
        Func<TThird, TOutputThird> transform)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TOutputThird, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TOutputThird, TLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TOutputThird, TLast>.Third(transform(_third!)),
            EitherState.Last => Either<TFirst, TSecond, TOutputThird, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TFirst, TSecond, TThird, TOutputLast}"/> when it's in the Last state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TThird, TOutputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputLast"/>.</param>
    /// <typeparam name="TOutputLast">The type of the transformed Last output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Last state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TThird, TOutputLast}"/> in the appropriate state.
    /// </returns>
    public Either<TFirst, TSecond, TThird, TOutputLast> MapLast<TOutputLast>(
        Func<TLast, TOutputLast> transform)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TThird, TOutputLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TThird, TOutputLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TThird, TOutputLast>.Third(_third!),
            EitherState.Last => Either<TFirst, TSecond, TThird, TOutputLast>.Last(transform(_last!)),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TOutputFirst, TSecond, TThird, TLast}"/> when it's in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TSecond, TThird, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="transform">The asynchronous function to transform to <typeparamref name="TOutputFirst"/>.</param>
    /// <typeparam name="TOutputFirst">The type of the transformed First output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TSecond, TThird, TLast}"/> in the appropriate state.
    /// </returns>
    public async Task<Either<TOutputFirst, TSecond, TThird, TLast>> MapFirstAsync<TOutputFirst>(
        Func<TFirst, Task<TOutputFirst>> transform)
    {
        return _state switch
        {
            EitherState.First => Either<TOutputFirst, TSecond, TThird, TLast>.First(await transform(_first!)),
            EitherState.Second => Either<TOutputFirst, TSecond, TThird, TLast>.Second(_second!),
            EitherState.Third => Either<TOutputFirst, TSecond, TThird, TLast>.Third(_third!),
            EitherState.Last => Either<TOutputFirst, TSecond, TThird, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TFirst, TOutputSecond, TThird, TLast}"/> when it's in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TOutputSecond, TThird, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="transform">The asynchronous function to transform to <typeparamref name="TOutputSecond"/>.</param>
    /// <typeparam name="TOutputSecond">The type of the transformed Second output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TOutputSecond, TThird, TLast}"/> in the appropriate state.
    /// </returns>
    public async Task<Either<TFirst, TOutputSecond, TThird, TLast>> MapSecondAsync<TOutputSecond>(
        Func<TSecond, Task<TOutputSecond>> transform)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TOutputSecond, TThird, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TOutputSecond, TThird, TLast>.Second(await transform(_second!)),
            EitherState.Third => Either<TFirst, TOutputSecond, TThird, TLast>.Third(_third!),
            EitherState.Last => Either<TFirst, TOutputSecond, TThird, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TFirst, TSecond, TOutputThird, TLast}"/> when it's in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TOutputThird, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="transform">The asynchronous function to transform to <typeparamref name="TOutputThird"/>.</param>
    /// <typeparam name="TOutputThird">The type of the transformed Third output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TOutputThird, TLast}"/> in the appropriate state.
    /// </returns>
    public async Task<Either<TFirst, TSecond, TOutputThird, TLast>> MapThirdAsync<TOutputThird>(
        Func<TThird, Task<TOutputThird>> transform)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TOutputThird, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TOutputThird, TLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TOutputThird, TLast>.Third(await transform(_third!)),
            EitherState.Last => Either<TFirst, TSecond, TOutputThird, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TFirst, TSecond, TThird, TOutputLast}"/> when it's in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TThird, TOutputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="transform">The asynchronous function to transform to <typeparamref name="TOutputLast"/>.</param>
    /// <typeparam name="TOutputLast">The type of the transformed Last output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TThird, TOutputLast}"/> in the appropriate state.
    /// </returns>
    public async Task<Either<TFirst, TSecond, TThird, TOutputLast>> MapLastAsync<TOutputLast>(
        Func<TLast, Task<TOutputLast>> transform)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TThird, TOutputLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TThird, TOutputLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TThird, TOutputLast>.Third(_third!),
            EitherState.Last => Either<TFirst, TSecond, TThird, TOutputLast>.Last(await transform(_last!)),
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the First state.
    /// </summary>
    /// <param name="action">The action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public Either<TFirst, TSecond, TThird, TLast> OnFirst(Action<TFirst> action)
    {
        if (_state is EitherState.First)
        {
            action(_first!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the First state.
    /// </summary>
    /// <param name="action">The action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public Either<TFirst, TSecond, TThird, TLast> OnFirst(Func<TFirst, Unit> action)
    {
        if (_state is EitherState.First)
        {
            action(_first!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the First state.
    /// </summary>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public async Task<Either<TFirst, TSecond, TThird, TLast>> OnFirstAsync(Func<TFirst, Task> action)
    {
        if (_state is EitherState.First)
        {
            await action(_first!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the First state.
    /// </summary>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public async Task<Either<TFirst, TSecond, TThird, TLast>> OnFirstAsync(Func<TFirst, Task<Unit>> action)
    {
        if (_state is EitherState.First)
        {
            await action(_first!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Second state.
    /// </summary>
    /// <param name="action">The action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public Either<TFirst, TSecond, TThird, TLast> OnSecond(Action<TSecond> action)
    {
        if (_state is EitherState.Second)
        {
            action(_second!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Second state.
    /// </summary>
    /// <param name="action">The action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public Either<TFirst, TSecond, TThird, TLast> OnSecond(Func<TSecond, Unit> action)
    {
        if (_state is EitherState.Second)
        {
            action(_second!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Second state.
    /// </summary>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public async Task<Either<TFirst, TSecond, TThird, TLast>> OnSecondAsync(Func<TSecond, Task> action)
    {
        if (_state is EitherState.Second)
        {
            await action(_second!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Second state.
    /// </summary>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public async Task<Either<TFirst, TSecond, TThird, TLast>> OnSecondAsync(Func<TSecond, Task<Unit>> action)
    {
        if (_state is EitherState.Second)
        {
            await action(_second!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Third state.
    /// </summary>
    /// <param name="action">The action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public Either<TFirst, TSecond, TThird, TLast> OnThird(Action<TThird> action)
    {
        if (_state is EitherState.Third)
        {
            action(_third!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Third state.
    /// </summary>
    /// <param name="action">The action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public Either<TFirst, TSecond, TThird, TLast> OnThird(Func<TThird, Unit> action)
    {
        if (_state is EitherState.Third)
        {
            action(_third!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Third state.
    /// </summary>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public async Task<Either<TFirst, TSecond, TThird, TLast>> OnThirdAsync(Func<TThird, Task> action)
    {
        if (_state is EitherState.Third)
        {
            await action(_third!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Third state.
    /// </summary>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public async Task<Either<TFirst, TSecond, TThird, TLast>> OnThirdAsync(Func<TThird, Task<Unit>> action)
    {
        if (_state is EitherState.Third)
        {
            await action(_third!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Last state.
    /// </summary>
    /// <param name="action">The action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public Either<TFirst, TSecond, TThird, TLast> OnLast(Action<TLast> action)
    {
        if (_state is EitherState.Last)
        {
            action(_last!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Last state.
    /// </summary>
    /// <param name="action">The action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public Either<TFirst, TSecond, TThird, TLast> OnLast(Func<TLast, Unit> action)
    {
        if (_state is EitherState.Last)
        {
            action(_last!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Last state.
    /// </summary>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public async Task<Either<TFirst, TSecond, TThird, TLast>> OnLastAsync(Func<TLast, Task> action)
    {
        if (_state is EitherState.Last)
        {
            await action(_last!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Last state.
    /// </summary>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public async Task<Either<TFirst, TSecond, TThird, TLast>> OnLastAsync(Func<TLast, Task<Unit>> action)
    {
        if (_state is EitherState.Last)
        {
            await action(_last!);
        }

        return this;
    }

    /// <summary>
    ///      Constructs <see cref="Either{TFirst, TSecond, TThird, TLast}"/> from a <typeparamref name="TFirst"/> in the First state.
    /// </summary>
    /// <param name="first">The value to construct the <see cref="Either{TFirst, TSecond, TThird, TLast}"/> type from.</param>
    /// <returns>The <see cref="Either{TFirst, TSecond, TThird, TLast}"/> type in the First state.</returns>
    public static Either<TFirst, TSecond, TThird, TLast> First(TFirst first)
    {
        return new Either<TFirst, TSecond, TThird, TLast>(first);
    }

    /// <summary>
    ///      Constructs <see cref="Either{TFirst, TSecond, TThird, TLast}"/> from a <typeparamref name="TSecond"/> in the Second state.
    /// </summary>
    /// <param name="second">The value to construct the <see cref="Either{TFirst, TSecond, TThird, TLast}"/> type from.</param>
    /// <returns>The <see cref="Either{TFirst, TSecond, TThird, TLast}"/> type in the Second state.</returns>
    public static Either<TFirst, TSecond, TThird, TLast> Second(TSecond second)
    {
        return new Either<TFirst, TSecond, TThird, TLast>(second);
    }

    /// <summary>
    ///      Constructs <see cref="Either{TFirst, TSecond, TThird, TLast}"/> from a <typeparamref name="TThird"/> in the Third state.
    /// </summary>
    /// <param name="third">The value to construct the <see cref="Either{TFirst, TSecond, TThird, TLast}"/> type from.</param>
    /// <returns>The <see cref="Either{TFirst, TSecond, TThird, TLast}"/> type in the Third state.</returns>
    public static Either<TFirst, TSecond, TThird, TLast> Third(TThird third)
    {
        return new Either<TFirst, TSecond, TThird, TLast>(third);
    }

    /// <summary>
    ///      Constructs <see cref="Either{TFirst, TSecond, TThird, TLast}"/> from a <typeparamref name="TLast"/> in the Last state.
    /// </summary>
    /// <param name="last">The value to construct the <see cref="Either{TFirst, TSecond, TThird, TLast}"/> type from.</param>
    /// <returns>The <see cref="Either{TFirst, TSecond, TThird, TLast}"/> type in the Last state.</returns>
    public static Either<TFirst, TSecond, TThird, TLast> Last(TLast last)
    {
        return new Either<TFirst, TSecond, TThird, TLast>(last);
    }
}