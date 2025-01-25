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
    ///     Returns the underlying value of the option. Will return null if in the None state.
    /// </summary>
    public TValue? Value => _value;

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
    /// <param name="some">The action to perform if in the Some state.</param>
    /// <param name="none">The asynchronous action to perform if in the None state.</param>
    /// <returns>The current object after possibly performing the action.</returns>
    public async Task<Option<TValue>> PerformAsync(
        Action<TValue>? some = null,
        Func<Task>? none = null)
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
    /// <param name="none">The action to perform if in the None state.</param>
    /// <returns>The current object after possibly performing the action.</returns>
    public async Task<Option<TValue>> PerformAsync(
        Func<TValue, Task>? some = null,
        Action? none = null)
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
    ///      Performs the relevant action based on the current state.
    /// </summary>
    /// <param name="some">The action to perform if in the Some state.</param>
    /// <param name="none">The asynchronous action to perform if in the None state.</param>
    /// <returns>The current object after possibly performing the action.</returns>
    public async Task<Option<TValue>> PerformAsync(
        Func<TValue, Unit>? some = null,
        Func<Task<Unit>>? none = null)
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
    /// <param name="none">The action to perform if in the None state.</param>
    /// <returns>The current object after possibly performing the action.</returns>
    public async Task<Option<TValue>> PerformAsync(
        Func<TValue, Task<Unit>>? some = null,
        Func<Unit>? none = null)
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
                    none();
                }
                break;
            default:
                throw new InvalidOperationException("Invalid state.");
        }
        
        return this;
    }
    
    /// <summary>
    ///      Returns the <paramref name="fallback"/> if in the None state.
    /// </summary>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>Returns the <paramref name="fallback"/> if in the None state.</returns>
    public Option<TValue> FallbackTo(Option<TValue> fallback)
    {
        return _state switch
        {
            OptionState.Some => this,
            OptionState.None => fallback,
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }
    
    /// <summary>
    ///      Returns the <paramref name="fallback"/> if in the None state.
    /// </summary>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>Returns the <paramref name="fallback"/> if in the None state.</returns>
    public async Task<Option<TValue>> FallbackToAsync(Task<Option<TValue>> fallback)
    {
        return _state switch
        {
            OptionState.Some => this,
            OptionState.None => await fallback,
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }
    
    /// <summary>
    ///      Returns the <paramref name="fallback"/> if in the None state.
    /// </summary>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>Returns the <paramref name="fallback"/> if in the None state.</returns>
    public Option<TValue> FallbackTo(Func<Option<TValue>> fallback)
    {
        return _state switch
        {
            OptionState.Some => this,
            OptionState.None => fallback(),
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }
    
    /// <summary>
    ///      Returns the <paramref name="fallback"/> if in the None state.
    /// </summary>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>Returns the <paramref name="fallback"/> if in the None state.</returns>
    public async Task<Option<TValue>> FallbackToAsync(Func<Task<Option<TValue>>> fallback)
    {
        return _state switch
        {
            OptionState.Some => this,
            OptionState.None => await fallback(),
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <returns><see cref="Result{TValue}"/></returns>
    public Result<TValue> ToResult()
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => Error.IsNone()
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="error">The error to produce when <see cref="Result{TValue}"/> is in the Failure state</param>
    /// <returns><see cref="Result{TValue}"/></returns>
    public Result<TValue> ToResult(Error error)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => error
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="error">The error to produce when <see cref="Result{TValue}"/> is in the Failure state</param>
    /// <returns><see cref="Result{TValue}"/></returns>
    public Result<TValue> ToResult(Func<Error> error)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => error()
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="error">The error to produce when <see cref="Result{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the error func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <returns><see cref="Result{TValue}"/></returns>
    public Result<TValue> ToResult<TFirstParam>(Func<TFirstParam, Error> error, TFirstParam firstParam)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => error(firstParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="error">The error to produce when <see cref="Result{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the error func</param>
    /// <param name="secondParam">Second parameter of the error func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <returns><see cref="Result{TValue}"/></returns>
    public Result<TValue> ToResult<TFirstParam, TSecondParam>(
        Func<TFirstParam, TSecondParam, Error> error, 
        TFirstParam firstParam,
        TSecondParam secondParam)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => error(firstParam, secondParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="error">The error to produce when <see cref="Result{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the error func</param>
    /// <param name="secondParam">Second parameter of the error func</param>
    /// <param name="thirdParam">Third parameter of the error func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <typeparam name="TThirdParam">The type of the third parameter</typeparam>
    /// <returns><see cref="Result{TValue}"/></returns>
    public Result<TValue> ToResult<TFirstParam, TSecondParam, TThirdParam>(
        Func<TFirstParam, TSecondParam, TThirdParam, Error> error, 
        TFirstParam firstParam,
        TSecondParam secondParam,
        TThirdParam thirdParam)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => error(firstParam, secondParam, thirdParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="error">The error to produce when <see cref="Result{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the error func</param>
    /// <param name="secondParam">Second parameter of the error func</param>
    /// <param name="thirdParam">Third parameter of the error func</param>
    /// <param name="fourthParam">Fourth parameter of the error func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <typeparam name="TThirdParam">The type of the third parameter</typeparam>
    /// <typeparam name="TFourthParam">The type of the fourth parameter</typeparam>
    /// <returns><see cref="Result{TValue}"/></returns>
    public Result<TValue> ToResult<TFirstParam, TSecondParam, TThirdParam, TFourthParam>(
        Func<TFirstParam, TSecondParam, TThirdParam, TFourthParam, Error> error, 
        TFirstParam firstParam,
        TSecondParam secondParam,
        TThirdParam thirdParam,
        TFourthParam fourthParam)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => error(firstParam, secondParam, thirdParam, fourthParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="error">The error to produce when <see cref="Result{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the error func</param>
    /// <param name="secondParam">Second parameter of the error func</param>
    /// <param name="thirdParam">Third parameter of the error func</param>
    /// <param name="fourthParam">Fourth parameter of the error func</param>
    /// <param name="fifthParam">Fifth parameter of the error func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <typeparam name="TThirdParam">The type of the third parameter</typeparam>
    /// <typeparam name="TFourthParam">The type of the fourth parameter</typeparam>
    /// <typeparam name="TFifthParam">The type of the fifth parameter</typeparam>
    /// <returns><see cref="Result{TValue}"/></returns>
    public Result<TValue> ToResult<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam>(
        Func<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, Error> error, 
        TFirstParam firstParam,
        TSecondParam secondParam,
        TThirdParam thirdParam,
        TFourthParam fourthParam,
        TFifthParam fifthParam)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => error(firstParam, secondParam, thirdParam, fourthParam, fifthParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="error">The error to produce when <see cref="Result{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the error func</param>
    /// <param name="secondParam">Second parameter of the error func</param>
    /// <param name="thirdParam">Third parameter of the error func</param>
    /// <param name="fourthParam">Fourth parameter of the error func</param>
    /// <param name="fifthParam">Fifth parameter of the error func</param>
    /// <param name="sixthParam">Sixth parameter of the error func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <typeparam name="TThirdParam">The type of the third parameter</typeparam>
    /// <typeparam name="TFourthParam">The type of the fourth parameter</typeparam>
    /// <typeparam name="TFifthParam">The type of the fifth parameter</typeparam>
    /// <typeparam name="TSixthParam">The type of the sixth parameter</typeparam>
    /// <returns><see cref="Result{TValue}"/></returns>
    public Result<TValue> ToResult<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, TSixthParam>(
        Func<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, TSixthParam, Error> error, 
        TFirstParam firstParam,
        TSecondParam secondParam,
        TThirdParam thirdParam,
        TFourthParam fourthParam,
        TFifthParam fifthParam,
        TSixthParam sixthParam)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => error(firstParam, secondParam, thirdParam, fourthParam, fifthParam, sixthParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="error">The error to produce when <see cref="Result{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the error func</param>
    /// <param name="secondParam">Second parameter of the error func</param>
    /// <param name="thirdParam">Third parameter of the error func</param>
    /// <param name="fourthParam">Fourth parameter of the error func</param>
    /// <param name="fifthParam">Fifth parameter of the error func</param>
    /// <param name="sixthParam">Sixth parameter of the error func</param>
    /// <param name="seventhParam">Seventh parameter of the error func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <typeparam name="TThirdParam">The type of the third parameter</typeparam>
    /// <typeparam name="TFourthParam">The type of the fourth parameter</typeparam>
    /// <typeparam name="TFifthParam">The type of the fifth parameter</typeparam>
    /// <typeparam name="TSixthParam">The type of the sixth parameter</typeparam>
    /// <typeparam name="TSeventhParam">The type of the seventh parameter</typeparam>
    /// <returns><see cref="Result{TValue}"/></returns>
    public Result<TValue> ToResult<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, TSixthParam, TSeventhParam>(
        Func<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, TSixthParam, TSeventhParam, Error> error, 
        TFirstParam firstParam,
        TSecondParam secondParam,
        TThirdParam thirdParam,
        TFourthParam fourthParam,
        TFifthParam fifthParam,
        TSixthParam sixthParam,
        TSeventhParam seventhParam)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => error(firstParam, secondParam, thirdParam, fourthParam, fifthParam, sixthParam, seventhParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="error">The error to produce when <see cref="Result{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the error func</param>
    /// <param name="secondParam">Second parameter of the error func</param>
    /// <param name="thirdParam">Third parameter of the error func</param>
    /// <param name="fourthParam">Fourth parameter of the error func</param>
    /// <param name="fifthParam">Fifth parameter of the error func</param>
    /// <param name="sixthParam">Sixth parameter of the error func</param>
    /// <param name="seventhParam">Seventh parameter of the error func</param>
    /// <param name="eighthParam">Eighth parameter of the error func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <typeparam name="TThirdParam">The type of the third parameter</typeparam>
    /// <typeparam name="TFourthParam">The type of the fourth parameter</typeparam>
    /// <typeparam name="TFifthParam">The type of the fifth parameter</typeparam>
    /// <typeparam name="TSixthParam">The type of the sixth parameter</typeparam>
    /// <typeparam name="TSeventhParam">The type of the seventh parameter</typeparam>
    /// <typeparam name="TEighthParam">The type of the eighth parameter</typeparam>
    /// <returns><see cref="Result{TValue}"/></returns>
    public Result<TValue> ToResult<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, TSixthParam, TSeventhParam, TEighthParam>(
        Func<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, TSixthParam, TSeventhParam, TEighthParam, Error> error, 
        TFirstParam firstParam,
        TSecondParam secondParam,
        TThirdParam thirdParam,
        TFourthParam fourthParam,
        TFifthParam fifthParam,
        TSixthParam sixthParam,
        TSeventhParam seventhParam,
        TEighthParam eighthParam)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => error(firstParam, secondParam, thirdParam, fourthParam, fifthParam, sixthParam, seventhParam, eighthParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="result">The result to produce when <see cref="Result{TValue}"/> is in the Failure state</param>
    /// <returns><see cref="Result{TValue}"/></returns>
    public Result<TValue> ToResult(Func<Result<TValue>> result)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => result()
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="result">The result to produce when <see cref="Result{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the result func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <returns><see cref="Result{TValue}"/></returns>
    public Result<TValue> ToResult<TFirstParam>(Func<TFirstParam, Result<TValue>> result, TFirstParam firstParam)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => result(firstParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="result">The result to produce when <see cref="Result{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the result func</param>
    /// <param name="secondParam">Second parameter of the result func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <returns><see cref="Result{TValue}"/></returns>
    public Result<TValue> ToResult<TFirstParam, TSecondParam>(
        Func<TFirstParam, TSecondParam, Result<TValue>> result, 
        TFirstParam firstParam,
        TSecondParam secondParam)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => result(firstParam, secondParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="result">The result to produce when <see cref="Result{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the result func</param>
    /// <param name="secondParam">Second parameter of the result func</param>
    /// <param name="thirdParam">Third parameter of the result func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <typeparam name="TThirdParam">The type of the third parameter</typeparam>
    /// <returns><see cref="Result{TValue}"/></returns>
    public Result<TValue> ToResult<TFirstParam, TSecondParam, TThirdParam>(
        Func<TFirstParam, TSecondParam, TThirdParam, Result<TValue>> result, 
        TFirstParam firstParam,
        TSecondParam secondParam,
        TThirdParam thirdParam)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => result(firstParam, secondParam, thirdParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="result">The result to produce when <see cref="Result{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the result func</param>
    /// <param name="secondParam">Second parameter of the result func</param>
    /// <param name="thirdParam">Third parameter of the result func</param>
    /// <param name="fourthParam">Fourth parameter of the result func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <typeparam name="TThirdParam">The type of the third parameter</typeparam>
    /// <typeparam name="TFourthParam">The type of the fourth parameter</typeparam>
    /// <returns><see cref="Result{TValue}"/></returns>
    public Result<TValue> ToResult<TFirstParam, TSecondParam, TThirdParam, TFourthParam>(
        Func<TFirstParam, TSecondParam, TThirdParam, TFourthParam, Result<TValue>> result, 
        TFirstParam firstParam,
        TSecondParam secondParam,
        TThirdParam thirdParam,
        TFourthParam fourthParam)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => result(firstParam, secondParam, thirdParam, fourthParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="result">The result to produce when <see cref="Result{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the result func</param>
    /// <param name="secondParam">Second parameter of the result func</param>
    /// <param name="thirdParam">Third parameter of the result func</param>
    /// <param name="fourthParam">Fourth parameter of the result func</param>
    /// <param name="fifthParam">Fifth parameter of the result func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <typeparam name="TThirdParam">The type of the third parameter</typeparam>
    /// <typeparam name="TFourthParam">The type of the fourth parameter</typeparam>
    /// <typeparam name="TFifthParam">The type of the fifth parameter</typeparam>
    /// <returns><see cref="Result{TValue}"/></returns>
    public Result<TValue> ToResult<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam>(
        Func<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, Result<TValue>> result, 
        TFirstParam firstParam,
        TSecondParam secondParam,
        TThirdParam thirdParam,
        TFourthParam fourthParam,
        TFifthParam fifthParam)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => result(firstParam, secondParam, thirdParam, fourthParam, fifthParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="result">The result to produce when <see cref="Result{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the result func</param>
    /// <param name="secondParam">Second parameter of the result func</param>
    /// <param name="thirdParam">Third parameter of the result func</param>
    /// <param name="fourthParam">Fourth parameter of the result func</param>
    /// <param name="fifthParam">Fifth parameter of the result func</param>
    /// <param name="sixthParam">Sixth parameter of the result func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <typeparam name="TThirdParam">The type of the third parameter</typeparam>
    /// <typeparam name="TFourthParam">The type of the fourth parameter</typeparam>
    /// <typeparam name="TFifthParam">The type of the fifth parameter</typeparam>
    /// <typeparam name="TSixthParam">The type of the sixth parameter</typeparam>
    /// <returns><see cref="Result{TValue}"/></returns>
    public Result<TValue> ToResult<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, TSixthParam>(
        Func<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, TSixthParam, Result<TValue>> result, 
        TFirstParam firstParam,
        TSecondParam secondParam,
        TThirdParam thirdParam,
        TFourthParam fourthParam,
        TFifthParam fifthParam,
        TSixthParam sixthParam)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => result(firstParam, secondParam, thirdParam, fourthParam, fifthParam, sixthParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="result">The result to produce when <see cref="Result{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the result func</param>
    /// <param name="secondParam">Second parameter of the result func</param>
    /// <param name="thirdParam">Third parameter of the result func</param>
    /// <param name="fourthParam">Fourth parameter of the result func</param>
    /// <param name="fifthParam">Fifth parameter of the result func</param>
    /// <param name="sixthParam">Sixth parameter of the result func</param>
    /// <param name="seventhParam">Seventh parameter of the result func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <typeparam name="TThirdParam">The type of the third parameter</typeparam>
    /// <typeparam name="TFourthParam">The type of the fourth parameter</typeparam>
    /// <typeparam name="TFifthParam">The type of the fifth parameter</typeparam>
    /// <typeparam name="TSixthParam">The type of the sixth parameter</typeparam>
    /// <typeparam name="TSeventhParam">The type of the seventh parameter</typeparam>
    /// <returns><see cref="Result{TValue}"/></returns>
    public Result<TValue> ToResult<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, TSixthParam, TSeventhParam>(
        Func<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, TSixthParam, TSeventhParam, Result<TValue>> result, 
        TFirstParam firstParam,
        TSecondParam secondParam,
        TThirdParam thirdParam,
        TFourthParam fourthParam,
        TFifthParam fifthParam,
        TSixthParam sixthParam,
        TSeventhParam seventhParam)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => result(firstParam, secondParam, thirdParam, fourthParam, fifthParam, sixthParam, seventhParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="result">The result to produce when <see cref="Result{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the result func</param>
    /// <param name="secondParam">Second parameter of the result func</param>
    /// <param name="thirdParam">Third parameter of the result func</param>
    /// <param name="fourthParam">Fourth parameter of the result func</param>
    /// <param name="fifthParam">Fifth parameter of the result func</param>
    /// <param name="sixthParam">Sixth parameter of the result func</param>
    /// <param name="seventhParam">Seventh parameter of the result func</param>
    /// <param name="eighthParam">Eighth parameter of the result func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <typeparam name="TThirdParam">The type of the third parameter</typeparam>
    /// <typeparam name="TFourthParam">The type of the fourth parameter</typeparam>
    /// <typeparam name="TFifthParam">The type of the fifth parameter</typeparam>
    /// <typeparam name="TSixthParam">The type of the sixth parameter</typeparam>
    /// <typeparam name="TSeventhParam">The type of the seventh parameter</typeparam>
    /// <typeparam name="TEighthParam">The type of the eighth parameter</typeparam>
    /// <returns><see cref="Result{TValue}"/></returns>
    public Result<TValue> ToResult<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, TSixthParam, TSeventhParam, TEighthParam>(
        Func<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, TSixthParam, TSeventhParam, TEighthParam, Result<TValue>> result, 
        TFirstParam firstParam,
        TSecondParam secondParam,
        TThirdParam thirdParam,
        TFourthParam fourthParam,
        TFifthParam fifthParam,
        TSixthParam sixthParam,
        TSeventhParam seventhParam,
        TEighthParam eighthParam)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => result(firstParam, secondParam, thirdParam, fourthParam, fifthParam, sixthParam, seventhParam, eighthParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Validation{TValue}"/>.
    /// </summary>
    /// <returns><see cref="Validation{TValue}"/></returns>
    public Validation<TValue> ToValidation()
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => new [] { Error.IsNone() }
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Validation{TValue}"/>.
    /// </summary>
    /// <param name="error">The error to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
    /// <returns><see cref="Validation{TValue}"/></returns>
    public Validation<TValue> ToValidation(Error[] error)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => error
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Validation{TValue}"/>.
    /// </summary>
    /// <param name="error">The error to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
    /// <returns><see cref="Validation{TValue}"/></returns>
    public Validation<TValue> ToValidation(List<Error> error)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => error
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Validation{TValue}"/>.
    /// </summary>
    /// <param name="error">The error to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
    /// <returns><see cref="Validation{TValue}"/></returns>
    public Validation<TValue> ToValidation(Func<List<Error>> error)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => error()
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Validation{TValue}"/>.
    /// </summary>
    /// <param name="error">The error to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the error func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <returns><see cref="Validation{TValue}"/></returns>
    public Validation<TValue> ToValidation<TFirstParam>(Func<TFirstParam, List<Error>> error, TFirstParam firstParam)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => error(firstParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Validation{TValue}"/>.
    /// </summary>
    /// <param name="error">The error to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the error func</param>
    /// <param name="secondParam">Second parameter of the error func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <returns><see cref="Validation{TValue}"/></returns>
    public Validation<TValue> ToValidation<TFirstParam, TSecondParam>(
        Func<TFirstParam, TSecondParam, List<Error>> error, 
        TFirstParam firstParam,
        TSecondParam secondParam)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => error(firstParam, secondParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Validation{TValue}"/>.
    /// </summary>
    /// <param name="error">The error to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the error func</param>
    /// <param name="secondParam">Second parameter of the error func</param>
    /// <param name="thirdParam">Third parameter of the error func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <typeparam name="TThirdParam">The type of the third parameter</typeparam>
    /// <returns><see cref="Validation{TValue}"/></returns>
    public Validation<TValue> ToValidation<TFirstParam, TSecondParam, TThirdParam>(
        Func<TFirstParam, TSecondParam, TThirdParam, List<Error>> error, 
        TFirstParam firstParam,
        TSecondParam secondParam,
        TThirdParam thirdParam)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => error(firstParam, secondParam, thirdParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Validation{TValue}"/>.
    /// </summary>
    /// <param name="error">The error to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the error func</param>
    /// <param name="secondParam">Second parameter of the error func</param>
    /// <param name="thirdParam">Third parameter of the error func</param>
    /// <param name="fourthParam">Fourth parameter of the error func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <typeparam name="TThirdParam">The type of the third parameter</typeparam>
    /// <typeparam name="TFourthParam">The type of the fourth parameter</typeparam>
    /// <returns><see cref="Validation{TValue}"/></returns>
    public Validation<TValue> ToValidation<TFirstParam, TSecondParam, TThirdParam, TFourthParam>(
        Func<TFirstParam, TSecondParam, TThirdParam, TFourthParam, List<Error>> error, 
        TFirstParam firstParam,
        TSecondParam secondParam,
        TThirdParam thirdParam,
        TFourthParam fourthParam)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => error(firstParam, secondParam, thirdParam, fourthParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Validation{TValue}"/>.
    /// </summary>
    /// <param name="error">The error to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the error func</param>
    /// <param name="secondParam">Second parameter of the error func</param>
    /// <param name="thirdParam">Third parameter of the error func</param>
    /// <param name="fourthParam">Fourth parameter of the error func</param>
    /// <param name="fifthParam">Fifth parameter of the error func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <typeparam name="TThirdParam">The type of the third parameter</typeparam>
    /// <typeparam name="TFourthParam">The type of the fourth parameter</typeparam>
    /// <typeparam name="TFifthParam">The type of the fifth parameter</typeparam>
    /// <returns><see cref="Validation{TValue}"/></returns>
    public Validation<TValue> ToValidation<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam>(
        Func<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, List<Error>> error, 
        TFirstParam firstParam,
        TSecondParam secondParam,
        TThirdParam thirdParam,
        TFourthParam fourthParam,
        TFifthParam fifthParam)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => error(firstParam, secondParam, thirdParam, fourthParam, fifthParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Validation{TValue}"/>.
    /// </summary>
    /// <param name="error">The error to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the error func</param>
    /// <param name="secondParam">Second parameter of the error func</param>
    /// <param name="thirdParam">Third parameter of the error func</param>
    /// <param name="fourthParam">Fourth parameter of the error func</param>
    /// <param name="fifthParam">Fifth parameter of the error func</param>
    /// <param name="sixthParam">Sixth parameter of the error func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <typeparam name="TThirdParam">The type of the third parameter</typeparam>
    /// <typeparam name="TFourthParam">The type of the fourth parameter</typeparam>
    /// <typeparam name="TFifthParam">The type of the fifth parameter</typeparam>
    /// <typeparam name="TSixthParam">The type of the sixth parameter</typeparam>
    /// <returns><see cref="Validation{TValue}"/></returns>
    public Validation<TValue> ToValidation<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, TSixthParam>(
        Func<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, TSixthParam, List<Error>> error, 
        TFirstParam firstParam,
        TSecondParam secondParam,
        TThirdParam thirdParam,
        TFourthParam fourthParam,
        TFifthParam fifthParam,
        TSixthParam sixthParam)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => error(firstParam, secondParam, thirdParam, fourthParam, fifthParam, sixthParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Validation{TValue}"/>.
    /// </summary>
    /// <param name="error">The error to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the error func</param>
    /// <param name="secondParam">Second parameter of the error func</param>
    /// <param name="thirdParam">Third parameter of the error func</param>
    /// <param name="fourthParam">Fourth parameter of the error func</param>
    /// <param name="fifthParam">Fifth parameter of the error func</param>
    /// <param name="sixthParam">Sixth parameter of the error func</param>
    /// <param name="seventhParam">Seventh parameter of the error func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <typeparam name="TThirdParam">The type of the third parameter</typeparam>
    /// <typeparam name="TFourthParam">The type of the fourth parameter</typeparam>
    /// <typeparam name="TFifthParam">The type of the fifth parameter</typeparam>
    /// <typeparam name="TSixthParam">The type of the sixth parameter</typeparam>
    /// <typeparam name="TSeventhParam">The type of the seventh parameter</typeparam>
    /// <returns><see cref="Validation{TValue}"/></returns>
    public Validation<TValue> ToValidation<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, TSixthParam, TSeventhParam>(
        Func<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, TSixthParam, TSeventhParam, List<Error>> error, 
        TFirstParam firstParam,
        TSecondParam secondParam,
        TThirdParam thirdParam,
        TFourthParam fourthParam,
        TFifthParam fifthParam,
        TSixthParam sixthParam,
        TSeventhParam seventhParam)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => error(firstParam, secondParam, thirdParam, fourthParam, fifthParam, sixthParam, seventhParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Validation{TValue}"/>.
    /// </summary>
    /// <param name="error">The error to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the error func</param>
    /// <param name="secondParam">Second parameter of the error func</param>
    /// <param name="thirdParam">Third parameter of the error func</param>
    /// <param name="fourthParam">Fourth parameter of the error func</param>
    /// <param name="fifthParam">Fifth parameter of the error func</param>
    /// <param name="sixthParam">Sixth parameter of the error func</param>
    /// <param name="seventhParam">Seventh parameter of the error func</param>
    /// <param name="eighthParam">Eighth parameter of the error func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <typeparam name="TThirdParam">The type of the third parameter</typeparam>
    /// <typeparam name="TFourthParam">The type of the fourth parameter</typeparam>
    /// <typeparam name="TFifthParam">The type of the fifth parameter</typeparam>
    /// <typeparam name="TSixthParam">The type of the sixth parameter</typeparam>
    /// <typeparam name="TSeventhParam">The type of the seventh parameter</typeparam>
    /// <typeparam name="TEighthParam">The type of the eighth parameter</typeparam>
    /// <returns><see cref="Validation{TValue}"/></returns>
    public Validation<TValue> ToValidation<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, TSixthParam, TSeventhParam, TEighthParam>(
        Func<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, TSixthParam, TSeventhParam, TEighthParam, List<Error>> error, 
        TFirstParam firstParam,
        TSecondParam secondParam,
        TThirdParam thirdParam,
        TFourthParam fourthParam,
        TFifthParam fifthParam,
        TSixthParam sixthParam,
        TSeventhParam seventhParam,
        TEighthParam eighthParam)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => error(firstParam, secondParam, thirdParam, fourthParam, fifthParam, sixthParam, seventhParam, eighthParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Validation{TValue}"/>.
    /// </summary>
    /// <param name="validation">The validation to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
    /// <returns><see cref="Validation{TValue}"/></returns>
    public Validation<TValue> ToValidation(Func<Validation<TValue>> validation)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => validation()
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Validation{TValue}"/>.
    /// </summary>
    /// <param name="validation">The validation to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the validation func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <returns><see cref="Validation{TValue}"/></returns>
    public Validation<TValue> ToValidation<TFirstParam>(Func<TFirstParam, Validation<TValue>> validation, TFirstParam firstParam)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => validation(firstParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Validation{TValue}"/>.
    /// </summary>
    /// <param name="validation">The validation to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the validation func</param>
    /// <param name="secondParam">Second parameter of the validation func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <returns><see cref="Validation{TValue}"/></returns>
    public Validation<TValue> ToValidation<TFirstParam, TSecondParam>(
        Func<TFirstParam, TSecondParam, Validation<TValue>> validation, 
        TFirstParam firstParam,
        TSecondParam secondParam)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => validation(firstParam, secondParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Validation{TValue}"/>.
    /// </summary>
    /// <param name="validation">The validation to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the validation func</param>
    /// <param name="secondParam">Second parameter of the validation func</param>
    /// <param name="thirdParam">Third parameter of the validation func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <typeparam name="TThirdParam">The type of the third parameter</typeparam>
    /// <returns><see cref="Validation{TValue}"/></returns>
    public Validation<TValue> ToValidation<TFirstParam, TSecondParam, TThirdParam>(
        Func<TFirstParam, TSecondParam, TThirdParam, Validation<TValue>> validation, 
        TFirstParam firstParam,
        TSecondParam secondParam,
        TThirdParam thirdParam)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => validation(firstParam, secondParam, thirdParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Validation{TValue}"/>.
    /// </summary>
    /// <param name="validation">The validation to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the validation func</param>
    /// <param name="secondParam">Second parameter of the validation func</param>
    /// <param name="thirdParam">Third parameter of the validation func</param>
    /// <param name="fourthParam">Fourth parameter of the validation func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <typeparam name="TThirdParam">The type of the third parameter</typeparam>
    /// <typeparam name="TFourthParam">The type of the fourth parameter</typeparam>
    /// <returns><see cref="Validation{TValue}"/></returns>
    public Validation<TValue> ToValidation<TFirstParam, TSecondParam, TThirdParam, TFourthParam>(
        Func<TFirstParam, TSecondParam, TThirdParam, TFourthParam, Validation<TValue>> validation, 
        TFirstParam firstParam,
        TSecondParam secondParam,
        TThirdParam thirdParam,
        TFourthParam fourthParam)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => validation(firstParam, secondParam, thirdParam, fourthParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Validation{TValue}"/>.
    /// </summary>
    /// <param name="validation">The validation to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the validation func</param>
    /// <param name="secondParam">Second parameter of the validation func</param>
    /// <param name="thirdParam">Third parameter of the validation func</param>
    /// <param name="fourthParam">Fourth parameter of the validation func</param>
    /// <param name="fifthParam">Fifth parameter of the validation func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <typeparam name="TThirdParam">The type of the third parameter</typeparam>
    /// <typeparam name="TFourthParam">The type of the fourth parameter</typeparam>
    /// <typeparam name="TFifthParam">The type of the fifth parameter</typeparam>
    /// <returns><see cref="Validation{TValue}"/></returns>
    public Validation<TValue> ToValidation<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam>(
        Func<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, Validation<TValue>> validation, 
        TFirstParam firstParam,
        TSecondParam secondParam,
        TThirdParam thirdParam,
        TFourthParam fourthParam,
        TFifthParam fifthParam)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => validation(firstParam, secondParam, thirdParam, fourthParam, fifthParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Validation{TValue}"/>.
    /// </summary>
    /// <param name="validation">The validation to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the validation func</param>
    /// <param name="secondParam">Second parameter of the validation func</param>
    /// <param name="thirdParam">Third parameter of the validation func</param>
    /// <param name="fourthParam">Fourth parameter of the validation func</param>
    /// <param name="fifthParam">Fifth parameter of the validation func</param>
    /// <param name="sixthParam">Sixth parameter of the validation func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <typeparam name="TThirdParam">The type of the third parameter</typeparam>
    /// <typeparam name="TFourthParam">The type of the fourth parameter</typeparam>
    /// <typeparam name="TFifthParam">The type of the fifth parameter</typeparam>
    /// <typeparam name="TSixthParam">The type of the sixth parameter</typeparam>
    /// <returns><see cref="Validation{TValue}"/></returns>
    public Validation<TValue> ToValidation<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, TSixthParam>(
        Func<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, TSixthParam, Validation<TValue>> validation, 
        TFirstParam firstParam,
        TSecondParam secondParam,
        TThirdParam thirdParam,
        TFourthParam fourthParam,
        TFifthParam fifthParam,
        TSixthParam sixthParam)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => validation(firstParam, secondParam, thirdParam, fourthParam, fifthParam, sixthParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Validation{TValue}"/>.
    /// </summary>
    /// <param name="validation">The validation to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the validation func</param>
    /// <param name="secondParam">Second parameter of the validation func</param>
    /// <param name="thirdParam">Third parameter of the validation func</param>
    /// <param name="fourthParam">Fourth parameter of the validation func</param>
    /// <param name="fifthParam">Fifth parameter of the validation func</param>
    /// <param name="sixthParam">Sixth parameter of the validation func</param>
    /// <param name="seventhParam">Seventh parameter of the validation func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <typeparam name="TThirdParam">The type of the third parameter</typeparam>
    /// <typeparam name="TFourthParam">The type of the fourth parameter</typeparam>
    /// <typeparam name="TFifthParam">The type of the fifth parameter</typeparam>
    /// <typeparam name="TSixthParam">The type of the sixth parameter</typeparam>
    /// <typeparam name="TSeventhParam">The type of the seventh parameter</typeparam>
    /// <returns><see cref="Validation{TValue}"/></returns>
    public Validation<TValue> ToValidation<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, TSixthParam, TSeventhParam>(
        Func<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, TSixthParam, TSeventhParam, Validation<TValue>> validation, 
        TFirstParam firstParam,
        TSecondParam secondParam,
        TThirdParam thirdParam,
        TFourthParam fourthParam,
        TFifthParam fifthParam,
        TSixthParam sixthParam,
        TSeventhParam seventhParam)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => validation(firstParam, secondParam, thirdParam, fourthParam, fifthParam, sixthParam, seventhParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Validation{TValue}"/>.
    /// </summary>
    /// <param name="validation">The validation to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the validation func</param>
    /// <param name="secondParam">Second parameter of the validation func</param>
    /// <param name="thirdParam">Third parameter of the validation func</param>
    /// <param name="fourthParam">Fourth parameter of the validation func</param>
    /// <param name="fifthParam">Fifth parameter of the validation func</param>
    /// <param name="sixthParam">Sixth parameter of the validation func</param>
    /// <param name="seventhParam">Seventh parameter of the validation func</param>
    /// <param name="eighthParam">Eighth parameter of the validation func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <typeparam name="TThirdParam">The type of the third parameter</typeparam>
    /// <typeparam name="TFourthParam">The type of the fourth parameter</typeparam>
    /// <typeparam name="TFifthParam">The type of the fifth parameter</typeparam>
    /// <typeparam name="TSixthParam">The type of the sixth parameter</typeparam>
    /// <typeparam name="TSeventhParam">The type of the seventh parameter</typeparam>
    /// <typeparam name="TEighthParam">The type of the eighth parameter</typeparam>
    /// <returns><see cref="Validation{TValue}"/></returns>
    public Validation<TValue> ToValidation<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, TSixthParam, TSeventhParam, TEighthParam>(
        Func<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, TSixthParam, TSeventhParam, TEighthParam, Validation<TValue>> validation, 
        TFirstParam firstParam,
        TSecondParam secondParam,
        TThirdParam thirdParam,
        TFourthParam fourthParam,
        TFifthParam fifthParam,
        TSixthParam sixthParam,
        TSeventhParam seventhParam,
        TEighthParam eighthParam)
    {
        return _state switch
        {
            OptionState.Some => Value!,
            _ => validation(firstParam, secondParam, thirdParam, fourthParam, fifthParam, sixthParam, seventhParam, eighthParam)
        };
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
    
    /// <summary>
    ///     Implicitly constructs <see cref="Option{TValue}"/> from a <typeparamref name="TValue"/> in the Some state
    ///     or None state if value is null.
    /// </summary>
    /// <param name="value">The value to construct the <see cref="Option{TValue}"/> type from.</param>
    /// <returns>The <see cref="Option{TValue}"/> type in the Some state or None state if value is null.</returns>
    public static implicit operator Option<TValue>(TValue? value) => value is not null ? Some(value) : None();
}