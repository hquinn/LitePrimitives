using LitePrimitives.InternalStates;

// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Represents a value of one of two possible types (a disjointed union).
///     This type can encapsulate either:
///     - <typeparamref name="TValue"/> in the Success state.
///     - <see cref="Error"/> in the Failure state.
///     But not all at once.
/// </summary>
/// <typeparam name="TValue">The type of the Success state.</typeparam>
public readonly struct Validation<TValue>
{
    private readonly ValidationState _state;
    private readonly TValue? _value;
    private readonly Error[]? _errors;

    private Validation(Error[] errors)
    {
        _errors = errors;
        _state = ValidationState.Failure;
    }
    
    private Validation(TValue value)
    {
        _value = value;
        _state = ValidationState.Success;
    }

    /// <summary>
    ///     Returns true if the <see cref="Validation{TValue}"/> is in the Success state.
    /// </summary>
    public bool IsSuccess => _state == ValidationState.Success;

    /// <summary>
    ///     Returns true if the <see cref="Validation{TValue}"/> is in the Failure state.
    /// </summary>
    public bool IsFailure => _state == ValidationState.Failure;
    
    /// <summary>
    ///     Returns the underlying value of the validation. Will return null if in the Failure state.
    /// </summary>
    public TValue? Value => _value;
    
    /// <summary>
    ///     Returns the underlying errors of the validation. Will return null if in the Success state.
    /// </summary>
    public Error[]? Errors => _errors;
    
    /// <summary>
    ///     Outputs the following:
    ///     - <paramref name="success"/> if in the Success state.
    ///     - <paramref name="failure"/> if in the Failure state.
    ///     The output is of type <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="success">The func to use if <see cref="Validation{TValue}"/> is in the Success state.</param>
    /// <param name="failure">The func to use if <see cref="Validation{TValue}"/> is in the Failure state.</param>
    /// <typeparam name="TOutput">The output of the match.</typeparam>
    /// <returns>The output of the match.</returns>
    public TOutput Match<TOutput>(
        Func<TValue, TOutput> success,
        Func<Error[], TOutput> failure)
    {
        return _state switch
        {
            ValidationState.Success => success(_value!),
            ValidationState.Failure => failure(_errors!),
            _ => throw new InvalidOperationException("Invalid state."),
        };
    }
    
    /// <summary>
    ///     Outputs the following:
    ///     - <paramref name="success"/> if in the Success state.
    ///     - <paramref name="failure"/> if in the Failure state.
    ///     The output is of type <see cref="Task"/> of <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="success">The asynchronous func to use if <see cref="Validation{TValue}"/> is in the Success state.</param>
    /// <param name="failure">The asynchronous func to use if <see cref="Validation{TValue}"/> is in the Failure state.</param>
    /// <typeparam name="TOutput">The output of the match.</typeparam>
    /// <returns>The output of the match.</returns>
    public async Task<TOutput> MatchAsync<TOutput>(
        Func<TValue, Task<TOutput>> success,
        Func<Error[], Task<TOutput>> failure)
    {
        return _state switch
        {
            ValidationState.Success => await success(_value!),
            ValidationState.Failure => await failure(_errors!),
            _ => throw new InvalidOperationException("Invalid state."),
        };
    }
    
    /// <summary>
    ///      Returns the validation of <paramref name="bindFunc"/> if in the Success state,
    ///      otherwise returns <see cref="Validation{TOutput}"/> in the Failure state.
    /// </summary>
    /// <param name="bindFunc">The func to apply if in the Success state.</param>
    /// <typeparam name="TOutput">The type of the Success output.</typeparam>
    /// <returns>
    ///      The validation of <paramref name="bindFunc"/> if in the Success state,
    ///      otherwise returns <see cref="Validation{TOutput}"/> in the Failure state.
    /// </returns>
    public Validation<TOutput> Bind<TOutput>(
        Func<TValue, Validation<TOutput>> bindFunc)
    {
        return _state switch
        {
            ValidationState.Success => bindFunc(_value!),
            ValidationState.Failure => Validation<TOutput>.Failure(_errors!),
            _ => throw new InvalidOperationException("Invalid state."),
        };
    }
    
    /// <summary>
    ///      Returns the validation of <paramref name="bindFunc"/> if in the Success state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Validation{TOutput}"/> in the Failure state.
    /// </summary>
    /// <param name="bindFunc">The asynchronous func to apply if in the Success state.</param>
    /// <typeparam name="TOutput">The type of the Success output.</typeparam>
    /// <returns>
    ///      The validation of <paramref name="bindFunc"/> if in the Success state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Validation{TOutput}"/> in the Failure state.
    /// </returns>
    public async Task<Validation<TOutput>> BindAsync<TOutput>(
        Func<TValue, Task<Validation<TOutput>>> bindFunc)
    {
        return _state switch
        {
            ValidationState.Success => await bindFunc(_value!),
            ValidationState.Failure => Validation<TOutput>.Failure(_errors!),
            _ => throw new InvalidOperationException("Invalid state."),
        };
    }
    
    /// <summary>
    ///      Performs transformation into <see cref="Validation{TOutput}"/> when it's in the Success state,
    ///      otherwise returns <see cref="Validation{TOutput}"/> in the Failure state.
    /// </summary>
    /// <param name="transform">The function to transform to <typeparamref name="TOutput"/>.</param>
    /// <typeparam name="TOutput">The type of the transformed Success output.</typeparam>
    /// <returns>
    ///      The validation of <paramref name="transform"/> if in the Success state,
    ///      otherwise returns <see cref="Validation{TOutput}"/> in the Failure state.
    /// </returns>
    public Validation<TOutput> Map<TOutput>(
        Func<TValue, TOutput> transform)
    {
        return _state switch
        {
            ValidationState.Success => Validation<TOutput>.Success(transform(_value!)),
            ValidationState.Failure => Validation<TOutput>.Failure(_errors!),
            _ => throw new InvalidOperationException("Invalid state."),
        };
    }
    
    /// <summary>
    ///      Performs transformation into <see cref="Validation{TOutput}"/> when it's in the Success state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Validation{TOutput}"/> in the Failure state.
    /// </summary>
    /// <param name="transform">The asynchronous function to transform to <typeparamref name="TOutput"/>.</param>
    /// <typeparam name="TOutput">The type of the transformed Success output.</typeparam>
    /// <returns>
    ///      The validation of <paramref name="transform"/> if in the Success state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Validation{TOutput}"/> in the Failure state.
    /// </returns>
    public async Task<Validation<TOutput>> MapAsync<TOutput>(
        Func<TValue, Task<TOutput>> transform)
    {
        return _state switch
        {
            ValidationState.Success => Validation<TOutput>.Success(await transform(_value!)),
            ValidationState.Failure => Validation<TOutput>.Failure(_errors!),
            _ => throw new InvalidOperationException("Invalid state."),
        };
    }
    
    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Success state.
    /// </summary>
    /// <param name="action">The action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public Validation<TValue> OnSuccess(Action<TValue> action)
    {
        if (_state is ValidationState.Success)
        {
            action(_value!);
        }

        return this;
    }
    
    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Success state.
    /// </summary>
    /// <param name="action">The action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public Validation<TValue> OnSuccess(Func<TValue, Unit> action)
    {
        if (_state is ValidationState.Success)
        {
            action(_value!);
        }

        return this;
    }
    
    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Success state.
    /// </summary>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public async Task<Validation<TValue>> OnSuccessAsync(Func<TValue, Task> action)
    {
        if (_state is ValidationState.Success)
        {
            await action(_value!);
        }

        return this;
    }
    
    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Success state.
    /// </summary>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public async Task<Validation<TValue>> OnSuccessAsync(Func<TValue, Task<Unit>> action)
    {
        if (_state is ValidationState.Success)
        {
            await action(_value!);
        }

        return this;
    }
    
    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Failure state.
    /// </summary>
    /// <param name="action">The action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public Validation<TValue> OnFailure(Action<Error[]> action)
    {
        if (_state is ValidationState.Failure)
        {
            action(_errors!);
        }

        return this;
    }
    
    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Failure state.
    /// </summary>
    /// <param name="action">The action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public Validation<TValue> OnFailure(Func<Error[], Unit> action)
    {
        if (_state is ValidationState.Failure)
        {
            action(_errors!);
        }

        return this;
    }
    
    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Failure state.
    /// </summary>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public async Task<Validation<TValue>> OnFailureAsync(Func<Error[], Task> action)
    {
        if (_state is ValidationState.Failure)
        {
            await action(_errors!);
        }

        return this;
    }
    
    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Failure state.
    /// </summary>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public async Task<Validation<TValue>> OnFailureAsync(Func<Error[], Task<Unit>> action)
    {
        if (_state is ValidationState.Failure)
        {
            await action(_errors!);
        }

        return this;
    }

    /// <summary>
    ///      Performs the relevant action based on the current state.
    /// </summary>
    /// <param name="success">The action to perform if in the Success state.</param>
    /// <param name="failure">The action to perform if in the Failure state.</param>
    /// <returns>The current object after possibly performing the action.</returns>
    public Validation<TValue> Perform(
        Action<TValue>? success = null,
        Action<Error[]>? failure = null)
    {
        switch (_state)
        {
            case ValidationState.Success:
                if (success is not null)
                {
                    success(_value!);
                }
                break;
            case ValidationState.Failure:
                if (failure is not null)
                {
                    failure(_errors!);
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
    /// <param name="success">The action to perform if in the Success state.</param>
    /// <param name="failure">The action to perform if in the Failure state.</param>
    /// <returns>The current object after possibly performing the action.</returns>
    public Validation<TValue> Perform(
        Func<TValue, Unit>? success = null,
        Func<Error[], Unit>? failure = null)
    {
        switch (_state)
        {
            case ValidationState.Success:
                if (success is not null)
                {
                    success(_value!);
                }
                break;
            case ValidationState.Failure:
                if (failure is not null)
                {
                    failure(_errors!);
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
    /// <param name="success">The asynchronous action to perform if in the Success state.</param>
    /// <param name="failure">The asynchronous action to perform if in the Failure state.</param>
    /// <returns>The current object after possibly performing the action.</returns>
    public async Task<Validation<TValue>> PerformAsync(
        Func<TValue, Task>? success = null,
        Func<Error[], Task>? failure = null)
    {
        switch (_state)
        {
            case ValidationState.Success:
                if (success is not null)
                {
                    await success(_value!);
                }
                break;
            case ValidationState.Failure:
                if (failure is not null)
                {
                    await failure(_errors!);
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
    /// <param name="success">The action to perform if in the Success state.</param>
    /// <param name="failure">The asynchronous action to perform if in the Failure state.</param>
    /// <returns>The current object after possibly performing the action.</returns>
    public async Task<Validation<TValue>> PerformAsync(
        Action<TValue>? success = null,
        Func<Error[], Task>? failure = null)
    {
        switch (_state)
        {
            case ValidationState.Success:
                if (success is not null)
                {
                    success(_value!);
                }
                break;
            case ValidationState.Failure:
                if (failure is not null)
                {
                    await failure(_errors!);
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
    /// <param name="success">The asynchronous action to perform if in the Success state.</param>
    /// <param name="failure">The action to perform if in the Failure state.</param>
    /// <returns>The current object after possibly performing the action.</returns>
    public async Task<Validation<TValue>> PerformAsync(
        Func<TValue, Task>? success = null,
        Action<Error[]>? failure = null)
    {
        switch (_state)
        {
            case ValidationState.Success:
                if (success is not null)
                {
                    await success(_value!);
                }
                break;
            case ValidationState.Failure:
                if (failure is not null)
                {
                    failure(_errors!);
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
    /// <param name="success">The asynchronous action to perform if in the Success state.</param>
    /// <param name="failure">The asynchronous action to perform if in the Failure state.</param>
    /// <returns>The current object after possibly performing the action.</returns>
    public async Task<Validation<TValue>> PerformAsync(
        Func<TValue, Task<Unit>>? success = null,
        Func<Error[], Task<Unit>>? failure = null)
    {
        switch (_state)
        {
            case ValidationState.Success:
                if (success is not null)
                {
                    await success(_value!);
                }
                break;
            case ValidationState.Failure:
                if (failure is not null)
                {
                    await failure(_errors!);
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
    /// <param name="success">The action to perform if in the Success state.</param>
    /// <param name="failure">The asynchronous action to perform if in the Failure state.</param>
    /// <returns>The current object after possibly performing the action.</returns>
    public async Task<Validation<TValue>> PerformAsync(
        Func<TValue, Unit>? success = null,
        Func<Error[], Task<Unit>>? failure = null)
    {
        switch (_state)
        {
            case ValidationState.Success:
                if (success is not null)
                {
                    success(_value!);
                }
                break;
            case ValidationState.Failure:
                if (failure is not null)
                {
                    await failure(_errors!);
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
    /// <param name="success">The asynchronous action to perform if in the Success state.</param>
    /// <param name="failure">The asynchronous action to perform if in the Failure state.</param>
    /// <returns>The current object after possibly performing the action.</returns>
    public async Task<Validation<TValue>> PerformAsync(
        Func<TValue, Task<Unit>>? success = null,
        Func<Error[], Unit>? failure = null)
    {
        switch (_state)
        {
            case ValidationState.Success:
                if (success is not null)
                {
                    await success(_value!);
                }
                break;
            case ValidationState.Failure:
                if (failure is not null)
                {
                    failure(_errors!);
                }
                break;
            default:
                throw new InvalidOperationException("Invalid state.");
        }
        
        return this;
    }
    
    /// <summary>
    ///      Returns the <paramref name="fallback"/> if in the Failure state.
    /// </summary>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>Returns the <paramref name="fallback"/> if in the Failure state.</returns>
    public Validation<TValue> FallbackTo(Validation<TValue> fallback)
    {
        return _state switch
        {
            ValidationState.Success => this,
            ValidationState.Failure => fallback,
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }
    
    /// <summary>
    ///      Returns the <paramref name="fallback"/> if in the Failure state.
    /// </summary>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>Returns the <paramref name="fallback"/> if in the Failure state.</returns>
    public async Task<Validation<TValue>> FallbackToAsync(Task<Validation<TValue>> fallback)
    {
        return _state switch
        {
            ValidationState.Success => this,
            ValidationState.Failure => await fallback,
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }
    
    /// <summary>
    ///      Returns the <paramref name="fallback"/> if in the Failure state.
    /// </summary>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>Returns the <paramref name="fallback"/> if in the Failure state.</returns>
    public Validation<TValue> FallbackTo(Func<Validation<TValue>> fallback)
    {
        return _state switch
        {
            ValidationState.Success => this,
            ValidationState.Failure => fallback(),
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }
    
    /// <summary>
    ///      Returns the <paramref name="fallback"/> if in the Failure state.
    /// </summary>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>Returns the <paramref name="fallback"/> if in the Failure state.</returns>
    public async Task<Validation<TValue>> FallbackToAsync(Func<Task<Validation<TValue>>> fallback)
    {
        return _state switch
        {
            ValidationState.Success => this,
            ValidationState.Failure => await fallback(),
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }    
    
    /// <summary>
    ///     Converts a <see cref="Validation{TValue}"/> to an <see cref="Option{TValue}"/>.
    /// </summary>
    /// <returns><see cref="Option{TValue}"/></returns>
    public Option<TValue> ToOption()
    {
        return _state switch
        {
            ValidationState.Success => Value!,
            _ => Option<TValue>.None()
        };
    }

    /// <summary>
    ///     Converts a <see cref="Validation{TValue}"/> to an <see cref="Option{TValue}"/>.
    /// </summary>
    /// <param name="option">The option to produce when <see cref="Option{TValue}"/> is in the None state</param>
    /// <returns><see cref="Option{TValue}"/></returns>
    public Option<TValue> ToOption(Func<Option<TValue>> option)
    {
        return _state switch
        {
            ValidationState.Success => Value!,
            _ => option()
        };
    }

    /// <summary>
    ///     Converts a <see cref="Validation{TValue}"/> to an <see cref="Option{TValue}"/>.
    /// </summary>
    /// <param name="option">The option to produce when <see cref="Option{TValue}"/> is in the None state</param>
    /// <param name="firstParam">First parameter of the option func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <returns><see cref="Option{TValue}"/></returns>
    public Option<TValue> ToOption<TFirstParam>(Func<TFirstParam, Option<TValue>> option, TFirstParam firstParam)
    {
        return _state switch
        {
            ValidationState.Success => Value!,
            _ => option(firstParam)
        };
    }

    /// <summary>
    ///     Converts a <see cref="Validation{TValue}"/> to an <see cref="Option{TValue}"/>.
    /// </summary>
    /// <param name="option">The option to produce when <see cref="Option{TValue}"/> is in the None state</param>
    /// <param name="firstParam">First parameter of the option func</param>
    /// <param name="secondParam">Second parameter of the option func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <returns><see cref="Option{TValue}"/></returns>
    public Option<TValue> ToOption<TFirstParam, TSecondParam>(
        Func<TFirstParam, TSecondParam, Option<TValue>> option, 
        TFirstParam firstParam,
        TSecondParam secondParam)
    {
        return _state switch
        {
            ValidationState.Success => Value!,
            _ => option(firstParam, secondParam)
        };
    }

    /// <summary>
    ///     Converts a <see cref="Validation{TValue}"/> to an <see cref="Option{TValue}"/>.
    /// </summary>
    /// <param name="option">The option to produce when <see cref="Option{TValue}"/> is in the None state</param>
    /// <param name="firstParam">First parameter of the option func</param>
    /// <param name="secondParam">Second parameter of the option func</param>
    /// <param name="thirdParam">Third parameter of the option func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <typeparam name="TThirdParam">The type of the third parameter</typeparam>
    /// <returns><see cref="Option{TValue}"/></returns>
    public Option<TValue> ToOption<TFirstParam, TSecondParam, TThirdParam>(
        Func<TFirstParam, TSecondParam, TThirdParam, Option<TValue>> option, 
        TFirstParam firstParam,
        TSecondParam secondParam,
        TThirdParam thirdParam)
    {
        return _state switch
        {
            ValidationState.Success => Value!,
            _ => option(firstParam, secondParam, thirdParam)
        };
    }

    /// <summary>
    ///     Converts a <see cref="Validation{TValue}"/> to an <see cref="Option{TValue}"/>.
    /// </summary>
    /// <param name="option">The option to produce when <see cref="Option{TValue}"/> is in the None state</param>
    /// <param name="firstParam">First parameter of the option func</param>
    /// <param name="secondParam">Second parameter of the option func</param>
    /// <param name="thirdParam">Third parameter of the option func</param>
    /// <param name="fourthParam">Fourth parameter of the option func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <typeparam name="TThirdParam">The type of the third parameter</typeparam>
    /// <typeparam name="TFourthParam">The type of the fourth parameter</typeparam>
    /// <returns><see cref="Option{TValue}"/></returns>
    public Option<TValue> ToOption<TFirstParam, TSecondParam, TThirdParam, TFourthParam>(
        Func<TFirstParam, TSecondParam, TThirdParam, TFourthParam, Option<TValue>> option, 
        TFirstParam firstParam,
        TSecondParam secondParam,
        TThirdParam thirdParam,
        TFourthParam fourthParam)
    {
        return _state switch
        {
            ValidationState.Success => Value!,
            _ => option(firstParam, secondParam, thirdParam, fourthParam)
        };
    }

    /// <summary>
    ///     Converts a <see cref="Validation{TValue}"/> to an <see cref="Option{TValue}"/>.
    /// </summary>
    /// <param name="option">The option to produce when <see cref="Option{TValue}"/> is in the None state</param>
    /// <param name="firstParam">First parameter of the option func</param>
    /// <param name="secondParam">Second parameter of the option func</param>
    /// <param name="thirdParam">Third parameter of the option func</param>
    /// <param name="fourthParam">Fourth parameter of the option func</param>
    /// <param name="fifthParam">Fifth parameter of the option func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <typeparam name="TThirdParam">The type of the third parameter</typeparam>
    /// <typeparam name="TFourthParam">The type of the fourth parameter</typeparam>
    /// <typeparam name="TFifthParam">The type of the fifth parameter</typeparam>
    /// <returns><see cref="Option{TValue}"/></returns>
    public Option<TValue> ToOption<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam>(
        Func<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, Option<TValue>> option, 
        TFirstParam firstParam,
        TSecondParam secondParam,
        TThirdParam thirdParam,
        TFourthParam fourthParam,
        TFifthParam fifthParam)
    {
        return _state switch
        {
            ValidationState.Success => Value!,
            _ => option(firstParam, secondParam, thirdParam, fourthParam, fifthParam)
        };
    }

    /// <summary>
    ///     Converts a <see cref="Validation{TValue}"/> to an <see cref="Option{TValue}"/>.
    /// </summary>
    /// <param name="option">The option to produce when <see cref="Option{TValue}"/> is in the None state</param>
    /// <param name="firstParam">First parameter of the option func</param>
    /// <param name="secondParam">Second parameter of the option func</param>
    /// <param name="thirdParam">Third parameter of the option func</param>
    /// <param name="fourthParam">Fourth parameter of the option func</param>
    /// <param name="fifthParam">Fifth parameter of the option func</param>
    /// <param name="sixthParam">Sixth parameter of the option func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <typeparam name="TThirdParam">The type of the third parameter</typeparam>
    /// <typeparam name="TFourthParam">The type of the fourth parameter</typeparam>
    /// <typeparam name="TFifthParam">The type of the fifth parameter</typeparam>
    /// <typeparam name="TSixthParam">The type of the sixth parameter</typeparam>
    /// <returns><see cref="Option{TValue}"/></returns>
    public Option<TValue> ToOption<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, TSixthParam>(
        Func<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, TSixthParam, Option<TValue>> option, 
        TFirstParam firstParam,
        TSecondParam secondParam,
        TThirdParam thirdParam,
        TFourthParam fourthParam,
        TFifthParam fifthParam,
        TSixthParam sixthParam)
    {
        return _state switch
        {
            ValidationState.Success => Value!,
            _ => option(firstParam, secondParam, thirdParam, fourthParam, fifthParam, sixthParam)
        };
    }

    /// <summary>
    ///     Converts a <see cref="Validation{TValue}"/> to an <see cref="Option{TValue}"/>.
    /// </summary>
    /// <param name="option">The option to produce when <see cref="Option{TValue}"/> is in the None state</param>
    /// <param name="firstParam">First parameter of the option func</param>
    /// <param name="secondParam">Second parameter of the option func</param>
    /// <param name="thirdParam">Third parameter of the option func</param>
    /// <param name="fourthParam">Fourth parameter of the option func</param>
    /// <param name="fifthParam">Fifth parameter of the option func</param>
    /// <param name="sixthParam">Sixth parameter of the option func</param>
    /// <param name="seventhParam">Seventh parameter of the option func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <typeparam name="TThirdParam">The type of the third parameter</typeparam>
    /// <typeparam name="TFourthParam">The type of the fourth parameter</typeparam>
    /// <typeparam name="TFifthParam">The type of the fifth parameter</typeparam>
    /// <typeparam name="TSixthParam">The type of the sixth parameter</typeparam>
    /// <typeparam name="TSeventhParam">The type of the seventh parameter</typeparam>
    /// <returns><see cref="Option{TValue}"/></returns>
    public Option<TValue> ToOption<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, TSixthParam, TSeventhParam>(
        Func<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, TSixthParam, TSeventhParam, Option<TValue>> option, 
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
            ValidationState.Success => Value!,
            _ => option(firstParam, secondParam, thirdParam, fourthParam, fifthParam, sixthParam, seventhParam)
        };
    }

    /// <summary>
    ///     Converts a <see cref="Validation{TValue}"/> to an <see cref="Option{TValue}"/>.
    /// </summary>
    /// <param name="option">The option to produce when <see cref="Option{TValue}"/> is in the None state</param>
    /// <param name="firstParam">First parameter of the option func</param>
    /// <param name="secondParam">Second parameter of the option func</param>
    /// <param name="thirdParam">Third parameter of the option func</param>
    /// <param name="fourthParam">Fourth parameter of the option func</param>
    /// <param name="fifthParam">Fifth parameter of the option func</param>
    /// <param name="sixthParam">Sixth parameter of the option func</param>
    /// <param name="seventhParam">Seventh parameter of the option func</param>
    /// <param name="eighthParam">Eighth parameter of the option func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <typeparam name="TSecondParam">The type of the second parameter</typeparam>
    /// <typeparam name="TThirdParam">The type of the third parameter</typeparam>
    /// <typeparam name="TFourthParam">The type of the fourth parameter</typeparam>
    /// <typeparam name="TFifthParam">The type of the fifth parameter</typeparam>
    /// <typeparam name="TSixthParam">The type of the sixth parameter</typeparam>
    /// <typeparam name="TSeventhParam">The type of the seventh parameter</typeparam>
    /// <typeparam name="TEighthParam">The type of the eighth parameter</typeparam>
    /// <returns><see cref="Option{TValue}"/></returns>
    public Option<TValue> ToOption<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, TSixthParam, TSeventhParam, TEighthParam>(
        Func<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, TSixthParam, TSeventhParam, TEighthParam, Option<TValue>> option, 
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
            ValidationState.Success => Value!,
            _ => option(firstParam, secondParam, thirdParam, fourthParam, fifthParam, sixthParam, seventhParam, eighthParam)
        };
    }

    /// <summary>
    ///     Converts a <see cref="Validation{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <returns><see cref="Result{TValue}"/></returns>
    public Result<TValue> ToResult()
    {
        return _state switch
        {
            ValidationState.Success => Value!,
            _ => Error.Aggregate(Errors!)
        };
    }

    /// <summary>
    ///     Converts a <see cref="Validation{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="error">The error to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
    /// <returns><see cref="Result{TValue}"/></returns>
    public Result<TValue> ToResult(Error error)
    {
        return _state switch
        {
            ValidationState.Success => Value!,
            _ => error
        };
    }

    /// <summary>
    ///     Converts a <see cref="Validation{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="error">The error to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
    /// <returns><see cref="Result{TValue}"/></returns>
    public Result<TValue> ToResult(Func<Error> error)
    {
        return _state switch
        {
            ValidationState.Success => Value!,
            _ => error()
        };
    }

    /// <summary>
    ///     Converts a <see cref="Validation{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="error">The error to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the error func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <returns><see cref="Result{TValue}"/></returns>
    public Result<TValue> ToResult<TFirstParam>(Func<TFirstParam, Error> error, TFirstParam firstParam)
    {
        return _state switch
        {
            ValidationState.Success => Value!,
            _ => error(firstParam)
        };
    }

    /// <summary>
    ///     Converts a <see cref="Validation{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="error">The error to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
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
            ValidationState.Success => Value!,
            _ => error(firstParam, secondParam)
        };
    }

    /// <summary>
    ///     Converts a <see cref="Validation{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="error">The error to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
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
            ValidationState.Success => Value!,
            _ => error(firstParam, secondParam, thirdParam)
        };
    }

    /// <summary>
    ///     Converts a <see cref="Validation{TValue}"/> to a <see cref="Result{TValue}"/>.
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
            ValidationState.Success => Value!,
            _ => error(firstParam, secondParam, thirdParam, fourthParam)
        };
    }

    /// <summary>
    ///     Converts a <see cref="Validation{TValue}"/> to a <see cref="Result{TValue}"/>.
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
            ValidationState.Success => Value!,
            _ => error(firstParam, secondParam, thirdParam, fourthParam, fifthParam)
        };
    }

    /// <summary>
    ///     Converts a <see cref="Validation{TValue}"/> to a <see cref="Result{TValue}"/>.
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
            ValidationState.Success => Value!,
            _ => error(firstParam, secondParam, thirdParam, fourthParam, fifthParam, sixthParam)
        };
    }

    /// <summary>
    ///     Converts a <see cref="Validation{TValue}"/> to a <see cref="Result{TValue}"/>.
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
            ValidationState.Success => Value!,
            _ => error(firstParam, secondParam, thirdParam, fourthParam, fifthParam, sixthParam, seventhParam)
        };
    }

    /// <summary>
    ///     Converts a <see cref="Validation{TValue}"/> to a <see cref="Result{TValue}"/>.
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
            ValidationState.Success => Value!,
            _ => error(firstParam, secondParam, thirdParam, fourthParam, fifthParam, sixthParam, seventhParam, eighthParam)
        };
    }

    /// <summary>
    ///     Converts a <see cref="Validation{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="result">The result to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
    /// <returns><see cref="Result{TValue}"/></returns>
    public Result<TValue> ToResult(Func<Result<TValue>> result)
    {
        return _state switch
        {
            ValidationState.Success => Value!,
            _ => result()
        };
    }

    /// <summary>
    ///     Converts a <see cref="Validation{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="result">The result to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the error func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <returns><see cref="Result{TValue}"/></returns>
    public Result<TValue> ToResult<TFirstParam>(Func<TFirstParam, Result<TValue>> result, TFirstParam firstParam)
    {
        return _state switch
        {
            ValidationState.Success => Value!,
            _ => result(firstParam)
        };
    }

    /// <summary>
    ///     Converts a <see cref="Validation{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="result">The result to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the error func</param>
    /// <param name="secondParam">Second parameter of the error func</param>
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
            ValidationState.Success => Value!,
            _ => result(firstParam, secondParam)
        };
    }

    /// <summary>
    ///     Converts a <see cref="Validation{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="result">The result to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the error func</param>
    /// <param name="secondParam">Second parameter of the error func</param>
    /// <param name="thirdParam">Third parameter of the error func</param>
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
            ValidationState.Success => Value!,
            _ => result(firstParam, secondParam, thirdParam)
        };
    }

    /// <summary>
    ///     Converts a <see cref="Validation{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="result">The result to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
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
        Func<TFirstParam, TSecondParam, TThirdParam, TFourthParam, Result<TValue>> result, 
        TFirstParam firstParam,
        TSecondParam secondParam,
        TThirdParam thirdParam,
        TFourthParam fourthParam)
    {
        return _state switch
        {
            ValidationState.Success => Value!,
            _ => result(firstParam, secondParam, thirdParam, fourthParam)
        };
    }

    /// <summary>
    ///     Converts a <see cref="Validation{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="result">The result to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
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
        Func<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, Result<TValue>> result, 
        TFirstParam firstParam,
        TSecondParam secondParam,
        TThirdParam thirdParam,
        TFourthParam fourthParam,
        TFifthParam fifthParam)
    {
        return _state switch
        {
            ValidationState.Success => Value!,
            _ => result(firstParam, secondParam, thirdParam, fourthParam, fifthParam)
        };
    }

    /// <summary>
    ///     Converts a <see cref="Validation{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="result">The result to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
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
            ValidationState.Success => Value!,
            _ => result(firstParam, secondParam, thirdParam, fourthParam, fifthParam, sixthParam)
        };
    }

    /// <summary>
    ///     Converts a <see cref="Validation{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="result">The result to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
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
            ValidationState.Success => Value!,
            _ => result(firstParam, secondParam, thirdParam, fourthParam, fifthParam, sixthParam, seventhParam)
        };
    }

    /// <summary>
    ///     Converts a <see cref="Validation{TValue}"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="result">The result to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
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
            ValidationState.Success => Value!,
            _ => result(firstParam, secondParam, thirdParam, fourthParam, fifthParam, sixthParam, seventhParam, eighthParam)
        };
    }
    
    /// <summary>
    ///      Constructs <see cref="Validation{TValue}"/> from a <typeparamref name="TValue"/> in the Success state.
    /// </summary>
    /// <param name="value">The value to construct the <see cref="Validation{TValue}"/> type from.</param>
    /// <returns>The <see cref="Validation{TValue}"/> type in the Success state.</returns>
    public static Validation<TValue> Success(TValue value) => new(value);
    
    /// <summary>
    ///      Constructs <see cref="Validation{TValue}"/> from an <see cref="Error"/> in the Failure state.
    /// </summary>
    /// <param name="errors">The errors to construct the <see cref="Validation{TValue}"/> type from.</param>
    /// <returns>The <see cref="Validation{TValue}"/> type in the Failure state.</returns>
    public static Validation<TValue> Failure(Error[] errors) => new(errors);
    
    /// <summary>
    ///      Constructs <see cref="Validation{TValue}"/> from an <see cref="Error"/> in the Failure state.
    /// </summary>
    /// <param name="errors">The errors to construct the <see cref="Validation{TValue}"/> type from.</param>
    /// <returns>The <see cref="Validation{TValue}"/> type in the Failure state.</returns>
    public static Validation<TValue> Failure(List<Error> errors) => new(errors.ToArray());
    
    /// <summary>
    ///      Implicitly constructs <see cref="Validation{TValue}"/> from a <typeparamref name="TValue"/> in the Success state.
    /// </summary>
    /// <param name="value">The value to construct the <see cref="Validation{TValue}"/> type from.</param>
    /// <returns>The <see cref="Validation{TValue}"/> type in the Success state.</returns>
    public static implicit operator Validation<TValue>(TValue value) => Success(value);
    
    /// <summary>
    ///      Implicitly constructs <see cref="Validation{TValue}"/> from an <see cref="Error"/> in the Failure state.
    /// </summary>
    /// <param name="errors">The errors to construct the <see cref="Validation{TValue}"/> type from.</param>
    /// <returns>The <see cref="Validation{TValue}"/> type in the Failure state.</returns>
    public static implicit operator Validation<TValue>(Error[] errors) => Failure(errors);
    
    /// <summary>
    ///      Implicitly constructs <see cref="Validation{TValue}"/> from an <see cref="Error"/> in the Failure state.
    /// </summary>
    /// <param name="errors">The errors to construct the <see cref="Validation{TValue}"/> type from.</param>
    /// <returns>The <see cref="Validation{TValue}"/> type in the Failure state.</returns>
    public static implicit operator Validation<TValue>(List<Error> errors) => Failure(errors);
}