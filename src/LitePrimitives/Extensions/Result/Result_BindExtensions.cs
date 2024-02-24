namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for Bind on the Result type.
/// </summary>
public static class Result_BindExtensions
{
	/// <summary>
	///     Returns the result of the <paramref name="bindFunc"/> if the <paramref name="input"/> parameter is in the Success state,
	///     otherwise returns <see cref="Result{TOutput}"/> with error(s) from <paramref name="input"/> in the Failure state.
	/// </summary>
	/// <param name="input">The input to check.</param>
	/// <param name="bindFunc">The func to apply if <paramref name="input"/> is in the Success state.</param>
	/// <typeparam name="TInput">The type of the <paramref name="input"/>.</typeparam>
	/// <typeparam name="TOutput">The type of the output.</typeparam>
	/// <returns>
	///	    The result of <paramref name="bindFunc"/> if <paramref name="input"/> is in the Success state,
	///		otherwise returns <see cref="Result{TOutput}"/> with errors from <paramref name="input"/> in the Failure state.
	/// </returns>
	public static Result<TOutput> Bind<TInput, TOutput>(
		this Result<TInput> input,
		Func<TInput, Result<TOutput>> bindFunc)
	{
		return input.Match(
			success: response => bindFunc(response), 
			failure: error => error.ToResult<TOutput>());
	}
	
	/// <summary>
	///     Returns the result of the <paramref name="bindFunc"/> if the <paramref name="input"/> parameter is in the Success state,
	///     otherwise returns <see cref="Task"/> of type <see cref="Result{TOutput}"/> with error(s) from <paramref name="input"/> in the Failure state.
	/// </summary>
	/// <param name="input">The input to check.</param>
	/// <param name="bindFunc">The asynchronous func to apply if <paramref name="input"/> is in the Success state.</param>
	/// <typeparam name="TInput">The type of the <paramref name="input"/>.</typeparam>
	/// <typeparam name="TOutput">The type of the output.</typeparam>
	/// <returns>
	///	    The result of <paramref name="bindFunc"/> if <paramref name="input"/> is in the Success state,
	///		otherwise returns <see cref="Task"/> of type <see cref="Result{TOutput}"/> with errors from <paramref name="input"/> in the Failure state.
	/// </returns>
	public static async Task<Result<TOutput>> BindAsync<TInput, TOutput>(
        this Task<Result<TInput>> input,
        Func<TInput, Task<Result<TOutput>>> bindFunc)
	{
		var result = await input;
		
		return await result.MatchAsync(
			success: async response => await bindFunc(response), 
			failure: error => error.ToResult<TOutput>().ToTask());
	}
}