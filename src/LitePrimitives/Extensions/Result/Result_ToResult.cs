namespace LitePrimitives;

public static class Result_ToResult
{
	/// <summary>
	///     Converts the <paramref name="response"/> parameter to a <see cref="Result{TResponse}"/> in the Success state.
	/// </summary>
	/// <param name="response">The response to convert.</param>
	/// <typeparam name="TResponse">
	///     The type of the <paramref name="response"/> parameter and the return type for <see cref="Result{TResponse}"/>.
	/// </typeparam>
	/// <returns>The <paramref name="response"/> parameter after converting it to <see cref="Result{TResponse}"/> in the Success state.</returns>
	public static Result<TResponse> ToResult<TResponse>(this TResponse response)
	{
		return Result<TResponse>.Success(response);
	}

	/// <summary>
	///     Converts the <paramref name="error"/> parameter to a <see cref="Result{TResponse}"/> in the Failure state.
	/// </summary>
	/// <param name="error">The error to convert.</param>
	/// <typeparam name="TResponse">
	///     The type of the <paramref name="error"/> parameter and the return type for <see cref="Result{TResponse}"/>.
	/// </typeparam>
	/// <returns>The <paramref name="error"/> parameter after converting it to <see cref="Result{TResponse}"/> in the Failure state.</returns>
	public static Result<TResponse> ToResult<TResponse>(this IError error)
	{
		return Result<TResponse>.Failure(error);
	}

	/// <summary>
	///     Converts the <paramref name="errors"/> parameter to a <see cref="Result{TResponse}"/> in the Failure state.
	/// </summary>
	/// <param name="errors">The errors to convert.</param>
	/// <typeparam name="TResponse">
	///     The type of the <paramref name="errors"/> parameter and the return type for <see cref="Result{TResponse}"/>.
	/// </typeparam>
	/// <returns>The <paramref name="errors"/> parameter after converting it to <see cref="Result{TResponse}"/> in the Failure state.</returns>
	public static Result<TResponse> ToResult<TResponse>(this IError[] errors)
	{
		return Result<TResponse>.Failure(errors);
	}

	/// <summary>
	///     Converts the <paramref name="errors"/> parameter to a <see cref="Result{TResponse}"/> in the Failure state.
	/// </summary>
	/// <param name="errors">The errors parameter to convert.</param>
	/// <typeparam name="TResponse">
	///     The type of the <paramref name="errors"/> parameter and the return type for <see cref="Result{TResponse}"/>.
	/// </typeparam>
	/// <returns>The <paramref name="errors"/> parameter after converting it to <see cref="Result{TResponse}"/> in the Failure state.</returns>
	public static Result<TResponse> ToResult<TResponse>(this List<IError> errors)
	{
		return Result<TResponse>.Failure(errors);
	}
}