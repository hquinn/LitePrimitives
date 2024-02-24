namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for ToTask on the Result type.
/// </summary>
public static class Result_ToTask
{
	/// <summary>
	///     Creates a <see cref="Task"/> from <see cref="Result{TResponse}"/>.
	/// </summary>
	/// <param name="input">The input to create into a <see cref="Task"/>.</param>
	/// <typeparam name="TResponse">The type of the <paramref name="input"/>.</typeparam>
	/// <returns>The created <see cref="Task"/> of from the <paramref name="input"/>.</returns>
	public static Task<Result<TResponse>> ToTask<TResponse>(this Result<TResponse> input)
	{
		return Task.FromResult(input);
	}
}