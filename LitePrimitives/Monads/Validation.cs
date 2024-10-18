using LitePrimitives.InternalStates;

// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Represents a value of one of two possible types (a disjointed union).
///     This type can encapsulate either:
///     - <typeparamref name="TValue"/> in the Success state.
///     - <see cref="IError"/> in the Failure state.
///     But not all at once.
/// </summary>
/// <typeparam name="TValue">The type of the Success state.</typeparam>
public readonly struct Validation<TValue>
{
    private readonly ValidationState _state;
    private readonly TValue? _value;
    private readonly IError[]? _errors;

    private Validation(IError[] errors)
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
    public IError[]? Errors => _errors;
    
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
        Func<IError[], TOutput> failure)
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
        Func<IError[], Task<TOutput>> failure)
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
    public Validation<TValue> OnFailure(Action<IError[]> action)
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
    public Validation<TValue> OnFailure(Func<IError[], Unit> action)
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
    public async Task<Validation<TValue>> OnFailureAsync(Func<IError[], Task> action)
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
    public async Task<Validation<TValue>> OnFailureAsync(Func<IError[], Task<Unit>> action)
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
        Action<IError[]>? failure = null)
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
        Func<IError[], Unit>? failure = null)
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
        Func<IError[], Task>? failure = null)
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
        Func<IError[], Task>? failure = null)
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
        Action<IError[]>? failure = null)
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
        Func<IError[], Task<Unit>>? failure = null)
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
        Func<IError[], Task<Unit>>? failure = null)
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
        Func<IError[], Unit>? failure = null)
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
    ///      Constructs <see cref="Validation{TValue}"/> from a <typeparamref name="TValue"/> in the Success state.
    /// </summary>
    /// <param name="value">The value to construct the <see cref="Validation{TValue}"/> type from.</param>
    /// <returns>The <see cref="Validation{TValue}"/> type in the Success state.</returns>
    public static Validation<TValue> Success(TValue value) => new(value);
    
    /// <summary>
    ///      Constructs <see cref="Validation{TValue}"/> from an <see cref="IError"/> in the Failure state.
    /// </summary>
    /// <param name="error">The error to construct the <see cref="Validation{TValue}"/> type from.</param>
    /// <returns>The <see cref="Validation{TValue}"/> type in the Failure state.</returns>
    public static Validation<TValue> Failure(IError error) => new([error]);
    
    /// <summary>
    ///      Constructs <see cref="Validation{TValue}"/> from an <see cref="IError"/> in the Failure state.
    /// </summary>
    /// <param name="errors">The errors to construct the <see cref="Validation{TValue}"/> type from.</param>
    /// <returns>The <see cref="Validation{TValue}"/> type in the Failure state.</returns>
    public static Validation<TValue> Failure(IError[] errors) => new(errors);
}