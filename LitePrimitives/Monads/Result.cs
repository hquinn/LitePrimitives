using LitePrimitives.InternalStates;

// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Static class to help instantiate <see cref="Result{TValue}"/>
/// </summary>
public static class Result
{
    /// <summary>
    ///      Constructs <see cref="Result{TValue}"/> from a <typeparamref name="TValue"/> in the Success state.
    /// </summary>
    /// <param name="value">The value to construct the <see cref="Result{TValue}"/> type from.</param>
    /// <returns>The <see cref="Result{TValue}"/> type in the Success state.</returns>
    public static Result<TValue> Success<TValue>(TValue value)
    {
        return Result<TValue>.Success(value);
    }

    /// <summary>
    ///      Constructs <see cref="Result{TValue}"/> from an <see cref="Error"/> in the Failure state.
    /// </summary>
    /// <param name="error">The error to construct the <see cref="Result{TValue}"/> type from.</param>
    /// <returns>The <see cref="Result{TValue}"/> type in the Failure state.</returns>
    public static Result<TValue> Failure<TValue>(Error error)
    {
        return Result<TValue>.Failure(error);
    }
}

/// <summary>
///     Represents a value of one of two possible types (a disjointed union).
///     This type can encapsulate either:
///     - <typeparamref name="TValue"/> in the Success state.
///     - <see cref="Error"/> in the Failure state.
///     But not all at once.
/// </summary>
/// <typeparam name="TValue">The type of the Success state.</typeparam>
public readonly struct Result<TValue>
{
    private readonly ResultState _state;
    private readonly TValue? _value;
    private readonly Error? _error;

    private Result(Error error)
    {
        _error = error;
        _state = ResultState.Failure;
    }
    
    private Result(TValue value)
    {
        _value = value;
        _state = ResultState.Success;
    }

    /// <summary>
    ///     Default constructor. Do not use!
    /// </summary>
    public Result()
    {
        _error = LitePrimitives.Error.Failure("InvalidState", "Result created in an invalid state.");
        _state = ResultState.Failure;
    }

    /// <summary>
    ///     Returns true if the <see cref="Result{TValue}"/> is in the Success state.
    /// </summary>
    public bool IsSuccess => _state == ResultState.Success;

    /// <summary>
    ///     Returns true if the <see cref="Result{TValue}"/> is in the Failure state.
    /// </summary>
    public bool IsFailure => _state == ResultState.Failure;
    
    /// <summary>
    ///     Returns the underlying value of the result. Will return null if in the Failure state.
    /// </summary>
    public TValue? Value => _value;
    
    /// <summary>
    ///     Returns the underlying error of the result. Will return null if in the Success state.
    /// </summary>
    public Error? Error => _error;
    
    /// <summary>
    ///     Outputs the following:
    ///     - <paramref name="success"/> if in the Success state.
    ///     - <paramref name="failure"/> if in the Failure state.
    ///     The output is of type <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="success">The func to use if <see cref="Result{TValue}"/> is in the Success state.</param>
    /// <param name="failure">The func to use if <see cref="Result{TValue}"/> is in the Failure state.</param>
    /// <typeparam name="TOutput">The output of the match.</typeparam>
    /// <returns>The output of the match.</returns>
    public TOutput Match<TOutput>(
        Func<TValue, TOutput> success,
        Func<Error, TOutput> failure)
    {
        return _state switch
        {
            ResultState.Success => success(_value!),
            ResultState.Failure => failure(_error!.Value),
            _ => throw new InvalidOperationException("Invalid state."),
        };
    }
    
    /// <summary>
    ///     Outputs the following:
    ///     - <paramref name="success"/> if in the Success state.
    ///     - <paramref name="failure"/> if in the Failure state.
    ///     The output is of type <see cref="Task"/> of <typeparamref name="TOutput"/>.
    /// </summary>
    /// <param name="success">The asynchronous func to use if <see cref="Result{TValue}"/> is in the Success state.</param>
    /// <param name="failure">The asynchronous func to use if <see cref="Result{TValue}"/> is in the Failure state.</param>
    /// <typeparam name="TOutput">The output of the match.</typeparam>
    /// <returns>The output of the match.</returns>
    public async Task<TOutput> MatchAsync<TOutput>(
        Func<TValue, Task<TOutput>> success,
        Func<Error, Task<TOutput>> failure)
    {
        return _state switch
        {
            ResultState.Success => await success(_value!),
            ResultState.Failure => await failure(_error!.Value),
            _ => throw new InvalidOperationException("Invalid state."),
        };
    }
    
    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Success state,
    ///      otherwise returns <see cref="Result{TOutput}"/> in the Failure state.
    /// </summary>
    /// <param name="bindFunc">The func to apply if in the Success state.</param>
    /// <typeparam name="TOutput">The type of the Success output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the Success state,
    ///      otherwise returns <see cref="Result{TOutput}"/> in the Failure state.
    /// </returns>
    public Result<TOutput> Bind<TOutput>(
        Func<TValue, Result<TOutput>> bindFunc)
    {
        return _state switch
        {
            ResultState.Success => bindFunc(_value!),
            ResultState.Failure => Result<TOutput>.Failure(_error!.Value),
            _ => throw new InvalidOperationException("Invalid state."),
        };
    }
    
    /// <summary>
    ///      Returns the result of <paramref name="bindFunc"/> if in the Success state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Result{TOutput}"/> in the Failure state.
    /// </summary>
    /// <param name="bindFunc">The asynchronous func to apply if in the Success state.</param>
    /// <typeparam name="TOutput">The type of the Success output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="bindFunc"/> if in the Success state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Result{TOutput}"/> in the Failure state.
    /// </returns>
    public async Task<Result<TOutput>> BindAsync<TOutput>(
        Func<TValue, Task<Result<TOutput>>> bindFunc)
    {
        return _state switch
        {
            ResultState.Success => await bindFunc(_value!),
            ResultState.Failure => Result<TOutput>.Failure(_error!.Value),
            _ => throw new InvalidOperationException("Invalid state."),
        };
    }
    
    /// <summary>
    ///      Performs transformation into <see cref="Result{TOutput}"/> when it's in the Success state,
    ///      otherwise returns <see cref="Result{TOutput}"/> in the Failure state.
    /// </summary>
    /// <param name="transform">The function to transform to <typeparamref name="TOutput"/>.</param>
    /// <typeparam name="TOutput">The type of the transformed Success output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Success state,
    ///      otherwise returns <see cref="Result{TOutput}"/> in the Failure state.
    /// </returns>
    public Result<TOutput> Map<TOutput>(
        Func<TValue, TOutput> transform)
    {
        return _state switch
        {
            ResultState.Success => Result<TOutput>.Success(transform(_value!)),
            ResultState.Failure => Result<TOutput>.Failure(_error!.Value),
            _ => throw new InvalidOperationException("Invalid state."),
        };
    }
    
    /// <summary>
    ///      Performs transformation into <see cref="Result{TOutput}"/> when it's in the Success state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Result{TOutput}"/> in the Failure state.
    /// </summary>
    /// <param name="transform">The asynchronous function to transform to <typeparamref name="TOutput"/>.</param>
    /// <typeparam name="TOutput">The type of the transformed Success output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Success state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Result{TOutput}"/> in the Failure state.
    /// </returns>
    public async Task<Result<TOutput>> MapAsync<TOutput>(
        Func<TValue, Task<TOutput>> transform)
    {
        return _state switch
        {
            ResultState.Success => Result<TOutput>.Success(await transform(_value!)),
            ResultState.Failure => Result<TOutput>.Failure(_error!.Value),
            _ => throw new InvalidOperationException("Invalid state."),
        };
    }
    
    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Success state.
    /// </summary>
    /// <param name="action">The action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public Result<TValue> OnSuccess(Action<TValue> action)
    {
        if (_state is ResultState.Success)
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
    public Result<TValue> OnSuccess(Func<TValue, Unit> action)
    {
        if (_state is ResultState.Success)
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
    public async Task<Result<TValue>> OnSuccessAsync(Func<TValue, Task> action)
    {
        if (_state is ResultState.Success)
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
    public async Task<Result<TValue>> OnSuccessAsync(Func<TValue, Task<Unit>> action)
    {
        if (_state is ResultState.Success)
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
    public Result<TValue> OnFailure(Action<Error> action)
    {
        if (_state is ResultState.Failure)
        {
            action(_error!.Value);
        }

        return this;
    }
    
    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Failure state.
    /// </summary>
    /// <param name="action">The action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public Result<TValue> OnFailure(Func<Error, Unit> action)
    {
        if (_state is ResultState.Failure)
        {
            action(_error!.Value);
        }

        return this;
    }
    
    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Failure state.
    /// </summary>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public async Task<Result<TValue>> OnFailureAsync(Func<Error, Task> action)
    {
        if (_state is ResultState.Failure)
        {
            await action(_error!.Value);
        }

        return this;
    }
    
    /// <summary>
    ///      Performs the <paramref name="action"/> if in the Failure state.
    /// </summary>
    /// <param name="action">The asynchronous action to perform.</param>
    /// <returns>The current object after possibly performing the <paramref name="action"/>.</returns>
    public async Task<Result<TValue>> OnFailureAsync(Func<Error, Task<Unit>> action)
    {
        if (_state is ResultState.Failure)
        {
            await action(_error!.Value);
        }

        return this;
    }

    /// <summary>
    ///      Performs the relevant action based on the current state.
    /// </summary>
    /// <param name="success">The action to perform if in the Success state.</param>
    /// <param name="failure">The action to perform if in the Failure state.</param>
    /// <returns>The current object after possibly performing the action.</returns>
    public Result<TValue> Perform(
        Action<TValue>? success = null,
        Action<Error>? failure = null)
    {
        switch (_state)
        {
            case ResultState.Success:
                if (success is not null)
                {
                    success(_value!);
                }
                break;
            case ResultState.Failure:
                if (failure is not null)
                {
                    failure(_error!.Value);
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
    public Result<TValue> Perform(
        Func<TValue, Unit>? success = null,
        Func<Error, Unit>? failure = null)
    {
        switch (_state)
        {
            case ResultState.Success:
                if (success is not null)
                {
                    success(_value!);
                }
                break;
            case ResultState.Failure:
                if (failure is not null)
                {
                    failure(_error!.Value);
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
    public async Task<Result<TValue>> PerformAsync(
        Func<TValue, Task>? success = null,
        Func<Error, Task>? failure = null)
    {
        switch (_state)
        {
            case ResultState.Success:
                if (success is not null)
                {
                    await success(_value!);
                }
                break;
            case ResultState.Failure:
                if (failure is not null)
                {
                    await failure(_error!.Value);
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
    public async Task<Result<TValue>> PerformAsync(
        Action<TValue>? success = null,
        Func<Error, Task>? failure = null)
    {
        switch (_state)
        {
            case ResultState.Success:
                if (success is not null)
                {
                    success(_value!);
                }
                break;
            case ResultState.Failure:
                if (failure is not null)
                {
                    await failure(_error!.Value);
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
    public async Task<Result<TValue>> PerformAsync(
        Func<TValue, Task>? success = null,
        Action<Error>? failure = null)
    {
        switch (_state)
        {
            case ResultState.Success:
                if (success is not null)
                {
                    await success(_value!);
                }
                break;
            case ResultState.Failure:
                if (failure is not null)
                {
                    failure(_error!.Value);
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
    public async Task<Result<TValue>> PerformAsync(
        Func<TValue, Task<Unit>>? success = null,
        Func<Error, Task<Unit>>? failure = null)
    {
        switch (_state)
        {
            case ResultState.Success:
                if (success is not null)
                {
                    await success(_value!);
                }
                break;
            case ResultState.Failure:
                if (failure is not null)
                {
                    await failure(_error!.Value);
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
    public async Task<Result<TValue>> PerformAsync(
        Func<TValue, Unit>? success = null,
        Func<Error, Task<Unit>>? failure = null)
    {
        switch (_state)
        {
            case ResultState.Success:
                if (success is not null)
                {
                    success(_value!);
                }
                break;
            case ResultState.Failure:
                if (failure is not null)
                {
                    await failure(_error!.Value);
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
    public async Task<Result<TValue>> PerformAsync(
        Func<TValue, Task<Unit>>? success = null,
        Func<Error, Unit>? failure = null)
    {
        switch (_state)
        {
            case ResultState.Success:
                if (success is not null)
                {
                    await success(_value!);
                }
                break;
            case ResultState.Failure:
                if (failure is not null)
                {
                    failure(_error!.Value);
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
    public Result<TValue> FallbackTo(Result<TValue> fallback)
    {
        return _state switch
        {
            ResultState.Success => this,
            ResultState.Failure => fallback,
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }
    
    /// <summary>
    ///      Returns the <paramref name="fallback"/> if in the Failure state.
    /// </summary>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>Returns the <paramref name="fallback"/> if in the Failure state.</returns>
    public async Task<Result<TValue>> FallbackToAsync(Task<Result<TValue>> fallback)
    {
        return _state switch
        {
            ResultState.Success => this,
            ResultState.Failure => await fallback,
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }
    
    /// <summary>
    ///      Returns the <paramref name="fallback"/> if in the Failure state.
    /// </summary>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>Returns the <paramref name="fallback"/> if in the Failure state.</returns>
    public Result<TValue> FallbackTo(Func<Result<TValue>> fallback)
    {
        return _state switch
        {
            ResultState.Success => this,
            ResultState.Failure => fallback(),
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }
    
    /// <summary>
    ///      Returns the <paramref name="fallback"/> if in the Failure state.
    /// </summary>
    /// <param name="fallback">The fallback value.</param>
    /// <returns>Returns the <paramref name="fallback"/> if in the Failure state.</returns>
    public async Task<Result<TValue>> FallbackToAsync(Func<Task<Result<TValue>>> fallback)
    {
        return _state switch
        {
            ResultState.Success => this,
            ResultState.Failure => await fallback(),
            _ => throw new InvalidOperationException("Invalid state.")
        };
    }

    /// <summary>
    ///     Converts a <see cref="Result{TValue}"/> to an <see cref="Option{TValue}"/>.
    /// </summary>
    /// <returns><see cref="Option{TValue}"/></returns>
    public Option<TValue> ToOption()
    {
        return _state switch
        {
            ResultState.Success => Value!,
            _ => Option<TValue>.None()
        };
    }

    /// <summary>
    ///     Converts a <see cref="Result{TValue}"/> to an <see cref="Option{TValue}"/>.
    /// </summary>
    /// <param name="option">The option to produce when <see cref="Option{TValue}"/> is in the None state</param>
    /// <returns><see cref="Option{TValue}"/></returns>
    public Option<TValue> ToOption(Func<Option<TValue>> option)
    {
        return _state switch
        {
            ResultState.Success => Value!,
            _ => option()
        };
    }

    /// <summary>
    ///     Converts a <see cref="Result{TValue}"/> to an <see cref="Option{TValue}"/>.
    /// </summary>
    /// <param name="option">The option to produce when <see cref="Option{TValue}"/> is in the None state</param>
    /// <param name="firstParam">First parameter of the option func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <returns><see cref="Option{TValue}"/></returns>
    public Option<TValue> ToOption<TFirstParam>(Func<TFirstParam, Option<TValue>> option, TFirstParam firstParam)
    {
        return _state switch
        {
            ResultState.Success => Value!,
            _ => option(firstParam)
        };
    }

    /// <summary>
    ///     Converts a <see cref="Result{TValue}"/> to an <see cref="Option{TValue}"/>.
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
            ResultState.Success => Value!,
            _ => option(firstParam, secondParam)
        };
    }

    /// <summary>
    ///     Converts a <see cref="Result{TValue}"/> to an <see cref="Option{TValue}"/>.
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
            ResultState.Success => Value!,
            _ => option(firstParam, secondParam, thirdParam)
        };
    }

    /// <summary>
    ///     Converts a <see cref="Result{TValue}"/> to an <see cref="Option{TValue}"/>.
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
            ResultState.Success => Value!,
            _ => option(firstParam, secondParam, thirdParam, fourthParam)
        };
    }

    /// <summary>
    ///     Converts a <see cref="Result{TValue}"/> to an <see cref="Option{TValue}"/>.
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
            ResultState.Success => Value!,
            _ => option(firstParam, secondParam, thirdParam, fourthParam, fifthParam)
        };
    }

    /// <summary>
    ///     Converts a <see cref="Result{TValue}"/> to an <see cref="Option{TValue}"/>.
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
            ResultState.Success => Value!,
            _ => option(firstParam, secondParam, thirdParam, fourthParam, fifthParam, sixthParam)
        };
    }

    /// <summary>
    ///     Converts a <see cref="Result{TValue}"/> to an <see cref="Option{TValue}"/>.
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
            ResultState.Success => Value!,
            _ => option(firstParam, secondParam, thirdParam, fourthParam, fifthParam, sixthParam, seventhParam)
        };
    }

    /// <summary>
    ///     Converts a <see cref="Result{TValue}"/> to an <see cref="Option{TValue}"/>.
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
            ResultState.Success => Value!,
            _ => option(firstParam, secondParam, thirdParam, fourthParam, fifthParam, sixthParam, seventhParam, eighthParam)
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
            ResultState.Success => Value!,
            _ => new [] { _error!.Value }
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
            ResultState.Success => Value!,
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
            ResultState.Success => Value!,
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
            ResultState.Success => Value!,
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
            ResultState.Success => Value!,
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
            ResultState.Success => Value!,
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
            ResultState.Success => Value!,
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
            ResultState.Success => Value!,
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
            ResultState.Success => Value!,
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
            ResultState.Success => Value!,
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
            ResultState.Success => Value!,
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
            ResultState.Success => Value!,
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
            ResultState.Success => Value!,
            _ => validation()
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Validation{TValue}"/>.
    /// </summary>
    /// <param name="validation">The validation to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the error func</param>
    /// <typeparam name="TFirstParam">The type of the first parameter</typeparam>
    /// <returns><see cref="Validation{TValue}"/></returns>
    public Validation<TValue> ToValidation<TFirstParam>(Func<TFirstParam, Validation<TValue>> validation, TFirstParam firstParam)
    {
        return _state switch
        {
            ResultState.Success => Value!,
            _ => validation(firstParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Validation{TValue}"/>.
    /// </summary>
    /// <param name="validation">The validation to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the error func</param>
    /// <param name="secondParam">Second parameter of the error func</param>
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
            ResultState.Success => Value!,
            _ => validation(firstParam, secondParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Validation{TValue}"/>.
    /// </summary>
    /// <param name="validation">The validation to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
    /// <param name="firstParam">First parameter of the error func</param>
    /// <param name="secondParam">Second parameter of the error func</param>
    /// <param name="thirdParam">Third parameter of the error func</param>
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
            ResultState.Success => Value!,
            _ => validation(firstParam, secondParam, thirdParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Validation{TValue}"/>.
    /// </summary>
    /// <param name="validation">The validation to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
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
        Func<TFirstParam, TSecondParam, TThirdParam, TFourthParam, Validation<TValue>> validation, 
        TFirstParam firstParam,
        TSecondParam secondParam,
        TThirdParam thirdParam,
        TFourthParam fourthParam)
    {
        return _state switch
        {
            ResultState.Success => Value!,
            _ => validation(firstParam, secondParam, thirdParam, fourthParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Validation{TValue}"/>.
    /// </summary>
    /// <param name="validation">The validation to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
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
        Func<TFirstParam, TSecondParam, TThirdParam, TFourthParam, TFifthParam, Validation<TValue>> validation, 
        TFirstParam firstParam,
        TSecondParam secondParam,
        TThirdParam thirdParam,
        TFourthParam fourthParam,
        TFifthParam fifthParam)
    {
        return _state switch
        {
            ResultState.Success => Value!,
            _ => validation(firstParam, secondParam, thirdParam, fourthParam, fifthParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Validation{TValue}"/>.
    /// </summary>
    /// <param name="validation">The validation to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
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
            ResultState.Success => Value!,
            _ => validation(firstParam, secondParam, thirdParam, fourthParam, fifthParam, sixthParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Validation{TValue}"/>.
    /// </summary>
    /// <param name="validation">The validation to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
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
            ResultState.Success => Value!,
            _ => validation(firstParam, secondParam, thirdParam, fourthParam, fifthParam, sixthParam, seventhParam)
        };
    }

    /// <summary>
    ///     Converts an <see cref="Option{TValue}"/> to a <see cref="Validation{TValue}"/>.
    /// </summary>
    /// <param name="validation">The validation to produce when <see cref="Validation{TValue}"/> is in the Failure state</param>
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
            ResultState.Success => Value!,
            _ => validation(firstParam, secondParam, thirdParam, fourthParam, fifthParam, sixthParam, seventhParam, eighthParam)
        };
    }
    
    /// <summary>
    ///      Constructs <see cref="Result{TValue}"/> from a <typeparamref name="TValue"/> in the Success state.
    /// </summary>
    /// <param name="value">The value to construct the <see cref="Result{TValue}"/> type from.</param>
    /// <returns>The <see cref="Result{TValue}"/> type in the Success state.</returns>
    public static Result<TValue> Success(TValue value) => new(value);
    
    /// <summary>
    ///      Constructs <see cref="Result{TValue}"/> from an <see cref="Error"/> in the Failure state.
    /// </summary>
    /// <param name="error">The error to construct the <see cref="Result{TValue}"/> type from.</param>
    /// <returns>The <see cref="Result{TValue}"/> type in the Failure state.</returns>
    public static Result<TValue> Failure(Error error) => new(error);
    
    /// <summary>
    ///      Implicitly constructs <see cref="Result{TValue}"/> from a <typeparamref name="TValue"/> in the Success state.
    /// </summary>
    /// <param name="value">The value to construct the <see cref="Result{TValue}"/> type from.</param>
    /// <returns>The <see cref="Result{TValue}"/> type in the Success state.</returns>
    public static implicit operator Result<TValue>(TValue value) => Success(value);
    
    /// <summary>
    ///      Implicitly constructs <see cref="Result{TValue}"/> from an <see cref="Error"/> in the Failure state.
    /// </summary>
    /// <param name="error">The error to construct the <see cref="Result{TValue}"/> type from.</param>
    /// <returns>The <see cref="Result{TValue}"/> type in the Failure state.</returns>
    public static implicit operator Result<TValue>(Error error) => Failure(error);
}