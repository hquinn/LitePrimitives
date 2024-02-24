namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for Map on the Result type.
/// </summary>
public static class Result_MapExtensions
{
	/// <summary>
	///     Transforms the <paramref name="input"/> when it's in a Success state into <see cref="Result{TOutput}"/>,
	///     otherwise returns <see cref="Result{TOutput}"/> with error(s) from <paramref name="input"/> in the Failure state.
	/// </summary>
	/// <param name="input">The input to transform.</param>
	/// <param name="transform">The function to transform the <paramref name="input"/> to <typeparamref name="TOutput"/>.</param>
	/// <typeparam name="TInput">The type of the <paramref name="input"/>.</typeparam>
	/// <typeparam name="TOutput">The type of the transformed response.</typeparam>
	/// <returns>
	///	    The result of <paramref name="transform"/> if <paramref name="input"/> is in the Success state,
	///		otherwise returns <see cref="Result{TOutput}"/> with errors from <paramref name="input"/> in the Failure state.
	/// </returns>
	public static Result<TOutput> Map<TInput, TOutput>(
		this Result<TInput> input, 
		Func<TInput, TOutput> transform)
	{
		return input.Match(
			success: response => transform(response).ToResult(), 
			failure: errors => errors.ToResult<TOutput>());
	}

	/// <summary>
	///     Transforms the <paramref name="input"/> when it's in a Success state into <see cref="Result{TOutput}"/>,
	///     otherwise returns <see cref="Task"/> of type <see cref="Result{TOutput}"/> with error(s) from <paramref name="input"/> in the Failure state.
	/// </summary>
	/// <param name="input">The input to transform.</param>
	/// <param name="transform">The asynchronous function to transform the <paramref name="input"/> to <typeparamref name="TOutput"/>.</param>
	/// <typeparam name="TInput">The type of the <paramref name="input"/>.</typeparam>
	/// <typeparam name="TOutput">The type of the transformed response.</typeparam>
	/// <returns>
	///	    The result of <paramref name="transform"/> if <paramref name="input"/> is in the Success state,
	///		otherwise returns <see cref="Task"/> of type <see cref="Result{TOutput}"/> with errors from <paramref name="input"/> in the Failure state.
	/// </returns>
	public static async Task<Result<TOutput>> MapAsync<TInput, TOutput>(
		this Result<TInput> input,
		Func<TInput, Task<TOutput>> transform)
	{
		return await input.MatchAsync(
			success: async response => (await transform(response)).ToResult(), 
			failure: errors => errors.ToResult<TOutput>().ToTask());
	}

	/// <summary>
	///     Transforms the <paramref name="input"/> when it's in a Success state into <see cref="Result{TOutput}"/>,
	///     otherwise returns <see cref="Task"/> of type <see cref="Result{TOutput}"/> with error(s) from <paramref name="input"/> in the Failure state.
	/// </summary>
	/// <param name="input">The asynchronous input to transform.</param>
	/// <param name="transform">The asynchronous function to transform the <paramref name="input"/> to <typeparamref name="TOutput"/>.</param>
	/// <typeparam name="TInput">The type of the <paramref name="input"/>.</typeparam>
	/// <typeparam name="TOutput">The type of the transformed response.</typeparam>
	/// <returns>
	///	    The result of <paramref name="transform"/> if <paramref name="input"/> is in the Success state,
	///		otherwise returns <see cref="Task"/> of type <see cref="Result{TOutput}"/> with errors from <paramref name="input"/> in the Failure state.
	/// </returns>
	public static async Task<Result<TOutput>> MapAsync<TInput, TOutput>(
		this Task<Result<TInput>> input,
		Func<TInput, Task<TOutput>> transform)
	{
		var result = await input;
		
		return await result.MatchAsync(
			success: async response => (await transform(response)).ToResult(), 
			failure: errors => errors.ToResult<TOutput>().ToTask());
	}
}