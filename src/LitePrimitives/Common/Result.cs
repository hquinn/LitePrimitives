namespace LitePrimitives;

/// <summary>
///     Represents a result from an operation. This type can encapsulate either a response of type <typeparamref name="TResponse"/>
///		when in the Success state, or indicate error(s) of type <see cref="IError"/> in the Failure state.
/// </summary>
/// <typeparam name="TResponse">The type of the response.</typeparam>
public readonly struct Result<TResponse>
{
	private readonly ResultState _state;
	private readonly TResponse? _response;
    private readonly IError[]? _errors;

	private Result(TResponse response)
	{
		_response = response;
		_state = ResultState.Success;
	}

	private Result(IError[] errors)
	{
		_errors = errors;
		_state = ResultState.Failure;
	}

	private Result(IError error)
	{
		_errors = [error];
		_state = ResultState.Failure;
	}

	/// <summary>
	///     Outputs the <paramref name="success"/> if in the Success state, otherwise outputs the <paramref name="failure"/>.
	///     The output is of type <typeparamref name="TOutput"/>.
	/// </summary>
	/// <param name="success">The func to use if <see cref="Result{TResponse}"/> is in the Success state.</param>
	/// <param name="failure">The func to use if <see cref="Result{TResponse}"/> is in the Failure state.</param>
	/// <typeparam name="TOutput">The output of the match.</typeparam>
	/// <returns>The output of the match.</returns>
	public TOutput Match<TOutput>(
		Func<TResponse, TOutput> success, 
		Func<IError[], TOutput> failure)
	{
		return _state is ResultState.Success 
			? success(_response!) 
			: failure(_errors!);
	}

	/// <summary>
	///     Outputs the <paramref name="success"/> if in the Success state, otherwise outputs the <paramref name="failure"/>.
	///     The output is of type <see cref="Task"/> of <typeparamref name="TOutput"/>.
	/// </summary>
	/// <param name="success">The func to use if <see cref="Result{TResponse}"/> is in the Success state.</param>
	/// <param name="failure">The func to use if <see cref="Result{TResponse}"/> is in the Failure state.</param>
	/// <typeparam name="TOutput">The output of the match.</typeparam>
	/// <returns>The output of the match.</returns>
	public Task<TOutput> MatchAsync<TOutput>(
		Func<TResponse, Task<TOutput>> success, 
		Func<IError[], Task<TOutput>> failure)
	{
		return _state is ResultState.Success 
			? success(_response!) 
			: failure(_errors!);
	}

	/// <summary>
	///     Constructs <see cref="Result{TResponse}"/> from a <typeparamref name="TResponse"/> type in the Success state.
	/// </summary>
	/// <param name="response">The response to construct the <see cref="Result{TResponse}"/> from.</param>
	/// <returns>The <see cref="Result{TResponse}"/> type in the Success state.</returns>
	public static Result<TResponse> Success(TResponse response)
	{
		return new Result<TResponse>(response);
	}

	/// <summary>
	///     Constructs <see cref="Result{TResponse}"/> from a singular <see cref="IError"/> in the Failure state.
	/// </summary>
	/// <param name="error">The error to construct the <see cref="Result{TResponse}"/> from.</param>
	/// <returns>The <see cref="Result{TResponse}"/> type in the Failure state.</returns>
	public static Result<TResponse> Failure(IError error)
	{
		return new Result<TResponse>(error);
	}

	/// <summary>
	///     Constructs <see cref="Result{TResponse}"/> from an array of <see cref="IError"/> types in the Failure state.
	/// </summary>
	/// <param name="errors">The errors to construct the <see cref="Result{TResponse}"/> from.</param>
	/// <returns>The <see cref="Result{TResponse}"/> type in the Failure state.</returns>
	public static Result<TResponse> Failure(IError[] errors)
	{
		return new Result<TResponse>(errors);
	}

	/// <summary>
	///     Constructs <see cref="Result{TResponse}"/> from a list of <see cref="IError"/> types in the Failure state.
	/// </summary>
	/// <param name="errors">The errors to construct the <see cref="Result{TResponse}"/> from.</param>
	/// <returns>The <see cref="Result{TResponse}"/> type in the Failure state.</returns>
	public static Result<TResponse> Failure(List<IError> errors)
	{
		return new Result<TResponse>(errors.ToArray());
	}
}