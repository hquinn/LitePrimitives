// ReSharper disable once CheckNamespace

using LitePrimitives.Enums;

namespace LitePrimitives;

/// <summary>
///     Represents a value of one of eight possible types (a disjointed union).
///     This type can encapsulate either:
///     - <typeparamref name="TFirst"/> in the First state.
///     - <typeparamref name="TSecond"/> in the Second state.
///     - <typeparamref name="TThird"/> in the Third state.
///     - <typeparamref name="TFourth"/> in the Fourth state.
///     - <typeparamref name="TFifth"/> in the Fifth state.
///     - <typeparamref name="TSixth"/> in the Sixth state.
///     - <typeparamref name="TSeventh"/> in the Seventh state.
///     - <typeparamref name="TLast"/> in the Last state.
///     But not all at once.
/// </summary>
/// <typeparam name="TFirst">The type of the First state.</typeparam>
/// <typeparam name="TSecond">The type of the Second state.</typeparam>
/// <typeparam name="TThird">The type of the Third state.</typeparam>
/// <typeparam name="TFourth">The type of the Fourth state.</typeparam>
/// <typeparam name="TFifth">The type of the Fifth state.</typeparam>
/// <typeparam name="TSixth">The type of the Sixth state.</typeparam>
/// <typeparam name="TSeventh">The type of the Seventh state.</typeparam>
/// <typeparam name="TLast">The type of the Last state.</typeparam>
public readonly struct Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>
{
    private readonly EitherState _state;
    private readonly TFirst? _first;
    private readonly TSecond? _second;
    private readonly TThird? _third;
    private readonly TFourth? _fourth;
    private readonly TFifth? _fifth;
    private readonly TSixth? _sixth;
    private readonly TSeventh? _seventh;
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

    private Either(TFifth fifth)
    {
        _fifth = fifth;
        _state = EitherState.Fifth;
    }

    private Either(TSixth sixth)
    {
        _sixth = sixth;
        _state = EitherState.Sixth;
    }

    private Either(TSeventh seventh)
    {
        _seventh = seventh;
        _state = EitherState.Seventh;
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
    ///     - <paramref name="fourth"/> if in the Fourth state.
    ///     - <paramref name="fifth"/> if in the Fifth state.
    ///     - <paramref name="sixth"/> if in the Sixth state.
    ///     - <paramref name="seventh"/> if in the Seventh state.
    ///     - <paramref name="last"/> if in the Last state.
    ///     The output is of type <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="first">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> is in the First state.</param>
    /// <param name="second">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> is in the Second state.</param>
    /// <param name="third">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> is in the Third state.</param>
    /// <param name="fourth">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> is in the Fourth state.</param>
    /// <param name="fifth">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> is in the Fifth state.</param>
    /// <param name="sixth">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> is in the Sixth state.</param>
    /// <param name="seventh">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> is in the Seventh state.</param>
    /// <param name="last">The func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> is in the Last state.</param>
    /// <typeparam name="TOutput">The output of the match.</typeparam>
    /// <returns>The output of the match.</returns>
    public TOutput Match<TOutput>(
        Func<TFirst, TOutput> first,
        Func<TSecond, TOutput> second,
        Func<TThird, TOutput> third,
        Func<TFourth, TOutput> fourth,
        Func<TFifth, TOutput> fifth,
        Func<TSixth, TOutput> sixth,
        Func<TSeventh, TOutput> seventh,
        Func<TLast, TOutput> last)
    {
        return _state switch
        {
            EitherState.First => first(_first!),
            EitherState.Second => second(_second!),
            EitherState.Third => third(_third!),
            EitherState.Fourth => fourth(_fourth!),
            EitherState.Fifth => fifth(_fifth!),
            EitherState.Sixth => sixth(_sixth!),
            EitherState.Seventh => seventh(_seventh!),
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
    ///     - <paramref name="fifth"/> if in the Fifth state.
    ///     - <paramref name="sixth"/> if in the Sixth state.
    ///     - <paramref name="seventh"/> if in the Seventh state.
    ///     - <paramref name="last"/> if in the Last state.
    ///     The output is of type <see cref="Task"/> of <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="first">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> is in the First state.</param>
    /// <param name="second">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> is in the Second state.</param>
    /// <param name="third">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> is in the Third state.</param>
    /// <param name="fourth">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> is in the Fourth state.</param>
    /// <param name="fifth">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> is in the Fifth state.</param>
    /// <param name="sixth">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> is in the Sixth state.</param>
    /// <param name="seventh">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> is in the Seventh state.</param>
    /// <param name="last">The asynchronous func to use if <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> is in the Last state.</param>
    /// <typeparam name="TOutput">The output of the match.</typeparam>
    /// <returns>The output of the match.</returns>
    public async Task<TOutput> MatchAsync<TOutput>(
        Func<TFirst, Task<TOutput>> first,
        Func<TSecond, Task<TOutput>> second,
        Func<TThird, Task<TOutput>> third,
        Func<TFourth, Task<TOutput>> fourth,
        Func<TFifth, Task<TOutput>> fifth,
        Func<TSixth, Task<TOutput>> sixth,
        Func<TSeventh, Task<TOutput>> seventh,
        Func<TLast, Task<TOutput>> last)
    {
        return _state switch
        {
            EitherState.First => await first(_first!),
            EitherState.Second => await second(_second!),
            EitherState.Third => await third(_third!),
            EitherState.Fourth => await fourth(_fourth!),
            EitherState.Fifth => await fifth(_fifth!),
            EitherState.Sixth => await sixth(_sixth!),
            EitherState.Seventh => await seventh(_seventh!),
            EitherState.Last => await last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the First state,
    ///      otherwise returns <see cref="Either{TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="bindFunc">The func to apply if in the First state.</param>
    /// <typeparam name="TOutputFirst">The type of the First output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the First state,
    ///      otherwise returns <see cref="Either{TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </returns>
    public Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast> BindFirst<TOutputFirst>(
        Func<TFirst, Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> bindFunc)
    {
        return _state switch
        {
            EitherState.First => bindFunc(_first!),
            EitherState.Second => Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Second(_second!),
            EitherState.Third => Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Third(_third!),
            EitherState.Fourth => Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Fourth(_fourth!),
            EitherState.Fifth => Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Fifth(_fifth!),
            EitherState.Sixth => Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Sixth(_sixth!),
            EitherState.Seventh => Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Seventh(_seventh!),
            EitherState.Last => Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Second state,
    ///      otherwise returns <see cref="Either{TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="bindFunc">The func to apply if in the Second state.</param>
    /// <typeparam name="TOutputSecond">The type of the Second output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the Second state,
    ///      otherwise returns <see cref="Either{TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </returns>
    public Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast> BindSecond<TOutputSecond>(
        Func<TSecond, Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> bindFunc)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.First(_first!),
            EitherState.Second => bindFunc(_second!),
            EitherState.Third => Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Third(_third!),
            EitherState.Fourth => Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Fourth(_fourth!),
            EitherState.Fifth => Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Fifth(_fifth!),
            EitherState.Sixth => Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Sixth(_sixth!),
            EitherState.Seventh => Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Seventh(_seventh!),
            EitherState.Last => Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Third state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="bindFunc">The func to apply if in the Third state.</param>
    /// <typeparam name="TOutputThird">The type of the Third output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the Third state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </returns>
    public Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast> BindThird<TOutputThird>(
        Func<TThird, Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast>> bindFunc)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Second(_second!),
            EitherState.Third => bindFunc(_third!),
            EitherState.Fourth => Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Fourth(_fourth!),
            EitherState.Fifth => Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Fifth(_fifth!),
            EitherState.Sixth => Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Sixth(_sixth!),
            EitherState.Seventh => Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Seventh(_seventh!),
            EitherState.Last => Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Fourth state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="bindFunc">The func to apply if in the Fourth state.</param>
    /// <typeparam name="TOutputFourth">The type of the Fourth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the Fourth state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </returns>
    public Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast> BindFourth<TOutputFourth>(
        Func<TFourth, Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast>> bindFunc)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast>.Third(_third!),
            EitherState.Fourth => bindFunc(_fourth!),
            EitherState.Fifth => Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast>.Fifth(_fifth!),
            EitherState.Sixth => Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast>.Sixth(_sixth!),
            EitherState.Seventh => Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast>.Seventh(_seventh!),
            EitherState.Last => Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Fifth state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="bindFunc">The func to apply if in the Fifth state.</param>
    /// <typeparam name="TOutputFifth">The type of the Fifth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the Fifth state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </returns>
    public Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast> BindFifth<TOutputFifth>(
        Func<TFifth, Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast>> bindFunc)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast>.Third(_third!),
            EitherState.Fourth => Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast>.Fourth(_fourth!),
            EitherState.Fifth => bindFunc(_fifth!),
            EitherState.Sixth => Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast>.Sixth(_sixth!),
            EitherState.Seventh => Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast>.Seventh(_seventh!),
            EitherState.Last => Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Sixth state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="bindFunc">The func to apply if in the Sixth state.</param>
    /// <typeparam name="TOutputSixth">The type of the Sixth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the Sixth state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </returns>
    public Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast> BindSixth<TOutputSixth>(
        Func<TSixth, Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast>> bindFunc)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast>.Third(_third!),
            EitherState.Fourth => Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast>.Fourth(_fourth!),
            EitherState.Fifth => Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast>.Fifth(_fifth!),
            EitherState.Sixth => bindFunc(_sixth!),
            EitherState.Seventh => Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast>.Seventh(_seventh!),
            EitherState.Last => Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Seventh state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="bindFunc">The func to apply if in the Seventh state.</param>
    /// <typeparam name="TOutputSeventh">The type of the Seventh output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the Seventh state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast}"/> in the appropriate state.
    /// </returns>
    public Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast> BindSeventh<TOutputSeventh>(
        Func<TSeventh, Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast>> bindFunc)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast>.Third(_third!),
            EitherState.Fourth => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast>.Fourth(_fourth!),
            EitherState.Fifth => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast>.Fifth(_fifth!),
            EitherState.Sixth => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast>.Sixth(_sixth!),
            EitherState.Seventh => bindFunc(_seventh!),
            EitherState.Last => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Last state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="bindFunc">The func to apply if in the Last state.</param>
    /// <typeparam name="TOutputLast">The type of the Last output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the Last state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast}"/> in the appropriate state.
    /// </returns>
    public Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast> BindLast<TOutputLast>(
        Func<TLast, Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast>> bindFunc)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast>.Third(_third!),
            EitherState.Fourth => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast>.Fourth(_fourth!),
            EitherState.Fifth => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast>.Fifth(_fifth!),
            EitherState.Sixth => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast>.Sixth(_sixth!),
            EitherState.Seventh => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast>.Seventh(_seventh!),
            EitherState.Last => bindFunc(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="bindFunc">The asynchronous func to apply if in the First state.</param>
    /// <typeparam name="TOutputFirst">The type of the First output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </returns>
    public async Task<Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> BindFirstAsync<TOutputFirst>(
        Func<TFirst, Task<Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>>> bindFunc)
    {
        return _state switch
        {
            EitherState.First => await bindFunc(_first!),
            EitherState.Second => Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Second(_second!),
            EitherState.Third => Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Third(_third!),
            EitherState.Fourth => Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Fourth(_fourth!),
            EitherState.Fifth => Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Fifth(_fifth!),
            EitherState.Sixth => Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Sixth(_sixth!),
            EitherState.Seventh => Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Seventh(_seventh!),
            EitherState.Last => Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="bindFunc">The asynchronous func to apply if in the Second state.</param>
    /// <typeparam name="TOutputSecond">The type of the Second output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </returns>
    public async Task<Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> BindSecondAsync<TOutputSecond>(
        Func<TSecond, Task<Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>>> bindFunc)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.First(_first!),
            EitherState.Second => await bindFunc(_second!),
            EitherState.Third => Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Third(_third!),
            EitherState.Fourth => Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Fourth(_fourth!),
            EitherState.Fifth => Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Fifth(_fifth!),
            EitherState.Sixth => Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Sixth(_sixth!),
            EitherState.Seventh => Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Seventh(_seventh!),
            EitherState.Last => Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="bindFunc">The asynchronous func to apply if in the Third state.</param>
    /// <typeparam name="TOutputThird">The type of the Third output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </returns>
    public async Task<Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast>> BindThirdAsync<TOutputThird>(
        Func<TThird, Task<Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast>>> bindFunc)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Second(_second!),
            EitherState.Third => await bindFunc(_third!),
            EitherState.Fourth => Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Fourth(_fourth!),
            EitherState.Fifth => Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Fifth(_fifth!),
            EitherState.Sixth => Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Sixth(_sixth!),
            EitherState.Seventh => Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Seventh(_seventh!),
            EitherState.Last => Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Fourth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="bindFunc">The asynchronous func to apply if in the Fourth state.</param>
    /// <typeparam name="TOutputFourth">The type of the Fourth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the Fourth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </returns>
    public async Task<Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast>> BindFourthAsync<TOutputFourth>(
        Func<TFourth, Task<Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast>>> bindFunc)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast>.Third(_third!),
            EitherState.Fourth => await bindFunc(_fourth!),
            EitherState.Fifth => Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast>.Fifth(_fifth!),
            EitherState.Sixth => Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast>.Sixth(_sixth!),
            EitherState.Seventh => Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast>.Seventh(_seventh!),
            EitherState.Last => Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Fifth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="bindFunc">The asynchronous func to apply if in the Fifth state.</param>
    /// <typeparam name="TOutputFifth">The type of the Fifth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the Fifth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </returns>
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast>> BindFifthAsync<TOutputFifth>(
        Func<TFifth, Task<Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast>>> bindFunc)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast>.Third(_third!),
            EitherState.Fourth => Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast>.Fourth(_fourth!),
            EitherState.Fifth => await bindFunc(_fifth!),
            EitherState.Sixth => Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast>.Sixth(_sixth!),
            EitherState.Seventh => Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast>.Seventh(_seventh!),
            EitherState.Last => Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Sixth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="bindFunc">The asynchronous func to apply if in the Sixth state.</param>
    /// <typeparam name="TOutputSixth">The type of the Sixth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the Sixth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </returns>
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast>> BindSixthAsync<TOutputSixth>(
        Func<TSixth, Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast>>> bindFunc)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast>.Third(_third!),
            EitherState.Fourth => Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast>.Fourth(_fourth!),
            EitherState.Fifth => Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast>.Fifth(_fifth!),
            EitherState.Sixth => await bindFunc(_sixth!),
            EitherState.Seventh => Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast>.Seventh(_seventh!),
            EitherState.Last => Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Seventh state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="bindFunc">The asynchronous func to apply if in the Seventh state.</param>
    /// <typeparam name="TOutputSeventh">The type of the Seventh output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the Seventh state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast}"/> in the appropriate state.
    /// </returns>
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast>> BindSeventhAsync<TOutputSeventh>(
        Func<TSeventh, Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast>>> bindFunc)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast>.Third(_third!),
            EitherState.Fourth => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast>.Fourth(_fourth!),
            EitherState.Fifth => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast>.Fifth(_fifth!),
            EitherState.Sixth => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast>.Sixth(_sixth!),
            EitherState.Seventh => await bindFunc(_seventh!),
            EitherState.Last => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="bindFunc">The asynchronous func to apply if in the Last state.</param>
    /// <typeparam name="TOutputLast">The type of the Last output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast}"/> in the appropriate state.
    /// </returns>
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast>> BindLastAsync<TOutputLast>(
        Func<TLast, Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast>>> bindFunc)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast>.Third(_third!),
            EitherState.Fourth => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast>.Fourth(_fourth!),
            EitherState.Fifth => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast>.Fifth(_fifth!),
            EitherState.Sixth => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast>.Sixth(_sixth!),
            EitherState.Seventh => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast>.Seventh(_seventh!),
            EitherState.Last => await bindFunc(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> when it's in the First state,
    ///      otherwise returns <see cref="Either{TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputFirst"/>.</param>
    /// <typeparam name="TOutputFirst">The type of the transformed First output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the First state,
    ///      otherwise returns <see cref="Either{TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </returns>
    public Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast> MapFirst<TOutputFirst>(
        Func<TFirst, TOutputFirst> transform)
    {
        return _state switch
        {
            EitherState.First => Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.First(transform(_first!)),
            EitherState.Second => Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Second(_second!),
            EitherState.Third => Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Third(_third!),
            EitherState.Fourth => Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Fourth(_fourth!),
            EitherState.Fifth => Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Fifth(_fifth!),
            EitherState.Sixth => Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Sixth(_sixth!),
            EitherState.Seventh => Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Seventh(_seventh!),
            EitherState.Last => Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> when it's in the Second state,
    ///      otherwise returns <see cref="Either{TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputSecond"/>.</param>
    /// <typeparam name="TOutputSecond">The type of the transformed Second output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Second state,
    ///      otherwise returns <see cref="Either{TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </returns>
    public Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast> MapSecond<TOutputSecond>(
        Func<TSecond, TOutputSecond> transform)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Second(transform(_second!)),
            EitherState.Third => Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Third(_third!),
            EitherState.Fourth => Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Fourth(_fourth!),
            EitherState.Fifth => Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Fifth(_fifth!),
            EitherState.Sixth => Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Sixth(_sixth!),
            EitherState.Seventh => Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Seventh(_seventh!),
            EitherState.Last => Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> when it's in the Third state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputThird"/>.</param>
    /// <typeparam name="TOutputThird">The type of the transformed Third output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Third state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </returns>
    public Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast> MapThird<TOutputThird>(
        Func<TThird, TOutputThird> transform)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Third(transform(_third!)),
            EitherState.Fourth => Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Fourth(_fourth!),
            EitherState.Fifth => Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Fifth(_fifth!),
            EitherState.Sixth => Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Sixth(_sixth!),
            EitherState.Seventh => Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Seventh(_seventh!),
            EitherState.Last => Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast}"/> when it's in the Fourth state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputFourth"/>.</param>
    /// <typeparam name="TOutputFourth">The type of the transformed Fourth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Fourth state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </returns>
    public Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast> MapFourth<TOutputFourth>(
        Func<TFourth, TOutputFourth> transform)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast>.Third(_third!),
            EitherState.Fourth => Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast>.Fourth(transform(_fourth!)),
            EitherState.Fifth => Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast>.Fifth(_fifth!),
            EitherState.Sixth => Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast>.Sixth(_sixth!),
            EitherState.Seventh => Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast>.Seventh(_seventh!),
            EitherState.Last => Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast}"/> when it's in the Fifth state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputFifth"/>.</param>
    /// <typeparam name="TOutputFifth">The type of the transformed Fifth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Fifth state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </returns>
    public Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast> MapFifth<TOutputFifth>(
        Func<TFifth, TOutputFifth> transform)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast>.Third(_third!),
            EitherState.Fourth => Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast>.Fourth(_fourth!),
            EitherState.Fifth => Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast>.Fifth(transform(_fifth!)),
            EitherState.Sixth => Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast>.Sixth(_sixth!),
            EitherState.Seventh => Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast>.Seventh(_seventh!),
            EitherState.Last => Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast}"/> when it's in the Sixth state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputSixth"/>.</param>
    /// <typeparam name="TOutputSixth">The type of the transformed Sixth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Sixth state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </returns>
    public Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast> MapSixth<TOutputSixth>(
        Func<TSixth, TOutputSixth> transform)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast>.Third(_third!),
            EitherState.Fourth => Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast>.Fourth(_fourth!),
            EitherState.Fifth => Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast>.Fifth(_fifth!),
            EitherState.Sixth => Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast>.Sixth(transform(_sixth!)),
            EitherState.Seventh => Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast>.Seventh(_seventh!),
            EitherState.Last => Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast}"/> when it's in the Seventh state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputSeventh"/>.</param>
    /// <typeparam name="TOutputSeventh">The type of the transformed Seventh output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Seventh state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast}"/> in the appropriate state.
    /// </returns>
    public Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast> MapSeventh<TOutputSeventh>(
        Func<TSeventh, TOutputSeventh> transform)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast>.Third(_third!),
            EitherState.Fourth => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast>.Fourth(_fourth!),
            EitherState.Fifth => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast>.Fifth(_fifth!),
            EitherState.Sixth => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast>.Sixth(_sixth!),
            EitherState.Seventh => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast>.Seventh(transform(_seventh!)),
            EitherState.Last => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast}"/> when it's in the Last state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputLast"/>.</param>
    /// <typeparam name="TOutputLast">The type of the transformed Last output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Last state,
    ///      otherwise returns <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast}"/> in the appropriate state.
    /// </returns>
    public Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast> MapLast<TOutputLast>(
        Func<TLast, TOutputLast> transform)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast>.Third(_third!),
            EitherState.Fourth => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast>.Fourth(_fourth!),
            EitherState.Fifth => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast>.Fifth(_fifth!),
            EitherState.Sixth => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast>.Sixth(_sixth!),
            EitherState.Seventh => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast>.Seventh(_seventh!),
            EitherState.Last => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast>.Last(transform(_last!)),
            _ => throw new InvalidOperationException("Invalid state.")
        };    
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> when it's in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="transform">The asynchronous function to transform to <typeparamref name="TOutputFirst"/>.</param>
    /// <typeparam name="TOutputFirst">The type of the transformed First output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </returns>
    public async Task<Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> MapFirstAsync<TOutputFirst>(
        Func<TFirst, Task<TOutputFirst>> transform)
    {
        return _state switch
        {
            EitherState.First => Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.First(await transform(_first!)),
            EitherState.Second => Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Second(_second!),
            EitherState.Third => Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Third(_third!),
            EitherState.Fourth => Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Fourth(_fourth!),
            EitherState.Fifth => Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Fifth(_fifth!),
            EitherState.Sixth => Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Sixth(_sixth!),
            EitherState.Seventh => Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Seventh(_seventh!),
            EitherState.Last => Either<TOutputFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> when it's in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="transform">The asynchronous function to transform to <typeparamref name="TOutputSecond"/>.</param>
    /// <typeparam name="TOutputSecond">The type of the transformed Second output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </returns>
    public async Task<Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> MapSecondAsync<TOutputSecond>(
        Func<TSecond, Task<TOutputSecond>> transform)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Second(await transform(_second!)),
            EitherState.Third => Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Third(_third!),
            EitherState.Fourth => Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Fourth(_fourth!),
            EitherState.Fifth => Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Fifth(_fifth!),
            EitherState.Sixth => Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Sixth(_sixth!),
            EitherState.Seventh => Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Seventh(_seventh!),
            EitherState.Last => Either<TFirst, TOutputSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> when it's in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="transform">The asynchronous function to transform to <typeparamref name="TOutputThird"/>.</param>
    /// <typeparam name="TOutputThird">The type of the transformed Third output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </returns>
    public async Task<Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast>> MapThirdAsync<TOutputThird>(
        Func<TThird, Task<TOutputThird>> transform)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Third(await transform(_third!)),
            EitherState.Fourth => Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Fourth(_fourth!),
            EitherState.Fifth => Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Fifth(_fifth!),
            EitherState.Sixth => Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Sixth(_sixth!),
            EitherState.Seventh => Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Seventh(_seventh!),
            EitherState.Last => Either<TFirst, TSecond, TOutputThird, TFourth, TFifth, TSixth, TSeventh, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast}"/> when it's in the Fourth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="transform">The asynchronous function to transform to <typeparamref name="TOutputFourth"/>.</param>
    /// <typeparam name="TOutputFourth">The type of the transformed Fourth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Fourth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </returns>
    public async Task<Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast>> MapFourthAsync<TOutputFourth>(
        Func<TFourth, Task<TOutputFourth>> transform)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast>.Third(_third!),
            EitherState.Fourth => Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast>.Fourth(await transform(_fourth!)),
            EitherState.Fifth => Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast>.Fifth(_fifth!),
            EitherState.Sixth => Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast>.Sixth(_sixth!),
            EitherState.Seventh => Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast>.Seventh(_seventh!),
            EitherState.Last => Either<TFirst, TSecond, TThird, TOutputFourth, TFifth, TSixth, TSeventh, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast}"/> when it's in the Fifth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="transform">The asynchronous function to transform to <typeparamref name="TOutputFifth"/>.</param>
    /// <typeparam name="TOutputFifth">The type of the transformed Fifth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Fifth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </returns>
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast>> MapFifthAsync<TOutputFifth>(
        Func<TFifth, Task<TOutputFifth>> transform)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast>.Third(_third!),
            EitherState.Fourth => Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast>.Fourth(_fourth!),
            EitherState.Fifth => Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast>.Fifth(await transform(_fifth!)),
            EitherState.Sixth => Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast>.Sixth(_sixth!),
            EitherState.Seventh => Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast>.Seventh(_seventh!),
            EitherState.Last => Either<TFirst, TSecond, TThird, TFourth, TOutputFifth, TSixth, TSeventh, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast}"/> when it's in the Sixth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="transform">The asynchronous function to transform to <typeparamref name="TOutputSixth"/>.</param>
    /// <typeparam name="TOutputSixth">The type of the transformed Sixth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Sixth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast}"/> in the appropriate state.
    /// </returns>
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast>> MapSixthAsync<TOutputSixth>(
        Func<TSixth, Task<TOutputSixth>> transform)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast>.Third(_third!),
            EitherState.Fourth => Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast>.Fourth(_fourth!),
            EitherState.Fifth => Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast>.Fifth(_fifth!),
            EitherState.Sixth => Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast>.Sixth(await transform(_sixth!)),
            EitherState.Seventh => Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast>.Seventh(_seventh!),
            EitherState.Last => Either<TFirst, TSecond, TThird, TFourth, TFifth, TOutputSixth, TSeventh, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast}"/> when it's in the Seventh state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="transform">The asynchronous function to transform to <typeparamref name="TOutputSeventh"/>.</param>
    /// <typeparam name="TOutputSeventh">The type of the transformed Seventh output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Seventh state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast}"/> in the appropriate state.
    /// </returns>
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast>> MapSeventhAsync<TOutputSeventh>(
        Func<TSeventh, Task<TOutputSeventh>> transform)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast>.Third(_third!),
            EitherState.Fourth => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast>.Fourth(_fourth!),
            EitherState.Fifth => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast>.Fifth(_fifth!),
            EitherState.Sixth => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast>.Sixth(_sixth!),
            EitherState.Seventh => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast>.Seventh(await transform(_seventh!)),
            EitherState.Last => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TOutputSeventh, TLast>.Last(_last!),
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast}"/> when it's in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="transform">The asynchronous function to transform to <typeparamref name="TOutputLast"/>.</param>
    /// <typeparam name="TOutputLast">The type of the transformed Last output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast}"/> in the appropriate state.
    /// </returns>
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast>> MapLastAsync<TOutputLast>(
        Func<TLast, Task<TOutputLast>> transform)
    {
        return _state switch
        {
            EitherState.First => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast>.First(_first!),
            EitherState.Second => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast>.Second(_second!),
            EitherState.Third => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast>.Third(_third!),
            EitherState.Fourth => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast>.Fourth(_fourth!),
            EitherState.Fifth => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast>.Fifth(_fifth!),
            EitherState.Sixth => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast>.Sixth(_sixth!),
            EitherState.Seventh => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast>.Seventh(_seventh!),
            EitherState.Last => Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TOutputLast>.Last(await transform(_last!)),
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the First state.
    /// </summary>
    /// <param name="action">The action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast> OnFirst(Action<TFirst> action)
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
    public Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast> OnFirst(Func<TFirst, Unit> action)
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
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnFirstAsync(Func<TFirst, Task> action)
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
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnFirstAsync(Func<TFirst, Task<Unit>> action)
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
    public Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast> OnSecond(Action<TSecond> action)
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
    public Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast> OnSecond(Func<TSecond, Unit> action)
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
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnSecondAsync(Func<TSecond, Task> action)
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
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnSecondAsync(Func<TSecond, Task<Unit>> action)
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
    public Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast> OnThird(Action<TThird> action)
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
    public Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast> OnThird(Func<TThird, Unit> action)
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
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnThirdAsync(Func<TThird, Task> action)
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
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnThirdAsync(Func<TThird, Task<Unit>> action)
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
    public Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast> OnFourth(Action<TFourth> action)
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
    public Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast> OnFourth(Func<TFourth, Unit> action)
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
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnFourthAsync(Func<TFourth, Task> action)
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
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnFourthAsync(Func<TFourth, Task<Unit>> action)
    {
        if (_state is EitherState.Fourth)
        {
            await action(_fourth!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Fifth state.
    /// </summary>
    /// <param name="action">The action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast> OnFifth(Action<TFifth> action)
    {
        if (_state is EitherState.Fifth)
        {
            action(_fifth!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Fifth state.
    /// </summary>
    /// <param name="action">The action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast> OnFifth(Func<TFifth, Unit> action)
    {
        if (_state is EitherState.Fifth)
        {
            action(_fifth!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Fifth state.
    /// </summary>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnFifthAsync(Func<TFifth, Task> action)
    {
        if (_state is EitherState.Fifth)
        {
            await action(_fifth!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Fifth state.
    /// </summary>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnFifthAsync(Func<TFifth, Task<Unit>> action)
    {
        if (_state is EitherState.Fifth)
        {
            await action(_fifth!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Sixth state.
    /// </summary>
    /// <param name="action">The action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast> OnSixth(Action<TSixth> action)
    {
        if (_state is EitherState.Sixth)
        {
            action(_sixth!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Sixth state.
    /// </summary>
    /// <param name="action">The action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast> OnSixth(Func<TSixth, Unit> action)
    {
        if (_state is EitherState.Sixth)
        {
            action(_sixth!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Sixth state.
    /// </summary>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnSixthAsync(Func<TSixth, Task> action)
    {
        if (_state is EitherState.Sixth)
        {
            await action(_sixth!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Sixth state.
    /// </summary>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnSixthAsync(Func<TSixth, Task<Unit>> action)
    {
        if (_state is EitherState.Sixth)
        {
            await action(_sixth!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Seventh state.
    /// </summary>
    /// <param name="action">The action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast> OnSeventh(Action<TSeventh> action)
    {
        if (_state is EitherState.Seventh)
        {
            action(_seventh!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Seventh state.
    /// </summary>
    /// <param name="action">The action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast> OnSeventh(Func<TSeventh, Unit> action)
    {
        if (_state is EitherState.Seventh)
        {
            action(_seventh!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Seventh state.
    /// </summary>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnSeventhAsync(Func<TSeventh, Task> action)
    {
        if (_state is EitherState.Seventh)
        {
            await action(_seventh!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Seventh state.
    /// </summary>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnSeventhAsync(Func<TSeventh, Task<Unit>> action)
    {
        if (_state is EitherState.Seventh)
        {
            await action(_seventh!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Last state.
    /// </summary>
    /// <param name="action">The action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast> OnLast(Action<TLast> action)
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
    public Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast> OnLast(Func<TLast, Unit> action)
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
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnLastAsync(Func<TLast, Task> action)
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
    public async Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> OnLastAsync(Func<TLast, Task<Unit>> action)
    {
        if (_state is EitherState.Last)
        {
            await action(_last!);
        }

        return this;
    }

    /// <summary>
    ///      Constructs <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> from a <typeparamref name="TFirst"/> in the First state.
    /// </summary>
    /// <param name="first">The value to construct the <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> type from.</param>
    /// <returns>The <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> type in the First state.</returns>
    public static Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast> First(TFirst first)
    {
        return new Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(first);
    }

    /// <summary>
    ///      Constructs <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> from a <typeparamref name="TSecond"/> in the Second state.
    /// </summary>
    /// <param name="second">The value to construct the <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> type from.</param>
    /// <returns>The <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> type in the Second state.</returns>
    public static Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast> Second(TSecond second)
    {
        return new Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(second);
    }

    /// <summary>
    ///      Constructs <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> from a <typeparamref name="TThird"/> in the Third state.
    /// </summary>
    /// <param name="third">The value to construct the <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> type from.</param>
    /// <returns>The <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> type in the Third state.</returns>
    public static Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast> Third(TThird third)
    {
        return new Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(third);
    }

    /// <summary>
    ///      Constructs <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> from a <typeparamref name="TFourth"/> in the Fourth state.
    /// </summary>
    /// <param name="fourth">The value to construct the <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> type from.</param>
    /// <returns>The <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> type in the Fourth state.</returns>
    public static Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast> Fourth(TFourth fourth)
    {
        return new Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(fourth);
    }

    /// <summary>
    ///      Constructs <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> from a <typeparamref name="TFifth"/> in the Fifth state.
    /// </summary>
    /// <param name="fifth">The value to construct the <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> type from.</param>
    /// <returns>The <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> type in the Fifth state.</returns>
    public static Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast> Fifth(TFifth fifth)
    {
        return new Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(fifth);
    }

    /// <summary>
    ///      Constructs <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> from a <typeparamref name="TSixth"/> in the Sixth state.
    /// </summary>
    /// <param name="sixth">The value to construct the <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> type from.</param>
    /// <returns>The <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> type in the Sixth state.</returns>
    public static Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast> Sixth(TSixth sixth)
    {
        return new Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(sixth);
    }

    /// <summary>
    ///      Constructs <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> from a <typeparamref name="TSeventh"/> in the Seventh state.
    /// </summary>
    /// <param name="seventh">The value to construct the <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> type from.</param>
    /// <returns>The <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> type in the Seventh state.</returns>
    public static Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast> Seventh(TSeventh seventh)
    {
        return new Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(seventh);
    }

    /// <summary>
    ///      Constructs <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> from a <typeparamref name="TLast"/> in the Last state.
    /// </summary>
    /// <param name="last">The value to construct the <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> type from.</param>
    /// <returns>The <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/> type in the Last state.</returns>
    public static Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast> Last(TLast last)
    {
        return new Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(last);
    }
}