namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for OnFailure on the Result type.
/// </summary>
public static class Result_OnFailureExtensions
{
	/// <summary>
	///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Failure state.
	/// </summary>
	/// <param name="input">The input to perform the <paramref name="action"/> on.</param>
	/// <param name="action">The action to perform.</param>
	/// <typeparam name="TResponse">
	///     The type of the <paramref name="input"/> parameter and the return type for <see cref="Result{TResponse}"/>.
	/// </typeparam>
	/// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
	public static Result<TResponse> OnFailure<TResponse>(
		this Result<TResponse> input, 
		Action<IError[]> action)
	{
		return input.Match(
			success: _ => input,
			failure: errors =>
			{
				action(errors);
				return input;
			});
	}

	/// <summary>
	///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Failure state.
	/// </summary>
	/// <param name="input">The input to perform the <paramref name="action"/> on.</param>
	/// <param name="action">The action to perform.</param>
	/// <typeparam name="TResponse">
	///     The type of the <paramref name="input"/> parameter and the return type for <see cref="Result{TResponse}"/>.
	/// </typeparam>
	/// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
	public static Result<TResponse> OnFailure<TResponse>(
		this Result<TResponse> input, 
		Func<IError[], Unit> action)
	{
		return input.Match(
			success: _ => input,
			failure: errors =>
			{
				action(errors);
				return input;
			});
	}

	/// <summary>
	///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Failure state.
	/// </summary>
	/// <param name="input">The input to perform the <paramref name="action"/> on.</param>
	/// <param name="action">The asynchronous action to perform.</param>
	/// <typeparam name="TResponse">
	///     The type of the <paramref name="input"/> parameter and the return type for <see cref="Result{TResponse}"/>.
	/// </typeparam>
	/// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
	public static async Task<Result<TResponse>> OnFailureAsync<TResponse>(
		this Result<TResponse> input,
		Func<IError[], Task> action)
	{
		return await input.MatchAsync(
			success: _ => input.ToTask(),
			failure: async errors =>
			{
				await action(errors);
				return input;
			});
	}

	/// <summary>
	///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Failure state.
	/// </summary>
	/// <param name="input">The asynchronous input to perform the <paramref name="action"/> on.</param>
	/// <param name="action">The asynchronous action to perform.</param>
	/// <typeparam name="TResponse">
	///     The type of the <paramref name="input"/> parameter and the return type for <see cref="Result{TResponse}"/>.
	/// </typeparam>
	/// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
	public static async Task<Result<TResponse>> OnFailureAsync<TResponse>(
		this Task<Result<TResponse>> input,
		Func<IError[], Task> action)
	{
		var result = await input;
		
		return await result.MatchAsync(
			success: _ => input,
			failure: async errors =>
			{
				await action(errors);
				return result;
			});
	}

	/// <summary>
	///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Failure state.
	/// </summary>
	/// <param name="input">The input to perform the <paramref name="action"/> on.</param>
	/// <param name="action">The asynchronous action to perform.</param>
	/// <typeparam name="TResponse">
	///     The type of the <paramref name="input"/> parameter and the return type for <see cref="Result{TResponse}"/>.
	/// </typeparam>
	/// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
	public static async Task<Result<TResponse>> OnFailureAsync<TResponse>(
		this Result<TResponse> input,
		Func<IError[], Task<Unit>> action)
	{
		return await input.MatchAsync(
			success: _ => input.ToTask(),
			failure: async errors =>
			{
				await action(errors);
				return input;
			});
	}

	/// <summary>
	///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Failure state.
	/// </summary>
	/// <param name="input">The asynchronous input to perform the <paramref name="action"/> on.</param>
	/// <param name="action">The asynchronous action to perform.</param>
	/// <typeparam name="TResponse">
	///     The type of the <paramref name="input"/> parameter and the return type for <see cref="Result{TResponse}"/>.
	/// </typeparam>
	/// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
	public static async Task<Result<TResponse>> OnFailureAsync<TResponse>(
		this Task<Result<TResponse>> input,
		Func<IError[], Task<Unit>> action)
	{
		var result = await input;
		
		return await result.MatchAsync(
			success: _ => input,
			failure: async errors =>
			{
				await action(errors);
				return result;
			});
	}
}