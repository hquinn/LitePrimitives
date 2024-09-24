using LitePrimitives.InternalStates;

// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Represents a value of one of five possible types (a disjointed union).
///     This type can encapsulate either:
///     - <typeparamref name="TFirst"/> in the First state.
///     - <typeparamref name="TSecond"/> in the Second state.
///     - <typeparamref name="TThird"/> in the Third state.
///     - <typeparamref name="TFourth"/> in the Fourth state.
///     - <typeparamref name="TLast"/> in the Last state.
///     But not all at once.
/// </summary>
/// <typeparam name="TFirst">The type of the First state.</typeparam>
/// <typeparam name="TSecond">The type of the Second state.</typeparam>
/// <typeparam name="TThird">The type of the Third state.</typeparam>
/// <typeparam name="TFourth">The type of the Fourth state.</typeparam>
/// <typeparam name="TLast">The type of the Last state.</typeparam>
public readonly struct Either<TFirst, TSecond, TThird, TFourth, TLast>
{
    private readonly EitherState _state;
    private readonly TFirst? _first;
    private readonly TSecond? _second;
    private readonly TThird? _third;
    private readonly TFourth? _fourth;
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

    private Either(TFourth fourth)
    {
        _fourth = fourth;
        _state = EitherState.Fourth;
    }

    private Either(TLast last)
    {
        _last = last;
        _state = EitherState.Last;
    }

    /// <summary>
    ///     Returns true if the <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> is in the First state.
    /// </summary>
    public bool IsFirst => _state == EitherState.First;

    /// <summary>
    ///     Returns true if the <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> is in the Second state.
    /// </summary>
    public bool IsSecond => _state == EitherState.Second;

    /// <summary>
    ///     Returns true if the <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> is in the Third state.
    /// </summary>
    public bool IsThird => _state == EitherState.Third;

    /// <summary>
    ///     Returns true if the <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> is in the Fourth state.
    /// </summary>
    public bool IsFourth => _state == EitherState.Fourth;

    /// <summary>
    ///     Returns true if the <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> is in the Last state.
    /// </summary>
    public bool IsLast => _state == EitherState.Last;

    /// <summary>
    ///     Outputs the following:
    ///     - <paramref name="first"/> if in the First state.
    ///     - <paramref name="second"/> if in the Second state.
    ///     - <paramref name="third"/> if in the Third state.
    ///     - <paramref name="fourth"/> if in the Fourth state.
    ///     - <paramref name="last"/> if in the Last state.
    ///     The output is of type <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="first">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> is in the First state.</param>
    /// <param name="second">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> is in the Second state.</param>
    /// <param name="third">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> is in the Third state.</param>
    /// <param name="fourth">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> is in the Fourth state.</param>
    /// <param name="last">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> is in the Last state.</param>
    /// <typeparam name="TOutput">The output of the match.</typeparam>
    /// <returns>The output of the match.</returns>
    public TOutput Match<TOutput>(
        Func<TFirst, TOutput> first,
        Func<TSecond, TOutput> second,
        Func<TThird, TOutput> third,
        Func<TFourth, TOutput> fourth,
        Func<TLast, TOutput> last)
    {
        return _state switch
        {
            EitherState.First => first(_first!),
            EitherState.Second => second(_second!),
            EitherState.Third => third(_third!),
            EitherState.Fourth => fourth(_fourth!),
            EitherState.Last => last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };
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
    /// <param name="first">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> is in the First state.</param>
    /// <param name="second">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> is in the Second state.</param>
    /// <param name="third">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> is in the Third state.</param>
    /// <param name="fourth">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> is in the Fourth state.</param>
    /// <param name="last">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> is in the Last state.</param>
    /// <typeparam name="TOutput">The output of the match.</typeparam>
    /// <returns>The output of the match.</returns>
    public async Task<TOutput> MatchAsync<TOutput>(
        Func<TFirst, Task<TOutput>> first,
        Func<TSecond, Task<TOutput>> second,
        Func<TThird, Task<TOutput>> third,
        Func<TFourth, Task<TOutput>> fourth,
        Func<TLast, Task<TOutput>> last)
    {
        return _state switch
        {
            EitherState.First => await first(_first!),
            EitherState.Second => await second(_second!),
            EitherState.Third => await third(_third!),
            EitherState.Fourth => await fourth(_fourth!),
            EitherState.Last => await last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the First state,
    ///      otherwise returns <see cref="Either{TOutputFirst, TSecond, TThird, TFourth, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="bindFunc">The func to apply if in the First state.</param>
    /// <typeparam name="TOutputFirst">The type of the First output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the First state,
    ///      otherwise returns <see cref="Either{TOutputFirst, TSecond, TThird, TFourth, TLast}"/> in the appropriate state.
    /// </returns>
    public Either<TOutputFirst, TSecond, TThird, TFourth, TLast> BindFirst<TOutputFirst>(
        Func<TFirst, Either<TOutputFirst, TSecond, TThird, TFourth, TLast>> bindFunc)
    {
        return _state switch
        {
            EitherState.First => bindFunc(_first!),
            EitherState.Second => Either<TOutputFirst, TSecond, TThird, TFourth, TLast>.Second(_second!),
            EitherState.Third => Either<TOutputFirst, TSecond, TThird, TFourth, TLast>.Third(_third!),
            EitherState.Fourth => Either<TOutputFirst, TSecond, TThird, TFourth, TLast>.Fourth(_fourth!),
            EitherState.Last => Either<TOutputFirst, TSecond, TThird, TFourth, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Second state,
    ///      otherwise returns <see cref="Either{TFirst, TOutputSecond, TThird, TFourth, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="bindFunc">The func to apply if in the Second state.</param>
    /// <typeparam name="TOutputSecond">The type of the Second output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the Second state,
    ///      otherwise returns <see cref="Either{TFirst, TOutputSecond, TThird, TFourth, TLast}"/> in the appropriate state.
    /// </returns>
    public Either<TFirst, TOutputSecond, TThird, TFourth, TLast> BindSecond<TOutputSecond>(
        Func<TSecond, Either<TFirst, TOutputSecond, TThird, TFourth, TLast>> bindFunc)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TOutputSecond, TThird, TFourth, TLast>.First(_first!),
            EitherState.Second => bindFunc(_second!),
            EitherState.Third => Either<TFirst, TOutputSecond, TThird, TFourth, TLast>.Third(_third!),
            EitherState.Fourth => Either<TFirst, TOutputSecond, TThird, TFourth, TLast>.Fourth(_fourth!),
            EitherState.Last => Either<TFirst, TOutputSecond, TThird, TFourth, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Third state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TOutputThird, TFourth, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="bindFunc">The func to apply if in the Third state.</param>
    /// <typeparam name="TOutputThird">The type of the Third output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the Third state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TOutputThird, TFourth, TLast}"/> in the appropriate state.
    /// </returns>
    public Either<TFirst, TSecond, TOutputThird, TFourth, TLast> BindThird<TOutputThird>(
        Func<TThird, Either<TFirst, TSecond, TOutputThird, TFourth, TLast>> bindFunc)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TOutputThird, TFourth, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TOutputThird, TFourth, TLast>.Second(_second!),
            EitherState.Third => bindFunc(_third!),
            EitherState.Fourth => Either<TFirst, TSecond, TOutputThird, TFourth, TLast>.Fourth(_fourth!),
            EitherState.Last => Either<TFirst, TSecond, TOutputThird, TFourth, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Fourth state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TThird, TOutputFourth, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="bindFunc">The func to apply if in the Fourth state.</param>
    /// <typeparam name="TOutputFourth">The type of the Fourth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the Fourth state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TThird, TOutputFourth, TLast}"/> in the appropriate state.
    /// </returns>
    public Either<TFirst, TSecond, TThird, TOutputFourth, TLast> BindFourth<TOutputFourth>(
        Func<TFourth, Either<TFirst, TSecond, TThird, TOutputFourth, TLast>> bindFunc)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TThird, TOutputFourth, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TThird, TOutputFourth, TLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TThird, TOutputFourth, TLast>.Third(_third!),
            EitherState.Fourth => bindFunc(_fourth!),
            EitherState.Last => Either<TFirst, TSecond, TThird, TOutputFourth, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Last state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TThird, TFourth, TOutputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="bindFunc">The func to apply if in the Last state.</param>
    /// <typeparam name="TOutputLast">The type of the Last output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the Last state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TThird, TFourth, TOutputLast}"/> in the appropriate state.
    /// </returns>
    public Either<TFirst, TSecond, TThird, TFourth, TOutputLast> BindLast<TOutputLast>(
        Func<TLast, Either<TFirst, TSecond, TThird, TFourth, TOutputLast>> bindFunc)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TThird, TFourth, TOutputLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TThird, TFourth, TOutputLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TThird, TFourth, TOutputLast>.Third(_third!),
            EitherState.Fourth => Either<TFirst, TSecond, TThird, TFourth, TOutputLast>.Fourth(_fourth!),
            EitherState.Last => bindFunc(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TSecond, TThird, TFourth, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="bindFunc">The asynchronous func to apply if in the First state.</param>
    /// <typeparam name="TOutputFirst">The type of the First output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TSecond, TThird, TFourth, TLast}"/> in the appropriate state.
    /// </returns>
    public async Task<Either<TOutputFirst, TSecond, TThird, TFourth, TLast>> BindFirstAsync<TOutputFirst>(
        Func<TFirst, Task<Either<TOutputFirst, TSecond, TThird, TFourth, TLast>>> bindFunc)
    {
        return _state switch
        {
            EitherState.First => await bindFunc(_first!),
            EitherState.Second => Either<TOutputFirst, TSecond, TThird, TFourth, TLast>.Second(_second!),
            EitherState.Third => Either<TOutputFirst, TSecond, TThird, TFourth, TLast>.Third(_third!),
            EitherState.Fourth => Either<TOutputFirst, TSecond, TThird, TFourth, TLast>.Fourth(_fourth!),
            EitherState.Last => Either<TOutputFirst, TSecond, TThird, TFourth, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TOutputSecond, TThird, TFourth, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="bindFunc">The asynchronous func to apply if in the Second state.</param>
    /// <typeparam name="TOutputSecond">The type of the Second output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TOutputSecond, TThird, TFourth, TLast}"/> in the appropriate state.
    /// </returns>
    public async Task<Either<TFirst, TOutputSecond, TThird, TFourth, TLast>> BindSecondAsync<TOutputSecond>(
        Func<TSecond, Task<Either<TFirst, TOutputSecond, TThird, TFourth, TLast>>> bindFunc)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TOutputSecond, TThird, TFourth, TLast>.First(_first!),
            EitherState.Second => await bindFunc(_second!),
            EitherState.Third => Either<TFirst, TOutputSecond, TThird, TFourth, TLast>.Third(_third!),
            EitherState.Fourth => Either<TFirst, TOutputSecond, TThird, TFourth, TLast>.Fourth(_fourth!),
            EitherState.Last => Either<TFirst, TOutputSecond, TThird, TFourth, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TOutputThird, TFourth, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="bindFunc">The asynchronous func to apply if in the Third state.</param>
    /// <typeparam name="TOutputThird">The type of the Third output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TOutputThird, TFourth, TLast}"/> in the appropriate state.
    /// </returns>
    public async Task<Either<TFirst, TSecond, TOutputThird, TFourth, TLast>> BindThirdAsync<TOutputThird>(
        Func<TThird, Task<Either<TFirst, TSecond, TOutputThird, TFourth, TLast>>> bindFunc)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TOutputThird, TFourth, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TOutputThird, TFourth, TLast>.Second(_second!),
            EitherState.Third => await bindFunc(_third!),
            EitherState.Fourth => Either<TFirst, TSecond, TOutputThird, TFourth, TLast>.Fourth(_fourth!),
            EitherState.Last => Either<TFirst, TSecond, TOutputThird, TFourth, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Fourth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TThird, TOutputFourth, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="bindFunc">The asynchronous func to apply if in the Fourth state.</param>
    /// <typeparam name="TOutputFourth">The type of the Fourth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the Fourth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TThird, TOutputFourth, TLast}"/> in the appropriate state.
    /// </returns>
    public async Task<Either<TFirst, TSecond, TThird, TOutputFourth, TLast>> BindFourthAsync<TOutputFourth>(
        Func<TFourth, Task<Either<TFirst, TSecond, TThird, TOutputFourth, TLast>>> bindFunc)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TThird, TOutputFourth, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TThird, TOutputFourth, TLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TThird, TOutputFourth, TLast>.Third(_third!),
            EitherState.Fourth => await bindFunc(_fourth!),
            EitherState.Last => Either<TFirst, TSecond, TThird, TOutputFourth, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TThird, TFourth, TOutputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="bindFunc">The asynchronous func to apply if in the Last state.</param>
    /// <typeparam name="TOutputLast">The type of the Last output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TThird, TFourth, TOutputLast}"/> in the appropriate state.
    /// </returns>
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TOutputLast>> BindLastAsync<TOutputLast>(
        Func<TLast, Task<Either<TFirst, TSecond, TThird, TFourth, TOutputLast>>> bindFunc)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TThird, TFourth, TOutputLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TThird, TFourth, TOutputLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TThird, TFourth, TOutputLast>.Third(_third!),
            EitherState.Fourth => Either<TFirst, TSecond, TThird, TFourth, TOutputLast>.Fourth(_fourth!),
            EitherState.Last => await bindFunc(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TOutputFirst, TSecond, TThird, TFourth, TLast}"/> when it's in the First state,
    ///      otherwise returns <see cref="Either{TOutputFirst, TSecond, TThird, TFourth, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputFirst"/>.</param>
    /// <typeparam name="TOutputFirst">The type of the transformed First output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the First state,
    ///      otherwise returns <see cref="Either{TOutputFirst, TSecond, TThird, TFourth, TLast}"/> in the appropriate state.
    /// </returns>
    public Either<TOutputFirst, TSecond, TThird, TFourth, TLast> MapFirst<TOutputFirst>(
        Func<TFirst, TOutputFirst> transform)
    {
        return _state switch
        {
            EitherState.First => Either<TOutputFirst, TSecond, TThird, TFourth, TLast>.First(transform(_first!)),
            EitherState.Second => Either<TOutputFirst, TSecond, TThird, TFourth, TLast>.Second(_second!),
            EitherState.Third => Either<TOutputFirst, TSecond, TThird, TFourth, TLast>.Third(_third!),
            EitherState.Fourth => Either<TOutputFirst, TSecond, TThird, TFourth, TLast>.Fourth(_fourth!),
            EitherState.Last => Either<TOutputFirst, TSecond, TThird, TFourth, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TFirst, TOutputSecond, TThird, TFourth, TLast}"/> when it's in the Second state,
    ///      otherwise returns <see cref="Either{TFirst, TOutputSecond, TThird, TFourth, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputSecond"/>.</param>
    /// <typeparam name="TOutputSecond">The type of the transformed Second output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Second state,
    ///      otherwise returns <see cref="Either{TFirst, TOutputSecond, TThird, TFourth, TLast}"/> in the appropriate state.
    /// </returns>
    public Either<TFirst, TOutputSecond, TThird, TFourth, TLast> MapSecond<TOutputSecond>(
        Func<TSecond, TOutputSecond> transform)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TOutputSecond, TThird, TFourth, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TOutputSecond, TThird, TFourth, TLast>.Second(transform(_second!)),
            EitherState.Third => Either<TFirst, TOutputSecond, TThird, TFourth, TLast>.Third(_third!),
            EitherState.Fourth => Either<TFirst, TOutputSecond, TThird, TFourth, TLast>.Fourth(_fourth!),
            EitherState.Last => Either<TFirst, TOutputSecond, TThird, TFourth, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TFirst, TSecond, TOutputThird, TFourth, TLast}"/> when it's in the Third state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TOutputThird, TFourth, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputThird"/>.</param>
    /// <typeparam name="TOutputThird">The type of the transformed Third output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Third state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TOutputThird, TFourth, TLast}"/> in the appropriate state.
    /// </returns>
    public Either<TFirst, TSecond, TOutputThird, TFourth, TLast> MapThird<TOutputThird>(
        Func<TThird, TOutputThird> transform)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TOutputThird, TFourth, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TOutputThird, TFourth, TLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TOutputThird, TFourth, TLast>.Third(transform(_third!)),
            EitherState.Fourth => Either<TFirst, TSecond, TOutputThird, TFourth, TLast>.Fourth(_fourth!),
            EitherState.Last => Either<TFirst, TSecond, TOutputThird, TFourth, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TFirst, TSecond, TThird, TOutputFourth, TLast}"/> when it's in the Fourth state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TThird, TOutputFourth, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputFourth"/>.</param>
    /// <typeparam name="TOutputFourth">The type of the transformed Fourth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Fourth state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TThird, TOutputFourth, TLast}"/> in the appropriate state.
    /// </returns>
    public Either<TFirst, TSecond, TThird, TOutputFourth, TLast> MapFourth<TOutputFourth>(
        Func<TFourth, TOutputFourth> transform)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TThird, TOutputFourth, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TThird, TOutputFourth, TLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TThird, TOutputFourth, TLast>.Third(_third!),
            EitherState.Fourth => Either<TFirst, TSecond, TThird, TOutputFourth, TLast>.Fourth(transform(_fourth!)),
            EitherState.Last => Either<TFirst, TSecond, TThird, TOutputFourth, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TFirst, TSecond, TThird, TFourth, TOutputLast}"/> when it's in the Last state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TThird, TFourth, TOutputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputLast"/>.</param>
    /// <typeparam name="TOutputLast">The type of the transformed Last output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Last state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TThird, TFourth, TOutputLast}"/> in the appropriate state.
    /// </returns>
    public Either<TFirst, TSecond, TThird, TFourth, TOutputLast> MapLast<TOutputLast>(
        Func<TLast, TOutputLast> transform)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TThird, TFourth, TOutputLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TThird, TFourth, TOutputLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TThird, TFourth, TOutputLast>.Third(_third!),
            EitherState.Fourth => Either<TFirst, TSecond, TThird, TFourth, TOutputLast>.Fourth(_fourth!),
            EitherState.Last => Either<TFirst, TSecond, TThird, TFourth, TOutputLast>.Last(transform(_last!)),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TOutputFirst, TSecond, TThird, TFourth, TLast}"/> when it's in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TSecond, TThird, TFourth, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="transform">The asynchronous function to transform to <typeparamref name="TOutputFirst"/>.</param>
    /// <typeparam name="TOutputFirst">The type of the transformed First output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TSecond, TThird, TFourth, TLast}"/> in the appropriate state.
    /// </returns>
    public async Task<Either<TOutputFirst, TSecond, TThird, TFourth, TLast>> MapFirstAsync<TOutputFirst>(
        Func<TFirst, Task<TOutputFirst>> transform)
    {
        return _state switch
        {
            EitherState.First => Either<TOutputFirst, TSecond, TThird, TFourth, TLast>.First(await transform(_first!)),
            EitherState.Second => Either<TOutputFirst, TSecond, TThird, TFourth, TLast>.Second(_second!),
            EitherState.Third => Either<TOutputFirst, TSecond, TThird, TFourth, TLast>.Third(_third!),
            EitherState.Fourth => Either<TOutputFirst, TSecond, TThird, TFourth, TLast>.Fourth(_fourth!),
            EitherState.Last => Either<TOutputFirst, TSecond, TThird, TFourth, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TFirst, TOutputSecond, TThird, TFourth, TLast}"/> when it's in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TOutputSecond, TThird, TFourth, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="transform">The asynchronous function to transform to <typeparamref name="TOutputSecond"/>.</param>
    /// <typeparam name="TOutputSecond">The type of the transformed Second output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TOutputSecond, TThird, TFourth, TLast}"/> in the appropriate state.
    /// </returns>
    public async Task<Either<TFirst, TOutputSecond, TThird, TFourth, TLast>> MapSecondAsync<TOutputSecond>(
        Func<TSecond, Task<TOutputSecond>> transform)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TOutputSecond, TThird, TFourth, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TOutputSecond, TThird, TFourth, TLast>.Second(await transform(_second!)),
            EitherState.Third => Either<TFirst, TOutputSecond, TThird, TFourth, TLast>.Third(_third!),
            EitherState.Fourth => Either<TFirst, TOutputSecond, TThird, TFourth, TLast>.Fourth(_fourth!),
            EitherState.Last => Either<TFirst, TOutputSecond, TThird, TFourth, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TFirst, TSecond, TOutputThird, TFourth, TLast}"/> when it's in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TOutputThird, TFourth, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="transform">The asynchronous function to transform to <typeparamref name="TOutputThird"/>.</param>
    /// <typeparam name="TOutputThird">The type of the transformed Third output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TOutputThird, TFourth, TLast}"/> in the appropriate state.
    /// </returns>
    public async Task<Either<TFirst, TSecond, TOutputThird, TFourth, TLast>> MapThirdAsync<TOutputThird>(
        Func<TThird, Task<TOutputThird>> transform)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TOutputThird, TFourth, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TOutputThird, TFourth, TLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TOutputThird, TFourth, TLast>.Third(await transform(_third!)),
            EitherState.Fourth => Either<TFirst, TSecond, TOutputThird, TFourth, TLast>.Fourth(_fourth!),
            EitherState.Last => Either<TFirst, TSecond, TOutputThird, TFourth, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TFirst, TSecond, TThird, TOutputFourth, TLast}"/> when it's in the Fourth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TThird, TOutputFourth, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="transform">The asynchronous function to transform to <typeparamref name="TOutputFourth"/>.</param>
    /// <typeparam name="TOutputFourth">The type of the transformed Fourth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Fourth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TThird, TOutputFourth, TLast}"/> in the appropriate state.
    /// </returns>
    public async Task<Either<TFirst, TSecond, TThird, TOutputFourth, TLast>> MapFourthAsync<TOutputFourth>(
        Func<TFourth, Task<TOutputFourth>> transform)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TThird, TOutputFourth, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TThird, TOutputFourth, TLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TThird, TOutputFourth, TLast>.Third(_third!),
            EitherState.Fourth => Either<TFirst, TSecond, TThird, TOutputFourth, TLast>.Fourth(await transform(_fourth!)),
            EitherState.Last => Either<TFirst, TSecond, TThird, TOutputFourth, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TFirst, TSecond, TThird, TFourth, TOutputLast}"/> when it's in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TThird, TFourth, TOutputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="transform">The asynchronous function to transform to <typeparamref name="TOutputLast"/>.</param>
    /// <typeparam name="TOutputLast">The type of the transformed Last output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TThird, TFourth, TOutputLast}"/> in the appropriate state.
    /// </returns>
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TOutputLast>> MapLastAsync<TOutputLast>(
        Func<TLast, Task<TOutputLast>> transform)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TThird, TFourth, TOutputLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TThird, TFourth, TOutputLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TThird, TFourth, TOutputLast>.Third(_third!),
            EitherState.Fourth => Either<TFirst, TSecond, TThird, TFourth, TOutputLast>.Fourth(_fourth!),
            EitherState.Last => Either<TFirst, TSecond, TThird, TFourth, TOutputLast>.Last(await transform(_last!)),
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the First state.
    /// </summary>
    /// <param name="action">The action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public Either<TFirst, TSecond, TThird, TFourth, TLast> OnFirst(Action<TFirst> action)
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
    public Either<TFirst, TSecond, TThird, TFourth, TLast> OnFirst(Func<TFirst, Unit> action)
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
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> OnFirstAsync(Func<TFirst, Task> action)
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
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> OnFirstAsync(Func<TFirst, Task<Unit>> action)
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
    public Either<TFirst, TSecond, TThird, TFourth, TLast> OnSecond(Action<TSecond> action)
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
    public Either<TFirst, TSecond, TThird, TFourth, TLast> OnSecond(Func<TSecond, Unit> action)
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
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> OnSecondAsync(Func<TSecond, Task> action)
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
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> OnSecondAsync(Func<TSecond, Task<Unit>> action)
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
    public Either<TFirst, TSecond, TThird, TFourth, TLast> OnThird(Action<TThird> action)
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
    public Either<TFirst, TSecond, TThird, TFourth, TLast> OnThird(Func<TThird, Unit> action)
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
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> OnThirdAsync(Func<TThird, Task> action)
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
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> OnThirdAsync(Func<TThird, Task<Unit>> action)
    {
        if (_state is EitherState.Third)
        {
            await action(_third!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Fourth state.
    /// </summary>
    /// <param name="action">The action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public Either<TFirst, TSecond, TThird, TFourth, TLast> OnFourth(Action<TFourth> action)
    {
        if (_state is EitherState.Fourth)
        {
            action(_fourth!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Fourth state.
    /// </summary>
    /// <param name="action">The action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public Either<TFirst, TSecond, TThird, TFourth, TLast> OnFourth(Func<TFourth, Unit> action)
    {
        if (_state is EitherState.Fourth)
        {
            action(_fourth!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Fourth state.
    /// </summary>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> OnFourthAsync(Func<TFourth, Task> action)
    {
        if (_state is EitherState.Fourth)
        {
            await action(_fourth!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Fourth state.
    /// </summary>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> OnFourthAsync(Func<TFourth, Task<Unit>> action)
    {
        if (_state is EitherState.Fourth)
        {
            await action(_fourth!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Last state.
    /// </summary>
    /// <param name="action">The action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public Either<TFirst, TSecond, TThird, TFourth, TLast> OnLast(Action<TLast> action)
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
    public Either<TFirst, TSecond, TThird, TFourth, TLast> OnLast(Func<TLast, Unit> action)
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
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> OnLastAsync(Func<TLast, Task> action)
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
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> OnLastAsync(Func<TLast, Task<Unit>> action)
    {
        if (_state is EitherState.Last)
        {
            await action(_last!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the relevant action based on the current state.
    /// </summary>
    /// <param name="first">The action to perform if in the First state.</param>
    /// <param name="second">The action to perform if in the Second state.</param>
    /// <param name="third">The action to perform if in the Third state.</param>
    /// <param name="fourth">The action to perform if in the Fourth state.</param>
    /// <param name="last">The action to perform if in the Last state.</param>
    /// <returns>The current object after possibly performing the action.</returns>
    public Either<TFirst, TSecond, TThird, TFourth, TLast> Perform(
        Action<TFirst>? first = null,
        Action<TSecond>? second = null,
        Action<TThird>? third = null,
        Action<TFourth>? fourth = null,
        Action<TLast>? last = null)
    {
        switch (_state)
        {
            case EitherState.First:
                if (first is not null)
                {
                    first(_first!);
                }
                break;
            case EitherState.Second:
                if (second is not null)
                {
                    second(_second!);
                }
                break;
            case EitherState.Third:
                if (third is not null)
                {
                    third(_third!);
                }
                break;
            case EitherState.Fourth:
                if (fourth is not null)
                {
                    fourth(_fourth!);
                }
                break;
            case EitherState.Last:
                if (last is not null)
                {
                    last(_last!);
                }
                break;
            default:
                throw new InvalidOperationException("Invalid state.");
        }
        
        return this;
    }

    /// <summary>
    ///      Performs the relevant action based on the current state.
    /// </summary>
    /// <param name="first">The action to perform if in the First state.</param>
    /// <param name="second">The action to perform if in the Second state.</param>
    /// <param name="third">The action to perform if in the Third state.</param>
    /// <param name="fourth">The action to perform if in the Fourth state.</param>
    /// <param name="last">The action to perform if in the Last state.</param>
    /// <returns>The current object after possibly performing the action.</returns>
    public Either<TFirst, TSecond, TThird, TFourth, TLast> Perform(
        Func<TFirst, Unit>? first = null,
        Func<TSecond, Unit>? second = null,
        Func<TThird, Unit>? third = null,
        Func<TFourth, Unit>? fourth = null,
        Func<TLast, Unit>? last = null)
    {
        switch (_state)
        {
            case EitherState.First:
                if (first is not null)
                {
                    first(_first!);
                }
                break;
            case EitherState.Second:
                if (second is not null)
                {
                    second(_second!);
                }
                break;
            case EitherState.Third:
                if (third is not null)
                {
                    third(_third!);
                }
                break;
            case EitherState.Fourth:
                if (fourth is not null)
                {
                    fourth(_fourth!);
                }
                break;
            case EitherState.Last:
                if (last is not null)
                {
                    last(_last!);
                }
                break;
            default:
                throw new InvalidOperationException("Invalid state.");
        }
        
        return this;
    }

    /// <summary>
    ///      Performs the relevant action based on the current state.
    /// </summary>
    /// <param name="first">The asynchronous action to perform if in the First state.</param>
    /// <param name="second">The asynchronous action to perform if in the Second state.</param>
    /// <param name="third">The asynchronous action to perform if in the Third state.</param>
    /// <param name="fourth">The asynchronous action to perform if in the Fourth state.</param>
    /// <param name="last">The asynchronous action to perform if in the Last state.</param>
    /// <returns>The current object after possibly performing the action.</returns>
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> PerformAsync(
        Func<TFirst, Task>? first = null,
        Func<TSecond, Task>? second = null,
        Func<TThird, Task>? third = null,
        Func<TFourth, Task>? fourth = null,
        Func<TLast, Task>? last = null)
    {
        switch (_state)
        {
            case EitherState.First:
                if (first is not null)
                {
                    await first(_first!);
                }
                break;
            case EitherState.Second:
                if (second is not null)
                {
                    await second(_second!);
                }
                break;
            case EitherState.Third:
                if (third is not null)
                {
                    await third(_third!);
                }
                break;
            case EitherState.Fourth:
                if (fourth is not null)
                {
                    await fourth(_fourth!);
                }
                break;
            case EitherState.Last:
                if (last is not null)
                {
                    await last(_last!);
                }
                break;
            default:
                throw new InvalidOperationException("Invalid state.");
        }
        
        return this;
    }

    /// <summary>
    ///      Performs the relevant action based on the current state.
    /// </summary>
    /// <param name="first">The asynchronous action to perform if in the First state.</param>
    /// <param name="second">The asynchronous action to perform if in the Second state.</param>
    /// <param name="third">The asynchronous action to perform if in the Third state.</param>
    /// <param name="fourth">The asynchronous action to perform if in the Fourth state.</param>
    /// <param name="last">The asynchronous action to perform if in the Last state.</param>
    /// <returns>The current object after possibly performing the action.</returns>
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> PerformAsync(
        Func<TFirst, Task<Unit>>? first = null,
        Func<TSecond, Task<Unit>>? second = null,
        Func<TThird, Task<Unit>>? third = null,
        Func<TFourth, Task<Unit>>? fourth = null,
        Func<TLast, Task<Unit>>? last = null)
    {
        switch (_state)
        {
            case EitherState.First:
                if (first is not null)
                {
                    await first(_first!);
                }
                break;
            case EitherState.Second:
                if (second is not null)
                {
                    await second(_second!);
                }
                break;
            case EitherState.Third:
                if (third is not null)
                {
                    await third(_third!);
                }
                break;
            case EitherState.Fourth:
                if (fourth is not null)
                {
                    await fourth(_fourth!);
                }
                break;
            case EitherState.Last:
                if (last is not null)
                {
                    await last(_last!);
                }
                break;
            default:
                throw new InvalidOperationException("Invalid state.");
        }
        
        return this;
    }

    /// <summary>
    ///      Constructs <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> from a <typeparamref name="TFirst"/> in the First state.
    /// </summary>
    /// <param name="first">The value to construct the <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> type from.</param>
    /// <returns>The <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> type in the First state.</returns>
    public static Either<TFirst, TSecond, TThird, TFourth, TLast> First(TFirst first)
    {
        return new Either<TFirst, TSecond, TThird, TFourth, TLast>(first);
    }

    /// <summary>
    ///      Constructs <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> from a <typeparamref name="TSecond"/> in the Second state.
    /// </summary>
    /// <param name="second">The value to construct the <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> type from.</param>
    /// <returns>The <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> type in the Second state.</returns>
    public static Either<TFirst, TSecond, TThird, TFourth, TLast> Second(TSecond second)
    {
        return new Either<TFirst, TSecond, TThird, TFourth, TLast>(second);
    }

    /// <summary>
    ///      Constructs <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> from a <typeparamref name="TThird"/> in the Third state.
    /// </summary>
    /// <param name="third">The value to construct the <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> type from.</param>
    /// <returns>The <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> type in the Third state.</returns>
    public static Either<TFirst, TSecond, TThird, TFourth, TLast> Third(TThird third)
    {
        return new Either<TFirst, TSecond, TThird, TFourth, TLast>(third);
    }

    /// <summary>
    ///      Constructs <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> from a <typeparamref name="TFourth"/> in the Fourth state.
    /// </summary>
    /// <param name="fourth">The value to construct the <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> type from.</param>
    /// <returns>The <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> type in the Fourth state.</returns>
    public static Either<TFirst, TSecond, TThird, TFourth, TLast> Fourth(TFourth fourth)
    {
        return new Either<TFirst, TSecond, TThird, TFourth, TLast>(fourth);
    }

    /// <summary>
    ///      Constructs <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> from a <typeparamref name="TLast"/> in the Last state.
    /// </summary>
    /// <param name="last">The value to construct the <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> type from.</param>
    /// <returns>The <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/> type in the Last state.</returns>
    public static Either<TFirst, TSecond, TThird, TFourth, TLast> Last(TLast last)
    {
        return new Either<TFirst, TSecond, TThird, TFourth, TLast>(last);
    }
}