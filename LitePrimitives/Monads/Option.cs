using LitePrimitives.InternalStates;

// ReSharper disable once CheckNamespace
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
    ///     Returns true if the <see cref="Option{TValue}"/> is in the Some state.
    /// </summary>
    public bool IsSome => _state == OptionState.Some;

    /// <summary>
    ///     Returns true if the <see cref="Option{TValue}"/> is in the None state.
    /// </summary>
    public bool IsNone => _state == OptionState.None;

    /// <summary>
    ///     Outputs the <paramref name="some"/> if in the Some state, otherwise outputs the <paramref name="none"/>.
    ///     The output is of type <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="some">The func to use if <see cref="Option{TValue}"/> is in the Some state.</param>
    /// <param name="none">The func to use if <see cref="Option{TValue}"/> is in the None state.</param>
    /// <typeparam name="TOutput">The output of the match.</typeparam>
    /// <returns>The output of the match.</returns>
    public TOutput Match<TOutput>(Func<TValue, TOutput> some, Func<TOutput> none)
    {
        return _state switch
        {
            OptionState.Some => some(_value!),
            OptionState.None => none(),
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }

    /// <summary>
    ///     Outputs the <paramref name="some"/> if in the Some state, otherwise outputs the <paramref name="none"/>.
    ///     The output is of type <see cref="Task"/> of <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="some">The func to use if <see cref="Option{TValue}"/> is in the Some state.</param>
    /// <param name="none">The func to use if <see cref="Option{TValue}"/> is in the None state.</param>
    /// <typeparam name="TOutput">The output of the match.</typeparam>
    /// <returns>The output of the match.</returns>
    public async Task<TOutput> MatchAsync<TOutput>(Func<TValue, Task<TOutput>> some, Func<Task<TOutput>> none)
    {
        return _state switch
        {
            OptionState.Some => await some(_value!),
            OptionState.None => await none(),
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }
    
    /// <summary>
    ///     Returns the return type of <paramref name="bindFunc"/> if in the Some state,
    ///     otherwise returns <see cref="Option{TOutput}"/> in the None state.
    /// </summary>
    /// <param name="bindFunc">The func to apply if in the Some state.</param>
    /// <typeparam name="TOutput">The type of the output.</typeparam>
    /// <returns>
    ///     The result of <paramref name="bindFunc"/> if in the Some state,
    ///     otherwise returns <see cref="Option{TOutput}"/> in the None state.
    /// </returns>
    public Option<TOutput> Bind<TOutput>(Func<TValue, Option<TOutput>> bindFunc)
    {
        return _state switch
        {
            OptionState.Some => bindFunc(_value!),
            OptionState.None => Option<TOutput>.None(),
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }
    
    /// <summary>
    ///     Returns the return type of <paramref name="bindFunc"/> if in the Some state,
    ///     otherwise returns <see cref="Task"/> of type <see cref="Option{TOutput}"/> in the None state.
    /// </summary>
    /// <param name="bindFunc">The asynchronous func to apply if in the Some state.</param>
    /// <typeparam name="TOutput">The type of the output.</typeparam>
    /// <returns>
    ///     The result of <paramref name="bindFunc"/> if in the Some state,
    ///     otherwise returns <see cref="Task"/> of type <see cref="Option{TOutput}"/> in the None state.
    /// </returns>
    public async Task<Option<TOutput>> BindAsync<TOutput>(Func<TValue, Task<Option<TOutput>>> bindFunc)
    {
        return _state switch
        {
            OptionState.Some => await bindFunc(_value!),
            OptionState.None => Option<TOutput>.None(),
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }
    
    /// <summary>
    ///     Performs transformation into <see cref="Option{TOutput}"/> when it's in a Some state,
    ///     otherwise returns <see cref="Option{TOutput}"/> in the None state.
    /// </summary>
    /// <param name="transform">The function to transform to <typeparamref name="TOutput"/>.</param>
    /// <typeparam name="TOutput">The type of the transformed output.</typeparam>
    /// <returns>
    ///	    The result of <paramref name="transform"/> if in the Some state,
    ///	    otherwise returns <see cref="Option{TOutput}"/> in the None state.
    /// </returns>
    public Option<TOutput> Map<TOutput>(Func<TValue, TOutput> transform)
    {
        return _state switch
        {
            OptionState.Some => Option<TOutput>.Some(transform(_value!)),
            OptionState.None => Option<TOutput>.None(),
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }

    /// <summary>
    ///     Performs transformation into <see cref="Option{TOutput}"/> when it's in a Some state,
    ///     otherwise returns <see cref="Task"/> of type <see cref="Option{TOutput}"/> in the None state.
    /// </summary>
    /// <param name="transform">The asynchronous function to transform to <typeparamref name="TOutput"/>.</param>
    /// <typeparam name="TOutput">The type of the transformed output.</typeparam>
    /// <returns>
    ///	    The result of <paramref name="transform"/> if in the Some state,
    ///	    otherwise returns <see cref="Task"/> of type <see cref="Option{TOutput}"/> in the None state.
    /// </returns>
    public async Task<Option<TOutput>> MapAsync<TOutput>(Func<TValue, Task<TOutput>> transform)
    {
        return _state switch
        {
            OptionState.Some => Option<TOutput>.Some(await transform(_value!)),
            OptionState.None => Option<TOutput>.None(),
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }
    
    /// <summary>
    ///     Performs the <paramref name="action"/> if in the Some state.
    /// </summary>
    /// <param name="action">The action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public Option<TValue> OnSome(Action<TValue> action)
    {
        if (_state is OptionState.Some)
        {
            action(_value!);
        }

        return this;
    }

    /// <summary>
    ///     Performs the <paramref name="action"/> if in the Some state.
    /// </summary>
    /// <param name="action">The action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public Option<TValue> OnSome(Func<TValue, Unit> action)
    {
        if (_state is OptionState.Some)
        {
            action(_value!);
        }

        return this;
    }

    /// <summary>
    ///     Performs the <paramref name="action"/> if in the Some state.
    /// </summary>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public async Task<Option<TValue>> OnSomeAsync(Func<TValue, Task> action)
    {
        if (_state is OptionState.Some)
        {
            await action(_value!);
        }

        return this;
    }

    /// <summary>
    ///     Performs the <paramref name="action"/> if in the Some state.
    /// </summary>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public async Task<Option<TValue>> OnSomeAsync(Func<TValue, Task<Unit>> action)
    {
        if (_state is OptionState.Some)
        {
            await action(_value!);
        }

        return this;
    }
    
    /// <summary>
    ///     Performs the <paramref name="action"/> if in the None state.
    /// </summary>
    /// <param name="action">The action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public Option<TValue> OnNone(Action action)
    {
        if (_state is OptionState.None)
        {
            action();
        }

        return this;
    }

    /// <summary>
    ///     Performs the <paramref name="action"/> if in the None state.
    /// </summary>
    /// <param name="action">The action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public Option<TValue> OnNone(Func<Unit> action)
    {
        if (_state is OptionState.None)
        {
            action();
        }

        return this;
    }

    /// <summary>
    ///     Performs the <paramref name="action"/> if in the None state.
    /// </summary>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public async Task<Option<TValue>> OnNoneAsync(Func<Task> action)
    {
        if (_state is OptionState.None)
        {
            await action();
        }

        return this;
    }

    /// <summary>
    ///     Performs the <paramref name="action"/> if in the None state.
    /// </summary>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public async Task<Option<TValue>> OnNoneAsync(Func<Task<Unit>> action)
    {
        if (_state is OptionState.None)
        {
            await action();
        }

        return this;
    }

    /// <summary>
    ///      Performs the relevant action based on the current state.
    /// </summary>
    /// <param name="some">The action to perform if in the Some state.</param>
    /// <param name="none">The action to perform if in the None state.</param>
    /// <returns>The current object after possibly performing the action.</returns>
    public Option<TValue> Perform(
        Action<TValue>? some = null,
        Action? none = null)
    {
        switch (_state)
        {
            case OptionState.Some:
                if (some is not null)
                {
                    some(_value!);
                }
                break;
            case OptionState.None:
                if (none is not null)
                {
                    none();
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
    /// <param name="some">The action to perform if in the Some state.</param>
    /// <param name="none">The action to perform if in the None state.</param>
    /// <returns>The current object after possibly performing the action.</returns>
    public Option<TValue> Perform(
        Func<TValue, Unit>? some = null,
        Func<Unit>? none = null)
    {
        switch (_state)
        {
            case OptionState.Some:
                if (some is not null)
                {
                    some(_value!);
                }
                break;
            case OptionState.None:
                if (none is not null)
                {
                    none();
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
    /// <param name="some">The asynchronous action to perform if in the Some state.</param>
    /// <param name="none">The asynchronous action to perform if in the None state.</param>
    /// <returns>The current object after possibly performing the action.</returns>
    public async Task<Option<TValue>> PerformAsync(
        Func<TValue, Task>? some = null,
        Func<Task>? none = null)
    {
        switch (_state)
        {
            case OptionState.Some:
                if (some is not null)
                {
                    await some(_value!);
                }
                break;
            case OptionState.None:
                if (none is not null)
                {
                    await none();
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
    /// <param name="some">The asynchronous action to perform if in the Some state.</param>
    /// <param name="none">The asynchronous action to perform if in the None state.</param>
    /// <returns>The current object after possibly performing the action.</returns>
    public async Task<Option<TValue>> PerformAsync(
        Func<TValue, Task<Unit>>? some = null,
        Func<Task<Unit>>? none = null)
    {
        switch (_state)
        {
            case OptionState.Some:
                if (some is not null)
                {
                    await some(_value!);
                }
                break;
            case OptionState.None:
                if (none is not null)
                {
                    await none();
                }
                break;
            default:
                throw new InvalidOperationException("Invalid state.");
        }
        
        return this;
    }

    /// <summary>
    ///     Constructs <see cref="Option{TValue}"/> from a <typeparamref name="TValue"/> in the Some state.
    /// </summary>
    /// <param name="value">The value to construct the <see cref="Option{TValue}"/> type from.</param>
    /// <returns>The <see cref="Option{TValue}"/> type in the Some state.</returns>
    public static Option<TValue> Some(TValue value) => new(value);

    /// <summary>
    ///     Constructs <see cref="Option{TValue}"/> in the None state.
    /// </summary>
    /// <returns>The <see cref="Option{TValue}"/> type in the None state.</returns>
    public static Option<TValue> None() => new();
}