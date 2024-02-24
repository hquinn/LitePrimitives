namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for OnSuccess on the Result type.
/// </summary>
public static class Result_OnSuccessExtensions
{
	/// <summary>
	///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Success state.
	/// </summary>
	/// <param name="input">The input to perform the <paramref name="action"/> on.</param>
	/// <param name="action">The action to perform.</param>
	/// <typeparam name="TResponse">
	///     The type of the <paramref name="input"/> parameter and the return type for <see cref="Result{TResponse}"/>.
	/// </typeparam>
	/// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
	public static Result<TResponse> OnSuccess<TResponse>(
		this Result<TResponse> input, 
		Action<TResponse> action)
	{
		return input.Match(
			success: response =>
			{
				action(response);
				return input;
			},
			failure: _ => input);
	}

	/// <summary>
	///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Success state.
	/// </summary>
	/// <param name="input">The input to perform the <paramref name="action"/> on.</param>
	/// <param name="action">The action to perform.</param>
	/// <typeparam name="TResponse">
	///     The type of the <paramref name="input"/> parameter and the return type for <see cref="Result{TResponse}"/>.
	/// </typeparam>
	/// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
	public static Result<TResponse> OnSuccess<TResponse>(
		this Result<TResponse> input, 
		Func<TResponse, Unit> action)
	{
		return input.Match(
			success: response =>
			{
				action(response);
				return input;
			},
			failure: _ => input);
	}

	/// <summary>
	///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Success state.
	/// </summary>
	/// <param name="input">The input to perform the <paramref name="action"/> on.</param>
	/// <param name="action">The asynchronous action to perform.</param>
	/// <typeparam name="TResponse">
	///     The type of the <paramref name="input"/> parameter and the return type for <see cref="Result{TResponse}"/>.
	/// </typeparam>
	/// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
	public static async Task<Result<TResponse>> OnSuccessAsync<TResponse>(
        this Result<TResponse> input,
        Func<TResponse, Task> action)
	{
		return await input.MatchAsync(
			success: async response =>
			{
				await action(response);
				return input;
			},
			failure: _ => input.ToTask());
	}

	/// <summary>
	///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Success state.
	/// </summary>
	/// <param name="input">The asynchronous input to perform the <paramref name="action"/> on.</param>
	/// <param name="action">The asynchronous action to perform.</param>
	/// <typeparam name="TResponse">
	///     The type of the <paramref name="input"/> parameter and the return type for <see cref="Result{TResponse}"/>.
	/// </typeparam>
	/// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
	public static async Task<Result<TResponse>> OnSuccessAsync<TResponse>(
		this Task<Result<TResponse>> input,
		Func<TResponse, Task> action)
	{
		var result = await input;
		
		return await result.MatchAsync(
			success: async response =>
			{
				await action(response);
				return result;
			},
			failure: _ => input);
	}

	/// <summary>
	///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Success state.
	/// </summary>
	/// <param name="input">The input to perform the <paramref name="action"/> on.</param>
	/// <param name="action">The asynchronous action to perform.</param>
	/// <typeparam name="TResponse">
	///     The type of the <paramref name="input"/> parameter and the return type for <see cref="Result{TResponse}"/>.
	/// </typeparam>
	/// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
	public static async Task<Result<TResponse>> OnSuccessAsync<TResponse>(
        this Result<TResponse> input,
        Func<TResponse, Task<Unit>> action)
	{
		return await input.MatchAsync(
			success: async response =>
			{
				await action(response);
				return input;
			},
			failure: _ => input.ToTask());
	}

	/// <summary>
	///     Performs the <paramref name="action"/> if the <paramref name="input"/> parameter is in the Success state.
	/// </summary>
	/// <param name="input">The asynchronous input to perform the <paramref name="action"/> on.</param>
	/// <param name="action">The asynchronous action to perform.</param>
	/// <typeparam name="TResponse">
	///     The type of the <paramref name="input"/> parameter and the return type for <see cref="Result{TResponse}"/>.
	/// </typeparam>
	/// <returns>The <paramref name="input"/> after possibly performing the <paramref name="action"/>.</returns>
	public static async Task<Result<TResponse>> OnSuccessAsync<TResponse>(
		this Task<Result<TResponse>> input,
		Func<TResponse, Task<Unit>> action)
	{
		var result = await input;
		
		return await result.MatchAsync(
			success: async response =>
			{
				await action(response);
				return result;
			},
			failure: _ => input);
	}
}