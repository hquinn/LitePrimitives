namespace LitePrimitives;

/// <summary>
///     Represents an optional value. This type can encapsulate either a value of type <typeparamref name="TValue"/>
///     when in the Some state, or indicate the absence of a value in the None state. 
/// </summary>
/// <typeparam name="TValue">The type of the value that may be present.</typeparam>
public readonly struct Option<TValue>
{
    private readonly OptionState _state;
    private readonly TValue? _value;

    /// <summary>
    ///     Constructs <see cref="Option{TValue}"/> in the None state.
    /// </summary>
    public Option()
    {
        _value = default;
        _state = OptionState.None;
    }
    
    private Option(TValue value)
    {
        _value = value;
        _state = OptionState.Some;
    }

    /// <summary>
    ///     Outputs the <paramref name="some"/> if in the Some state, otherwise outputs the <paramref name="none"/>.
    ///     The output is of type <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="some">The func to use if <see cref="Option{TValue}"/> is in the Some state.</param>
    /// <param name="none">The func to use if <see cref="Option{TValue}"/> is in the None state.</param>
    /// <typeparam name="TOutput">The output of the match.</typeparam>
    /// <returns>The output of the match.</returns>
    public TOutput Match<TOutput>(
        Func<TValue, TOutput> some,
        Func<TOutput> none)
    {
        return _state is OptionState.Some 
            ? some(_value!) 
            : none();
    }

    /// <summary>
    ///     Outputs the <paramref name="some"/> if in the Some state, otherwise outputs the <paramref name="none"/>.
    ///     The output is of type <see cref="Task"/> of <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="some">The func to use if <see cref="Option{TValue}"/> is in the Some state.</param>
    /// <param name="none">The func to use if <see cref="Option{TValue}"/> is in the None state.</param>
    /// <typeparam name="TOutput">The output of the match.</typeparam>
    /// <returns>The output of the match.</returns>
    public Task<TOutput> MatchAsync<TOutput>(
        Func<TValue, Task<TOutput>> some,
        Func<Task<TOutput>> none)
    {
        return _state is OptionState.Some 
            ? some(_value!) 
            : none();
    }

    /// <summary>
    ///     Constructs <see cref="Option{TValue}"/> from a <typeparamref name="TValue"/> in the Some state.
    /// </summary>
    /// <param name="value">The value to construct the <see cref="Option{TValue}"/> type from.</param>
    /// <returns>The <see cref="Option{TValue}"/> type in the Some state.</returns>
    public static Option<TValue> Some(TValue value)
    {
        return new Option<TValue>(value);
    }

    /// <summary>
    ///     Constructs <see cref="Option{TValue}"/> in the None state.
    /// </summary>
    /// <returns>The <see cref="Option{TValue}"/> type in the None state.</returns>
    public static Option<TValue> None()
    {
        return new Option<TValue>();
    }
}